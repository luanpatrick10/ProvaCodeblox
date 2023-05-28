namespace ProvaCodeblox.Servicos.Excecoes
{
    public class SemDadosDisponiveisException : Exception
    {
        public SemDadosDisponiveisException() : base("Não há dados disponíveis.")
        {

        }
    }
}
