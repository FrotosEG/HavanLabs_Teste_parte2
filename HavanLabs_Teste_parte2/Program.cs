using HavanLabs_Teste_parte2.Servicos;
using System;

namespace Cambio
{
    public static class Program
    {
        static void Main(string[] args)
        {
            GerenciadorOperacoes();
        }
        private static void GerenciadorOperacoes()
        {
            try
            {
                var gerenciadorOperacoes = new GerenciadorOperacoesAplicacao();
                Console.WriteLine("Gerenciador de operações!");
                var sair = false;
                while (!sair)
                {
                    ObterOperacoes();
                    var opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            gerenciadorOperacoes.Texto();
                            break;
                        case 2:
                            gerenciadorOperacoes.ListarValores();
                            break;
                        case 3:
                            gerenciadorOperacoes.ListarTaxa();
                            break;
                        case 4:
                            gerenciadorOperacoes.ListarOperacoes();
                            break;
                        case 5:
                            sair = true;

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Infelizmente não foi possível executar sua ação!");     
            }   

        }
      
        private static void ObterOperacoes()
        {
            Cabecalho();
            Console.WriteLine("Selecione a operação que deseja realizar: ");
            Console.WriteLine(
              "1 - Realizar Operação. \r\n"
            + "2 - Valor total das operações. \r\n"
            + "3 - Valor total das taxas cobradas. \r\n"
            + "4 - Lista de operações. \r\n"
            + "5 - Sair");
            Console.WriteLine();
        }

        private static void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("---Calculadora---");
            Console.WriteLine();
        }
    }
}