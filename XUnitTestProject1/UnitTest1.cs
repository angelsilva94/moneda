using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moneda;
using moneda.Controllers;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var currencyMock = new Mock<ICurrencyService>();
            var loggerMock = new Mock<ILogger<ExchangeController>>();

            currencyMock.Setup(x => x.GetRate(CurrencyType.USD)).Returns(Task.FromResult(new Exchange() { BuyValue = 1, SellValue = 1, Currency = CurrencyType.USD}));
            ExchangeController exchange = new ExchangeController(loggerMock.Object, currencyMock.Object);
            var result = await exchange.Get(CurrencyType.USD);

            Assert.IsType<ActionResult<double>>(result);
            //what is the scope of the unit tests? Also add other tests for testing the same controller for exceptions and the other controllers


        }
    }
}
