namespace ProvaCodeblox.Dominio.ObjetosDeDominio
{
    public abstract class Entidade
    {
        public int Id { get; private set; }
        public abstract void ValidarEntidade();
    }
}
