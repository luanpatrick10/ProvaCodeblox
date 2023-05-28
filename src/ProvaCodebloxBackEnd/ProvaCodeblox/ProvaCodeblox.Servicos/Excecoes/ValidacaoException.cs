using System.Text;

namespace ProvaCodeblox.Servicos.Excecoes
{
    public class ValidacaoException : Exception
    {
        public IEnumerable<string> Erros { get; set; }
        public ValidacaoException()
        {
        }
        public ValidacaoException(string mensagem) : base(mensagem)
        {
        }

        #region Métodos privados
        private string ConcatenarMensagensErro(IEnumerable<string> mensagensErro)
        {
            StringBuilder mensagensConcatenadas = new StringBuilder();

            var enumerator = mensagensErro.GetEnumerator();
            if (enumerator.MoveNext())
            {
                mensagensConcatenadas.Append(enumerator.Current);

                while (enumerator.MoveNext())
                {
                    mensagensConcatenadas.Append(",\n");
                    mensagensConcatenadas.Append(enumerator.Current);
                }
            }

            return mensagensConcatenadas.ToString();
        }
        #endregion
    }
}
