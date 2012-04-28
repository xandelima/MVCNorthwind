using System;
using System.Collections.Generic;
using Dominio.Repositorios;
using NHibernate;
using NHibernate.Criterion;
using NHIbernateRepository.Infra;


namespace Repositorio.Base
{
    /// <summary>
    /// Classe de apoio para facilitar as operações básicas em NHibernate
    /// </summary>
    /// <typeparam name="T">Tipo da Entidade</typeparam>
    public class NhRepo<T> : IRepositorio<T>, ITransacao, IDisposable
    {
        protected ISession _session;
        protected ITransaction _transaction;

        public NhRepo()
        {
            _session = CreateSession.CriarSessao();
        }

        public void Incluir(T entidade)
        {
            _session.BeginTransaction();
            
            _session.Save(entidade);
            
            _session.Transaction.Commit();
        }

        public IList<T> PesquisarLista()
        {
            _session.BeginTransaction();
            IList<T> pesquisarLista = _session.CreateCriteria(typeof(T)).List<T>();
            _session.Transaction.Commit();
            return pesquisarLista;
        }

        public IList<T> PesquisarLista(T entidade)
        {
            _session.BeginTransaction();

            IList<T> pesquisarLista = null;

            Example criterios = Example.Create(entidade).ExcludeNulls().ExcludeZeroes().EnableLike(MatchMode.Anywhere);
            
            var id = (int) entidade.GetType().GetProperty("Id").GetValue(entidade, null);

            if (id == 0)
            {
                pesquisarLista = _session.CreateCriteria(typeof (T)).Add(criterios).List<T>();
            }
            else
            {
                var retorno = _session.Get<T>(id);
                
                if(null != retorno)
                    pesquisarLista = new List<T> { retorno };
            }

            _session.Transaction.Commit();

            return pesquisarLista;
        }

        public void Alterar(T entidade)
        {
            _session.BeginTransaction();
            _session.Update(entidade);
            _session.Transaction.Commit();
        }

        public void Excluir(T entidade)
        {
            _session.BeginTransaction();
            _session.Delete(entidade);
            _session.Transaction.Commit();
        }     
        
        //
        // Direto do "id"
        //

        public T Pesquisar(int id)
        {
            _session.BeginTransaction();
            var pesquisar = _session.Get<T>(id);
            _session.Transaction.Commit();
            return pesquisar;
        }

        public void Excluir(int id)
        {
            _session.BeginTransaction();
            var entidade = Pesquisar(id);
            _session.Delete(entidade);
            _session.Transaction.Commit();
        }
    
        #region Membros de ITransacao

        public void  IniciarTransacao()
        {
             _transaction = _session.BeginTransaction();
       }

        public void  ConfirmarTransacao()
        {
            _transaction.Commit();

            FecharTransacao();
        }

        public void  DesfazerTransacao()
        {
            _transaction.Rollback();

            FecharTransacao();
            FecharSessao();
        }

        private void FecharTransacao()
        {
            _transaction.Dispose();
            _transaction = null;
        }

        private void FecharSessao()
        {
            _session.Close();
            _session.Dispose();
            _session = null;
        }
        #endregion
    
        #region Membros de IDisposable

        public void  Dispose()
        {
            if (_transaction != null)
            {
                // Commit transaction by default, unless user explicitly rolls it back.
                // To rollback transaction by default, unless user explicitly commits,
                // comment out the line below.
                ConfirmarTransacao();
            }

            if (_session  != null)
            {
                _session.Flush(); // commit session transactions
                FecharSessao();
            }
        }

        #endregion

        #region Membros de IRepositorio<T>


        public bool Transacional()
        {
            return true;
        }

        #endregion
    }
}