namespace Dominio.Repositorios
{
    public interface ITransacao
    {
        void IniciarTransacao();
        void ConfirmarTransacao();
        void DesfazerTransacao();
    }
}