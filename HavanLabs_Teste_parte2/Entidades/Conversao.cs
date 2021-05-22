using System;
using System.Globalization;

namespace HavanLabs_Teste_parte2
{
    public class Conversao
    {
        public DateTime DataHora { get; set; }
        public string NomeCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Taxa { get; set; }
        public string MoedaOrigem { get; set; }
        public string MoedaDestino { get; set;}
        public decimal ValorConvetido { get; set; }
        public decimal ValorOriginal { get; set; }

        public Conversao(string nome,
            decimal taxa ,
            decimal valor, 
            DateTime dataHora,
            string moedaOrigem,
            string moedaDestino,
            decimal valorConvertido,
            decimal valorOriginal)
        {
            Taxa = taxa;
            ValorTotal = valor;
            NomeCliente = nome;
            DataHora = dataHora;
            MoedaOrigem = moedaOrigem;
            MoedaDestino = moedaDestino;
            ValorOriginal = valorOriginal;
            ValorConvetido = valorConvertido;
        }
        public override string ToString()
        {
            return "Senhor(a) "
                + NomeCliente + ", a sua quantidade de "
                + MoedaDestino + " será de: " 
                + ValorConvetido.ToString("F2", CultureInfo.InvariantCulture)
                +". A taxa de 10% cobrada em cima do cambio será de: " + Taxa.ToString("F2", CultureInfo.InvariantCulture) + " "
                + MoedaOrigem + ". Sendo assim o valor final será de: " + ValorTotal.ToString("F2", CultureInfo.InvariantCulture) +" "+ MoedaOrigem + ".\n"
                + "Data e hora da operação: "+DataHora;
        }
    }
}
