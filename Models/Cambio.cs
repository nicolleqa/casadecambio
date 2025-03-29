using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casadecambio.Models
{
    public enum Moneda
    {
        USD,
        PEN,
        BRL
    }
    public class Cambio
    {
        public decimal? MontoOrigen { get; set; }
        public decimal? MontoDestino { get; set; }
        public Moneda TipoMonedaOrigen { get; set; }
        public Moneda TipoMonedaDestino { get; set; }
        public decimal? TasaCambio { get; set; }

        public decimal Convertir()
        {
            switch (TipoMonedaOrigen)
            {
                case Moneda.USD:
                    if (TipoMonedaDestino == Moneda.PEN)
                    {
                        MontoDestino = MontoOrigen * (decimal)3.652263; // Ejemplo de tasa de cambio
                    }
                    else if (TipoMonedaDestino == Moneda.BRL)
                    {
                        MontoDestino = MontoOrigen * (decimal)5.7622705; // Ejemplo de tasa de cambio
                    }
                    break;
                case Moneda.PEN:
                    if (TipoMonedaDestino == Moneda.USD)
                    {
                        MontoDestino = MontoOrigen * (decimal)0.27380284; // Ejemplo de tasa de cambio
                    }
                    else if (TipoMonedaDestino == Moneda.BRL)
                    {
                        MontoDestino = MontoOrigen * (decimal)1.577726; // Ejemplo de tasa de cambio
                    }
                    break;
                case Moneda.BRL:
                    if (TipoMonedaDestino == Moneda.USD)
                    {
                        MontoDestino = MontoOrigen / (decimal)0.1735427; // Ejemplo de tasa de cambio
                    }
                    else if (TipoMonedaDestino == Moneda.PEN)
                    {
                        MontoDestino = MontoOrigen * (decimal)0.6338236; // Ejemplo de tasa de cambio
                    }
                    break;
            }
            if (MontoDestino > 0)
            {
                return MontoDestino ?? 0;
            }
            else
            {
                return MontoDestino ?? 0;
            }
        }
    }
}