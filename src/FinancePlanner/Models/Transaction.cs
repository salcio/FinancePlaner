using System;

namespace FinancePlanner.Models
{
    public class Transaction : Entity
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionStatus Status { get; set; }
        public int? NumberOfTimes { get; set; }
        public DateTime? EndDate { get; set; }
    }
}