using System.ComponentModel;

namespace Cambio
{
    public enum Moedas : short
    {
        [Description("Real")]
        Real = 0,
        [Description("Dólar")]
        Dolar = 1,
        [Description("Euro")]
        Euro = 2,
        [Description("Libra Esterlina")]
        LibraE = 3,
        [Description("Iene")]
        Iene = 4,
        [Description("Franco Suíço")]
        FrancoS = 5,
        [Description("Dólar Canadense")]
        DolarC = 6,
        [Description("Yuan")]
        Yuan = 7

    }
}
