using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace moneda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeCurrencyController : ControllerBase
    {
        private readonly ILogger<ExchangeCurrencyController> _logger;
        private readonly ICurrencyService _currencyService;
        private readonly TransactionContext _transactionContext;
        private readonly IConfiguration _config;
        public ExchangeCurrencyController(ILogger<ExchangeCurrencyController> logger, ICurrencyService currencyService, TransactionContext transactionContext, IConfiguration config)
        {
            _logger = logger;
            _currencyService = currencyService;
            _transactionContext = transactionContext;
            _config = config;
        }
        //Dados un id de usuario, monto a comprar
        // en pesos argentinos e identificador de moneda, el endpoint realizará una transacción que
        // almacenará en la base de datos dicha compra registrando el usuario y los montos
        // comprados en la unidad de la moneda (dólar o real). Por ejemplo, dado el monto 1000 y la
        // moneda “dolar”, se registrará en la base de datos una compra con un valor resultado de
        // 1000/{cotización dolar del dia} dólares.
        // Se necesita validar los montos a comprar. Para el dólar, el límite es 200. Para el real,
        // el límite es 300. Todos los límites son en la moneda extranjera, por usuario y por mes.
        // Cualquier otra moneda solicitada deberá responderse con un error y mensaje apropiado.
        [HttpPost]
        public async Task<ActionResult<double>> PostTrans(Transaction trans)
        {
            try
            {
                User usr = await _transactionContext.Users.FindAsync(trans.UserId);
                await _transactionContext.Entry(usr).Collection(charge => charge.Charges).LoadAsync();
                if (usr != null)
                {
                    var currentRate = await _currencyService.GetRate(trans.Currency);
                    var temp = trans.Amount / currentRate.SellValue;
                    var temp1 = double.Parse(_config[trans.Currency.ToString()]);
                    bool isLimit = trans.Amount / currentRate.SellValue > double.Parse(_config[trans.Currency.ToString()]);
                    switch (trans.Currency)
                    {
                        case CurrencyType.USD:
                        case CurrencyType.Real:

                            if (!isLimit)
                            {
                                var charge = await UpdateOrInsertCharge(usr, trans, currentRate.SellValue);
                                return Created(nameof(Charge), charge); //here we can return the object as it is or use a DTO to only return certain properties
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ErrorHandler(e);
            }

            return NotFound();
        }
        private async Task<Charge> UpdateOrInsertCharge(User user, Transaction trans, double rate)
        {
            var charges = user.Charges.FindAll(x => x.ChargeDate.Month == DateTime.Now.Month && x.ChargeDate.Year == DateTime.Now.Year && x.currency == trans.Currency);
            double amount = trans.Amount / rate;
            var aux = double.Parse(_config[trans.Currency.ToString()]);
            if (charges.Count > 0)
            {
                foreach (var charge in charges)
                {
                    if (charge.amount + amount <= double.Parse(_config[trans.Currency.ToString()]))
                    {
                        // Ideally here we would check again for the rate of usd just in case it has changed, but because it only changes at the end and beginning of the day
                        // and not to waste a call to an external api I skipped this validation
                        // var currentRate = await _currencyService.GetRate(trans.Currency);
                        // if(trans.Amount / currentRate ){
                        //     throw Exception()
                        // }
                        Charge userCharge = await _transactionContext.Charges.FindAsync(charge.UserId);
                        userCharge.amount = userCharge.amount + (trans.Amount / rate);
                        userCharge.ChargeDate = DateTime.Now;
                        _transactionContext.Entry(userCharge).CurrentValues.SetValues(userCharge);
                        _transactionContext.Entry(userCharge).State = EntityState.Modified;
                        await _transactionContext.SaveChangesAsync();
                        return userCharge;
                    }
                    else
                    {
                        Exception excp = new ErrorHandler(HttpStatusCode.Forbidden, "The amount is invalid for the current month");
                        _logger.LogError(new EventId((int)HttpStatusCode.Forbidden, excp.Message), excp, excp.Message);
                        throw excp;
                    }
                }
            }
            if (amount > double.Parse(_config[trans.Currency.ToString()]))
            {
                Exception excp = new ErrorHandler(HttpStatusCode.Forbidden, $"Invalid operation, the amount is greater than:{_config[trans.Currency.ToString()]}");
                _logger.LogError(new EventId((int)HttpStatusCode.Forbidden, excp.Message), excp, excp.Message);
                throw excp;
            }
            Charge newCharge = new Charge(amount, trans.Currency, DateTime.Now, user.UserId);
            await _transactionContext.AddAsync(newCharge);
            await _transactionContext.SaveChangesAsync();
            return newCharge;
        }
    }
}