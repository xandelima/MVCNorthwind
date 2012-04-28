using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;
using System.Threading;
using MvcNorthwind.Models;
using MvcNorthwind.Map;

namespace NHIbernateRepository.Infra
{
    public static class CreateSession
    {
        // Localhost\SQLEXPRESS
        static string conexao = @"Data Source=Alexandre-DELL\SQLSERVER;Initial Catalog=Northwind;Persist Security Info=True;User ID=teste;Password=teste;";
        
        static ISession session;
        static ReaderWriterLock locker = new ReaderWriterLock();

        public static ISession CriarSessao()
        {

                if (session == null)
                {
                    var cfg = Fluently.Configure()
                       .Database(MsSqlConfiguration.MsSql2005.ConnectionString(conexao).ShowSql())
                       .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(CustomerMap))));
                         //.exposeconfiguration(cfgu =>
                           //     new schemaexport(cfgu).create(true, true));

                    session = cfg
                                .BuildSessionFactory()
                                .OpenSession();
                }

            return session;
        }

        public static void NewSession() 
        {
            ISession session = CriarSessao();
        }
    }
}
