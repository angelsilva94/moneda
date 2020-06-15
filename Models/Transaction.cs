using System;

namespace moneda
{
    public class Transaction
    {
        public int UserId { get; set; }
        public double Amount { get; set; }
        public CurrencyType Currency { get; set; }
    }
}
