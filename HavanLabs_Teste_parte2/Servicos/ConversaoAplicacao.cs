using System;
using System.Collections.Generic;
using System.Linq;

namespace Cambio
{
    public class ConversaoAplicacao
    {
        public decimal Dolar = 5.24m, 
                       Euro = 6.36m, 
                       LibraEsterlina = 7.41m, 
                       Iene = 20.73m,                       // valores baseados no real
                       FrancoSuico = 5.82m,
                       DolarCanadense = 4.33m, 
                       Yuan = 1.22m;


        public decimal Cambio(Moedas entrada, Moedas saida, decimal valor)
        {
            return entrada switch
            {
                Moedas.Dolar => CambiarDolar(saida, valor),
                Moedas.Real => CambiarReal(saida, valor),
                Moedas.Euro => CambiarEuro(saida, valor),
                Moedas.LibraE => CambiarLibraE(saida, valor),
                Moedas.Iene => CambiarIen(saida, valor),
                Moedas.FrancoS => CambiarYuan(saida, valor),
                Moedas.DolarC => CambiarDolarC(saida, valor),
                Moedas.Yuan => CambiarFrancoS(saida, valor),
                _ => throw new ArgumentException("Opção de conversão inválida"),
            };
        }


        private decimal CambiarEuro(Moedas saida, decimal valor)
        {
            var valores = new Dictionary<Moedas, decimal>();
            valores.Add(Moedas.Dolar, Euro / Dolar);
            valores.Add(Moedas.Real, Euro);
            valores.Add(Moedas.LibraE, LibraEsterlina / Euro);
            valores.Add(Moedas.Iene, Euro * Iene);
            valores.Add(Moedas.FrancoS, Euro / FrancoSuico);
            valores.Add(Moedas.DolarC, Euro / DolarCanadense);
            valores.Add(Moedas.Yuan, Euro * Yuan);
            return Conversao(saida, valores, valor);
        }

        private decimal CambiarReal(Moedas saida, decimal valor)
        {
            var valores = new Dictionary<Moedas, decimal>();
            valores.Add(Moedas.Euro, Euro);
            valores.Add(Moedas.Dolar, Dolar);
            valores.Add(Moedas.LibraE, LibraEsterlina);
            valores.Add(Moedas.Iene, Iene);
            valores.Add(Moedas.FrancoS, FrancoSuico);
            valores.Add(Moedas.DolarC, DolarCanadense);
            valores.Add(Moedas.Yuan, Yuan);
            return Conversao(saida, valores, valor);
        }

        private decimal CambiarDolar(Moedas saida, decimal valor)
        {
            var valores = new Dictionary<Moedas, decimal>();
            valores.Add(Moedas.Euro, Dolar / Euro);
            valores.Add(Moedas.Real, Dolar);
            valores.Add(Moedas.LibraE, Dolar / LibraEsterlina);
            valores.Add(Moedas.Iene, Dolar * Iene);
            valores.Add(Moedas.FrancoS, 0.90m);
            valores.Add(Moedas.DolarC, Dolar / DolarCanadense);
            valores.Add(Moedas.Yuan, Dolar * Yuan);
            return Conversao(saida, valores, valor);
        }
        private decimal CambiarLibraE(Moedas saida, decimal valor)
        {
            var valores = new Dictionary<Moedas, decimal>();
            valores.Add(Moedas.Euro, LibraEsterlina / Euro);
            valores.Add(Moedas.Real, LibraEsterlina);
            valores.Add(Moedas.Dolar, LibraEsterlina / Dolar);
            valores.Add(Moedas.Iene, LibraEsterlina * Iene);
            valores.Add(Moedas.FrancoS, LibraEsterlina / FrancoSuico);
            valores.Add(Moedas.DolarC, LibraEsterlina / DolarCanadense);
            valores.Add(Moedas.Yuan, LibraEsterlina * Yuan);
            return Conversao(saida, valores, valor);
        }
        private decimal CambiarIen(Moedas saida, decimal valor)
        {
            var valores = new Dictionary<Moedas, decimal>();
            valores.Add(Moedas.Euro, 1 / (Iene * Euro));
            valores.Add(Moedas.Real, 5.26m);
            valores.Add(Moedas.LibraE, 1 / (Iene * LibraEsterlina));
            valores.Add(Moedas.Dolar, 1 / (Iene * Dolar));
            valores.Add(Moedas.FrancoS, 1 / (Iene * FrancoSuico));
            valores.Add(Moedas.DolarC, 1 / (Iene * DolarCanadense));
            valores.Add(Moedas.Yuan, Yuan / Iene);
            return Conversao(saida, valores, valor);
        }
        private decimal CambiarFrancoS(Moedas saida, decimal valor)
        {
            var valores = new Dictionary<Moedas, decimal>();
            valores.Add(Moedas.Euro, FrancoSuico / Euro);
            valores.Add(Moedas.Real, 5.26m);
            valores.Add(Moedas.LibraE, FrancoSuico / LibraEsterlina);
            valores.Add(Moedas.Iene, FrancoSuico * Iene);
            valores.Add(Moedas.Dolar, FrancoSuico / Dolar);
            valores.Add(Moedas.DolarC, FrancoSuico / DolarCanadense);
            valores.Add(Moedas.Yuan, FrancoSuico * Yuan);
            return Conversao(saida, valores, valor);
        }
        private decimal CambiarDolarC(Moedas saida, decimal valor)
        {
            var valores = new Dictionary<Moedas, decimal>();
            valores.Add(Moedas.Euro, DolarCanadense / Euro);
            valores.Add(Moedas.Real, 5.26m);
            valores.Add(Moedas.LibraE, DolarCanadense / LibraEsterlina);
            valores.Add(Moedas.Iene, DolarCanadense * Iene);
            valores.Add(Moedas.FrancoS, DolarCanadense / FrancoSuico);
            valores.Add(Moedas.Dolar, Dolar / DolarCanadense);
            valores.Add(Moedas.Yuan, DolarCanadense * Yuan);
            return Conversao(saida, valores, valor);
        }
        private decimal CambiarYuan(Moedas saida, decimal valor)
        {
            var valores = new Dictionary<Moedas, decimal>();
            valores.Add(Moedas.Euro, Yuan / Euro);
            valores.Add(Moedas.Real, 5.26m);
            valores.Add(Moedas.LibraE, Yuan / LibraEsterlina);
            valores.Add(Moedas.Iene, Iene / Yuan);
            valores.Add(Moedas.FrancoS, Yuan / FrancoSuico);
            valores.Add(Moedas.DolarC, Yuan / DolarCanadense);
            valores.Add(Moedas.Dolar, Yuan / Dolar);
            return Conversao(saida, valores, valor);
        }

        private decimal Conversao(Moedas moedas, Dictionary<Moedas, decimal> dic, decimal valor)
        {
            if (moedas == Moedas.Euro)
                return valor * dic.FirstOrDefault(async => async.Key == Moedas.Euro).Value;
            if (moedas == Moedas.Real)
                return valor * dic.FirstOrDefault(async => async.Key == Moedas.Real).Value;
            if (moedas == Moedas.Dolar)
                return valor * dic.FirstOrDefault(async => async.Key == Moedas.Dolar).Value;
            if (moedas == Moedas.Iene)
                return valor * dic.FirstOrDefault(async => async.Key == Moedas.Iene).Value;
            if (moedas == Moedas.LibraE)
                return valor * dic.FirstOrDefault(async => async.Key == Moedas.LibraE).Value;
            if (moedas == Moedas.FrancoS)
                return valor * dic.FirstOrDefault(async => async.Key == Moedas.FrancoS).Value;
            if (moedas == Moedas.DolarC)
                return valor * dic.FirstOrDefault(async => async.Key == Moedas.DolarC).Value;

            return valor * dic.FirstOrDefault(async => async.Key == Moedas.Yuan).Value;

        }

    }
}