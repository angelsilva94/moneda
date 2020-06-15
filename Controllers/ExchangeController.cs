using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace moneda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly ILogger<ExchangeController> _logger;
        private readonly ICurrencyService _currencyService;


        public ExchangeController(ILogger<ExchangeController> logger, ICurrencyService currencyService)
        {
            _logger = logger;
            _currencyService = currencyService;
        }

        [HttpGet("{currency}")]
        public async Task<ActionResult<double>> Get(CurrencyType currency)
        {
            Exchange currentRate = null;
            try
            {
                currentRate = await _currencyService.GetRate(currency);
            }
            catch
            {
                var ex = new ErrorHandler(HttpStatusCode.InternalServerError, "There was an unexpected error");
                _logger.LogError(new EventId((int)ex.StatusCode,ex.StatusCode.ToString()),ex,ex.Message);
                throw ex;
            }
            if(currentRate != null){

                return Ok(currentRate.SellValue);
            }
            return NotFound();
        }

    }
}
