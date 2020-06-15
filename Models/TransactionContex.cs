using System;
using Microsoft.EntityFrameworkCore;

namespace moneda
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Charge> Charges { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { UserId = 1 });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2 });
            modelBuilder.Entity<User>().HasData(new User { UserId = 3 });
            modelBuilder.Entity<User>().HasData(new User { UserId = 4 });
            modelBuilder.Entity<User>().HasData(new User { UserId = 5 });

            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 1, ChargeId = 1, ChargeDate = new DateTime(2020, 06, 06), amount = 100, currency = CurrencyType.USD });
            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 1, ChargeId = 2, ChargeDate = new DateTime(2020, 06, 06), amount = 200, currency = CurrencyType.Real });
            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 2, ChargeId = 3, ChargeDate = new DateTime(2017, 01, 01), amount = 200, currency = CurrencyType.USD });
            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 2, ChargeId = 4, ChargeDate = new DateTime(2020, 03, 06), amount = 300, currency = CurrencyType.Real });
            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 3, ChargeId = 5, ChargeDate = new DateTime(2020, 04, 06), amount = 50, currency = CurrencyType.USD });
            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 3, ChargeId = 6, ChargeDate = new DateTime(2020, 05, 06), amount = 187, currency = CurrencyType.Real });
            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 4, ChargeId = 7, ChargeDate = new DateTime(2020, 03, 06), amount = 176, currency = CurrencyType.USD });
            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 4, ChargeId = 8, ChargeDate = new DateTime(2020, 04, 06), amount = 60, currency = CurrencyType.Real });
            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 5, ChargeId = 9, ChargeDate = new DateTime(2020, 05, 06), amount = 12, currency = CurrencyType.USD });
            modelBuilder.Entity<Charge>().HasData(new Charge { UserId = 5, ChargeId = 10, ChargeDate = new DateTime(2020, 02, 06), amount = 100, currency = CurrencyType.Real });





        }

    }

}
