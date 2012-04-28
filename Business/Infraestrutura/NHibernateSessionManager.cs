using System.Runtime.Remoting.Messaging;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using System.Reflection;
using MvcNorthwind.Map;
using MvcNorthwind.Models;

namespace Repositorio.Base
{
    /// <summary>
    /// Handles creation and management of sessions and transactions.  It is a singletocn because 
    /// building the initial session factory is very expensive. Inspiration for this class came 
    /// from Chapter 8 of Hibernate in Action by Bauer and King.  Although it is a sealed singleton
    /// you can use TypeMock (http://www.typemock.com) for more flexible testing.
    /// </summary>
    public sealed class NHibernateSessionManager
    {
        static ISession _session;
        
        #region Thread-safe, lazy Singleton
       
        /// <summary>
        /// Gets an instance via a thread-safe, lazy singleton.
        /// </summary>
        /// <remarks>
        /// See http://www.yoda.arachsys.com/csharp/singleton.html for more details about its implementation.
        /// </remarks>
        public static ISession Instance
        {
            get
            {
                if (_session == null)
                {
                    InitSessionFactory();
                    _session = sessionFactory.OpenSession(); 
                }

                return _session;
            }
        }

        /// <summary>
        /// Prevents a default instance of the NHibernateSessionManager class from being created.
        /// Initializes the NHibernate session factory upon instantiation.
        /// </summary>
        private NHibernateSessionManager()
        {
            //this.InitSessionFactory();
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            private Nested()
            {
            }

            internal static NHibernateSessionManager get() 
            {
                NHibernateSessionManager NHibernateSessionManager = new NHibernateSessionManager();
                
                return NHibernateSessionManager;
            }

            //static readonly 
        }

        #endregion

        private static void InitSessionFactory()
        {
            //Alexandre-PC\SQLSERVER
            FluentConfiguration cfg = Fluently.Configure()
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Employee>())
                .Database(MsSqlConfiguration.MsSql2005.ShowSql()
                              .ConnectionString(@"Data Source=Alexandre-DELL\SQLSERVER;Initial Catalog=Northwind;Persist Security Info=True;User ID=teste;Password=teste;")
                );
            
            sessionFactory = cfg.BuildSessionFactory();

        }

        /// <summary>
        /// Allows you to register an interceptor on a new session.  This may not be called if there is already
        /// an open session attached to the HttpContext.  If you have an interceptor to be used, modify
        /// the HttpModule to call this before calling BeginTransaction().
        /// </summary>
        public static void RegisterInterceptor(IInterceptor interceptor)
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                throw new CacheException(new System.Resources.ResourceManager(typeof(NHibernateSessionManager)).GetString("RegisterInterceptor_CacheException"));
            }

            GetSession(interceptor);
        }

        /// <summary>
        /// Gets a session (without an interceptor). This method is not called directly; instead,
        /// it gets invoked from other public methods.
        /// </summary>
        /// <returns></returns>
        public static ISession GetSession()
        {
            return GetSession(null);
        }

        /// <summary>
        /// Gets a session with or without an interceptor. This method is not called directly; instead,
        /// it gets invoked from other public methods.
        /// </summary>
        /// <remarks>
        /// Throws <see cref="HibernateException"/> if a reference to a session could not be retrieved.
        /// </remarks>
        private static ISession GetSession(IInterceptor interceptor)
        {
            ISession session = ContextSession;

            if (session == null)
            {
                if (interceptor != null)
                {
                    session = Instance;
                }
                else
                {
                    session = Instance;
                }

                ContextSession = session;
            }

            if (session == null)
            {
                throw new HibernateException("Session was null");
            }

            return session;
        }

        /// <summary>
        /// Flushes anything left in the session, committing changes as long as no <see cref="NHibernate.AssertionFailure">NHibernate.AssertionFailure's</see> are thrown.
        /// </summary>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static void FlushSession()
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                // Due to a bug in Hibernate (see http://forum.hibernate.org/viewtopic.php?p=2293664#2293664) make sure Flush() is wrapped in a transaction
                if (!HasOpenTransaction())
                {
                    BeginTransaction();
                }

                try
                {
                    session.Flush();
                }
                catch (NHibernate.AssertionFailure af)
                {
                    if (af.Message == "null id in entry (don't flush the Session after an exception occurs)")
                    {
                        System.Diagnostics.Trace.TraceError("NHibernate.AssertionFailure: " + af.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
                CommitTransaction();
            }

            ContextSession = null;
        }

        /// <summary>
        /// Flushes anything left in the session and closes the connection.
        /// </summary>
        public static void CloseSession()
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                FlushSession();
                session.Close();
            }

            ContextSession = null;
        }

        /// <summary>
        /// Begin an ITransaction (if one is not already active)
        /// </summary>
        public static void BeginTransaction()
        {
            ITransaction transaction = ContextTransaction;

            if (transaction == null)
            {
                transaction = GetSession().BeginTransaction();
                ContextTransaction = transaction;
            }
        }

        /// <summary>
        /// Begin an ITransaction (if one is not already active)
        /// </summary>
        /// <param name="isolationLevel"></param>
        public static void BeginTransaction(System.Data.IsolationLevel isolationLevel)
        {
            ITransaction transaction = ContextTransaction;

            if (transaction == null)
            {
                transaction = GetSession().BeginTransaction(isolationLevel);
                ContextTransaction = transaction;
            }
        }

        /// <summary>
        /// Commit transaction, if a transaction is currently open. Automatic rollback if commit fails.
        /// </summary>
        public static void CommitTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                if (HasOpenTransaction())
                {
                    try
                    {
                        transaction.Commit();
                    }
                    catch (NHibernate.AssertionFailure af)
                    {
                        if (af.Message == "null id in entry (don't flush the Session after an exception occurs)")
                        {
                            System.Diagnostics.Trace.TraceError("NHibernate.AssertionFailure: " + af.Message);
                        }
                        else
                        {
                            throw;
                        }
                    }
                    ContextTransaction = null;
                }
            }
            catch (HibernateException)
            {
                RollbackTransaction();
                throw;
            }
        }

        /// <summary>
        /// Checks for an open <see cref="ITransaction"/>.
        /// </summary>
        /// <returns></returns>
        public static bool HasOpenTransaction()
        {
            ITransaction transaction = ContextTransaction;

            return transaction != null && transaction.IsActive && !transaction.WasCommitted && !transaction.WasRolledBack;
        }

        /// <summary>
        /// Rollback transaction, closing the <see cref="ContextSession"/> if successful.
        /// </summary>
        public static void RollbackTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                if (HasOpenTransaction())
                {
                    transaction.Rollback();
                }

                ContextTransaction = null;
            }
            finally
            {
                if (ContextSession != null)
                {
                    ContextSession.Close();
                    ContextSession = null;
                }
            }
        }

        /// <summary>
        /// If within a web context, this uses <see cref="HttpContext" /> instead of the WinForms 
        /// specific <see cref="CallContext" />.  Discussion concerning this found at 
        /// http://forum.springframework.net/showthread.php?t=572.
        /// </summary>
        private static ITransaction ContextTransaction
        {
            // this should be here, but it starts a chain of having to mark this ALL over. So we're ignoring it here.
            // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, SkipVerification = true)]
            get
            {
                if (IsInWebContext())
                {
                    return (ITransaction)HttpContext.Current.Items[TRANSACTION_KEY];
                }
                else
                {
                    return (ITransaction)CallContext.GetData(TRANSACTION_KEY);
                }
            }
            // this should be here, but it starts a chain of having to mark this ALL over. So we're ignoring it here.
            // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, SkipVerification = true)]
            set
            {
                if (IsInWebContext())
                {
                    HttpContext.Current.Items[TRANSACTION_KEY] = value;
                }
                else
                {
                    CallContext.SetData(TRANSACTION_KEY, value);
                }
            }
        }

        /// <summary>
        /// If within a web context, this uses <see cref="HttpContext" /> instead of the WinForms 
        /// specific <see cref="CallContext" />.  Discussion concerning this found at 
        /// http://forum.springframework.net/showthread.php?t=572.
        /// </summary>
        private static ISession ContextSession
        {
            // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, SkipVerification = true)]  // this should be here, but it starts a chain of having to mark this ALL over. So we're ignoring it here.
            get
            {
                if (IsInWebContext())
                {
                    return (ISession)HttpContext.Current.Items[SESSION_KEY];
                }
                else
                {
                    return (ISession)CallContext.GetData(SESSION_KEY);
                }
            }
            // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, SkipVerification = true)]  // this should be here, but it starts a chain of having to mark this ALL over. So we're ignoring it here.
            set
            {
                if (IsInWebContext())
                {
                    HttpContext.Current.Items[SESSION_KEY] = value;
                }
                else
                {
                    CallContext.SetData(SESSION_KEY, value);
                }
            }
        }

        private static bool IsInWebContext()
        {
            return HttpContext.Current != null;
        }

        private const string TRANSACTION_KEY = "CONTEXT_TRANSACTION";
        private const string SESSION_KEY = "CONTEXT_SESSION";
        private static ISessionFactory sessionFactory;

        public static void InitSession() 
        {
            ISession session = GetSession(null);
        }
    }
}