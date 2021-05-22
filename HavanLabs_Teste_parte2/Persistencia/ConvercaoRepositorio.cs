using System.Collections.Generic;

namespace HavanLabs_Teste_parte2.Persistencia
{
    public static class  ConvercaoRepositorio
    {
        private static List<Conversao> _repositorio = new List<Conversao>();

        public static void Add(Conversao conversao)
        {
            _repositorio.Add(conversao);
        }
        public static List<Conversao> ListaConversao()
        {
            return _repositorio;
        }
    }
}
