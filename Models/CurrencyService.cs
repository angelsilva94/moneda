using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace moneda
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IConfiguration Config;
        public CurrencyService(IConfiguration config)
        {
            this.Config = config;
        }
        public async Task<Exchange> GetRate(CurrencyType currency)
        {
            Exchange exchange = new Exchange();
            switch (currency)
            {
                case CurrencyType.Real:
                    exchange = await GetRealRate();
                    break;
                case CurrencyType.USD:
                    exchange = await GetRate(Config["USDUrl"], CurrencyType.USD);
                    break;
                case CurrencyType.Canada:
                    exchange = await GetRate(Config["CanadaUrl"], CurrencyType.Canada);
                    break;
                default:
                    throw new ErrorHandler(HttpStatusCode.NotFound, $"The Rate for the currency {currency.ToString()} is not valid");
            }
            return exchange;
        }
        public async Task<Exchange> GetRate(string url, CurrencyType currency)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                url = Config["USDUrl"];
            }
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            Exchange exchange = await FillCurrency(response, currency);
            return exchange;
        }
        //Im asumming that all the external apis return the same structure
        private async Task<Exchange> FillCurrency(HttpResponseMessage response, CurrencyType currency)
        {
            Exchange exchange = new Exchange();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                //the response from the extenal api doesnt have a valid key/value pair, only the value, hence the parse into JObject

                JArray jArray = JArray.Parse(content);
                exchange.BuyValue = (double)jArray[0];
                exchange.SellValue = (double)jArray[1];
                exchange.Currency = currency;
            }
            return exchange;
        }
        private async Task<Exchange> GetRealRate()
        {
            Exchange exchange = new Exchange();
            if (String.IsNullOrWhiteSpace(Config["RealUrl"]))
            {
                exchange = await GetRate(Config["USDUrl"], CurrencyType.Real);
                exchange.SellValue /= int.Parse(Config["RealUsdRate"]);
                exchange.BuyValue /= int.Parse(Config["RealUsdRate"]);

            }
            else
            {
                exchange = await GetRate(Config["RealUrl"], CurrencyType.Real);
            }
            return exchange;
        }
    }
    public interface ICurrencyService
    {
        Task<Exchange> GetRate(string url, CurrencyType currency);
        Task<Exchange> GetRate(CurrencyType currency);

    }
}
