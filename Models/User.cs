using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace moneda
{
    public class User
    {
        public User()
        {

        }
        public User(int id, List<Charge> userCharges)
        {
            UserId = id;
            Charges = userCharges;
        }
        public int UserId { get; set; }
        public virtual List<Charge> Charges { get; set; }
    }
    public class Charge
    {
        public Charge()
        {

        }
        public Charge(double chargeAmount, CurrencyType currencyType, DateTime chargeDate, int userId)
        {
            amount = chargeAmount;
            currency = currencyType;
            ChargeDate = chargeDate;
            UserId = userId;
        }
        public int ChargeId { get; set; }
        [Required]
        public double amount { get; set; }
        [Required]
        public CurrencyType currency { get; set; }
        [Required]
        public DateTime ChargeDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

}
