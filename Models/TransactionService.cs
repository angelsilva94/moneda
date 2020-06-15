// using System;
// using System.Net;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Configuration;
// using Newtonsoft.Json.Linq;

// namespace moneda
// {
//     public class TransactionService : ITransactionService
//     {
//         private readonly IConfiguration Config;
//         private readonly ICurrencyService CurrencyService;
//         public TransactionService(IConfiguration config, ICurrencyService currencyService)
//         {
//             this.Config = config;
//             this.CurrencyService = currencyService;
//         }
//         // public async Task<double> ExchangeRate(CurrencyType currency)
//         // {
//         //     Exchange exchange = new Exchange();
//         //     double rate = 0;
//         //     exchange = await GetRate(currency);
//         //     return rate;
//         // }
        
        
        
//         //Dados un id de usuario, monto a comprar
//         // en pesos argentinos e identificador de moneda, el endpoint realizará una transacción que
//         // almacenará en la base de datos dicha compra registrando el usuario y los montos
//         // comprados en la unidad de la moneda (dólar o real). Por ejemplo, dado el monto 1000 y la
//         // moneda “dolar”, se registrará en la base de datos una compra con un valor resultado de
//         // 1000/{cotización dolar del dia} dólares.
//         // Se necesita validar los montos a comprar. Para el dólar, el límite es 200. Para el real,
//         // el límite es 300. Todos los límites son en la moneda extranjera, por usuario y por mes.
//         // Cualquier otra moneda solicitada deberá responderse con un error y mensaje apropiado.
//         public Task<User> Exchange(CurrencyType currency)
//         {
//         }
//         // public async Task<Exchange> GetRate(CurrencyType currency)
//         // {
//         //     Exchange exchange = new Exchange();
//         //     switch (currency)
//         //     {
//         //         case CurrencyType.Real:
//         //             exchange = await GetRealRate();
//         //             break;
//         //         case CurrencyType.USD:
//         //             exchange = await GetRate(Config["USDUrl"], CurrencyType.USD);
//         //             break;
//         //         case CurrencyType.Canada:
//         //             exchange = await GetRate(Config["CanadaUrl"], CurrencyType.Canada);
//         //             break;
//         //     }
//         //     return exchange;
//         // }
//         // public async Task<Exchange> GetRate(string url, CurrencyType currency)
//         // {
//         //     HttpClient client = new HttpClient();
//         //     var response = await client.GetAsync(url);
//         //     Exchange exchange = await FillCurrency(response, currency);
//         //     return exchange;
//         // }
//         // //Im asumming that all the external apis return the same structure
//         // private async Task<Exchange> FillCurrency(HttpResponseMessage response, CurrencyType currency)
//         // {
//         //     Exchange exchange = new Exchange();
//         //     if (response.StatusCode == HttpStatusCode.OK)
//         //     {
//         //         var content = await response.Content.ReadAsStringAsync();
//         //         //the response from the extenal api doesnt have a valid key/value pair, only the value, hence the parse into JObject

//         //         JArray jArray = JArray.Parse(content);
//         //         exchange.BuyValue = (double)jArray[0];
//         //         exchange.SellValue = (double)jArray[1];
//         //         exchange.Currency = currency;
//         //     }
//         //     return exchange;
//         // }
//         // private async Task<Exchange> GetRealRate()
//         // {
//         //     Exchange exchange = new Exchange();
//         //     if (String.IsNullOrWhiteSpace(Config["RealUrl"]))
//         //     {
//         //         exchange = await GetRate(Config["USDUrl"], CurrencyType.Real);
//         //         exchange.SellValue /= int.Parse(Config["RealUsdRate"]);
//         //     }
//         //     else
//         //     {
//         //         exchange = await GetRate(Config["RealUrl"], CurrencyType.Real);
//         //     }
//         //     return exchange;
//         // }
//     }
//     public interface ITransactionService
//     {
//         Task<User> Exchange(CurrencyType currency);
//     }
// }
