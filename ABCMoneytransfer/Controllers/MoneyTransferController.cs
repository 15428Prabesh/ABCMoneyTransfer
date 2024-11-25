using Application.DTOs;
using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ABCMoneytransfer.Controllers
{
    [Authorize(Roles = "admin")]
    public class MoneyTransferController : Controller
    {
        private readonly MoneyTransferService _moneyTransferService;

        public MoneyTransferController(MoneyTransferService moneyTransferService)
        {
            _moneyTransferService = moneyTransferService;
        }

        [HttpGet]
        public async Task<IActionResult> Transfer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(MoneyTransferDto dto)
        {
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (ModelState.IsValid)
            {
                try
                {
                    dto.UserId = currentUserId;
                    var success = await _moneyTransferService.TransferMoneyAsync(dto.BankName,dto.AccountNumber,dto.ReceiverFirstName,dto.ReceiverMiddleName,
                                    dto.ReceiverLastName,dto.ReceiverAddress, dto.ReceiverCountry,dto.TransferAmountMYR,dto.ExchangeRate, dto.PayoutAmountNPR);
                    if (success)
                    {
                        await _moneyTransferService.StoreTransactionDetails(dto);
                        ViewBag.Message = "Transfer successful!";
                        return RedirectToAction("Confirmation"); 
                    }
                    ModelState.AddModelError(string.Empty, "Transfer failed.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred while processing the transfer: {ex.Message}");
                }
                
            }
            return View(dto);
        }
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
