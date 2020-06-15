using System;

namespace moneda
{
    public class Exchange
    {
        public double BuyValue { get; set; }
        public double SellValue { get; set; }
        public CurrencyType Currency { get; set; }
    }
    public enum CurrencyType
    {
        USD = 0,
        Real = 1,
        Canada = 2
    }
}
