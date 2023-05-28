namespace ProvaCodeblox.Servicos.Excecoes
{
    public class NaoEncontradoException : Exception
    {
        public NaoEncontradoException() : base("Sua solicitção não foi encontrado.")
        {

        }
    }
}
