using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TransactionReportDto
    {
            public string SenderFirstName { get; set; }
            public string SenderMiddleName { get; set; }
            public string SenderLastName { get; set; }
            public string SenderAddress { get; set; }
            public string SenderCountry { get; set; }
            public string BankName { get; set; }
            public string AccountNumber { get; set; }

            public string ReceiverFirstName { get; set; }
            public string ReceiverMiddleName { get; set; }
            public string ReceiverLastName { get; set; }
            public string ReceiverAddress { get; set; }
            public string ReceiverCountry { get; set; }

            public decimal TransferAmountMYR { get; set; }
            public decimal ExchangeRate { get; set; }
            public decimal PayoutAmountNPR { get; set; }

            public DateTime TransferDate { get; set; }
    }
    public class TransactionReportViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
