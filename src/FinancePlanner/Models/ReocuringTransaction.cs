using System;

namespace FinancePlanner.Models
{
    public class ReocuringTransaction : Transaction
    {
        public int? NumberOfTimes { get; set; }
        public DateTime? EndDate { get; set; }
    }
}