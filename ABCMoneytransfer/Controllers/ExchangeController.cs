using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABCMoneytransfer.Controllers
{
    [Authorize(Roles = "admin")]
    public class ExchangeController : Controller
    {
        private readonly ExchangeRateService _exchangeRateService;

        public ExchangeController(ExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rates = await _exchangeRateService.GetExchangeRatesAsync();
            return View(rates);
        }
    }
}
