using HavanLabs_Teste_parte2.Servicos;
using Xunit;

namespace HavanLabs_Teste_parte2_Testes
{
    public class GerenciadorOperacaoAplicacaoTeste
    {
        [Fact]
        public void RealizaCambioTeste()
        {
            var gerenciador = new GerenciadorOperacoesAplicacao();
            var nome = "Erick";
            var valor = 1000m;
            var entrada = "Dólar";
            var saida = "Euro";

            var resultado = gerenciador.RealizarCambio(nome, valor, entrada , saida);

            Assert.Equal(1100m, resultado.ValorTotal);
            Assert.Equal(823.90m, decimal.Parse(resultado.ValorConvetido.ToString("F2")));
        }
    }
}
