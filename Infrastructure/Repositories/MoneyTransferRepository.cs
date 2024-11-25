using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MoneyTransferRepository :IMoneyTransferRepositories
    {
        private readonly AppDbContext _context;
        public MoneyTransferRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(Transfer transfer)
        {
            await _context.Transfers.AddAsync(transfer);
            await _context.SaveChangesAsync();
        }
    }
}
