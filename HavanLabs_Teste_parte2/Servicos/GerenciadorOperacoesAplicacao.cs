using Cambio;
using HavanLabs_Teste_parte2.Persistencia;
using System;
using System.Linq;

namespace HavanLabs_Teste_parte2.Servicos
{
    public class GerenciadorOperacoesAplicacao
    {
        public void Texto()
        {
            Cabecalho();
            Console.WriteLine("Por favor, informe o seu nome:");
            string nome = Console.ReadLine();
            Cabecalho();
            Console.WriteLine("Informe qual é a sua moeda de origem? \r\n");
            ObterOpcoesMoedas();
            string entrada = Console.ReadLine();
            Cabecalho();
            Console.WriteLine("Qual será a moeda de destino?\r\n");
            ObterOpcoesMoedas();
            string saida = Console.ReadLine();
            Cabecalho();
            Console.WriteLine("Qual o valor de " + entrada + " que deseja cambiar para " + saida + " ?");
            decimal valor = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Nós cobraremos uma taxa de 10% para realizar a conversão da moeda. \r\n");
            Console.WriteLine(RealizarCambio(nome, valor, entrada, saida));
            Rodape();
        }

        public Conversao RealizarCambio(string nome, decimal valor, string entrada, string saida)
        {
            ConversaoAplicacao conversaoAplicacao = new ConversaoAplicacao(); 
            var cambio = conversaoAplicacao.Cambio(EnumExtention.GetValueFromDescription<Moedas>(entrada), EnumExtention.GetValueFromDescription<Moedas>(saida), valor);
            var taxa = 0.10;
            var conversao = new Conversao(nome, Porcentagem(valor, taxa), ValorFinal(valor, taxa), DateTime.Now, entrada, saida, cambio, valor);
            ConvercaoRepositorio.Add(conversao);
            return conversao;
        }

        public void ListarValores()
        {
            Cabecalho();
            Console.WriteLine("Lista de valores totais: ");
            Console.WriteLine(ConvercaoRepositorio.ListaConversao().Sum(a => a.ValorTotal));
            Rodape();
        }

        public void ListarOperacoes()
        {
            Cabecalho();
            Console.WriteLine("Lista de Operações realizadas: ");

            for (int i = 0; i < ConvercaoRepositorio.ListaConversao().Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i} - " + ConvercaoRepositorio.ListaConversao()[i]);
            }
            Rodape();
        }

        public void ListarTaxa()
        {
            Cabecalho();
            Console.WriteLine("Lista de taxas cobradas durante a execução: ");
            Console.WriteLine(ConvercaoRepositorio.ListaConversao().Sum(a => a.Taxa));
            Rodape();
        }
        public decimal Porcentagem(decimal valor, double taxa)
        {
            return (decimal)taxa * valor; // 10%
        }

        public decimal ValorFinal(decimal valor, double taxa)
        {
            return Porcentagem(valor, taxa) + valor; // valor + %
        }

        public void ObterOpcoesMoedas()
        {
            Console.WriteLine(
             "Trabalhamos com as seguites moedas: \r\n"
            + "Dólar \r\n"
            + "Euro \r\n"
            + "Libra Estrelina \r\n"
            + "Iene \r\n"
            + "Franco Suíço \r\n"
            + "Dólar Canadense \r\n"
            + "Real \r\n"
            + "Yan");
            Console.WriteLine();
        }

        public void Rodape()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }


        public void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("---Calculadora---");
            Console.WriteLine();
        }

    }
}
