using System.Collections.Generic;

namespace Dominio.Repositorios
{
    public interface IRepositorio<T>
    {
        void Incluir(T entidade);
        void Alterar(T entidade);
        IList<T> PesquisarLista(T entidade);
        T Pesquisar(int id);
        void Excluir(T entidade);
        void Excluir(int id);
        bool Transacional();
        IList<T> PesquisarLista();
    }
}