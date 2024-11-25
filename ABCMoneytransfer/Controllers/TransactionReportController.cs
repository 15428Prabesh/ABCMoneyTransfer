using Application.DTOs;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABCMoneytransfer.Controllers
{
    [Authorize(Roles = "admin")]
    public class TransactionReportController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionReportController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GenerateReport(DateTime startDate, DateTime endDate)
        {
            var transactions = await GetTransactionsAsync(startDate, endDate);
            return View("Report", transactions);
        }

        private async Task<List<TransactionReportDto>> GetTransactionsAsync(DateTime startDate, DateTime endDate)
        {
            var transactions = await (from t in _context.Transfers
                                      join u in _context.Users on t.UserId equals u.Id
                                      where t.TransferDate >= startDate && t.TransferDate <= endDate && u.IsActive == true
                                      select new TransactionReportDto
                                      {
                                          SenderFirstName = u.FirstName,
                                          SenderMiddleName = u.MiddleName,
                                          SenderLastName = u.LastName,
                                          SenderAddress = u.Address,
                                          SenderCountry = u.Country,

                                          BankName = t.BankName,
                                          AccountNumber = t.AccountNumber,

                                          ReceiverFirstName = t.ReceiverFirstName,
                                          ReceiverMiddleName = t.ReceiverMiddleName,
                                          ReceiverLastName = t.ReceiverLastName,
                                          ReceiverAddress = t.ReceiverAddress,
                                          ReceiverCountry = t.ReceiverCountry,

                                          TransferAmountMYR = t.TransferAmountMYR,
                                          ExchangeRate = t.ExchangeRate,
                                          PayoutAmountNPR = t.PayoutAmountNPR,

                                          TransferDate = t.TransferDate
                                      }).ToListAsync();

            return transactions;
        } 
    }
}
