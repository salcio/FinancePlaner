<Query Kind="Program">
  <NuGetReference>DDay.iCal</NuGetReference>
  <Namespace>Transaction = UserQuery.Transaction</Namespace>
  <Namespace>DDay.iCal</Namespace>
</Query>

void Main()
{
  var transactions = new List<Transaction>
                     {
                         new Transaction(740, "rent", new DateTime(2015, 2, 17)),
                         new Transaction(703, "jan", new DateTime(2015, 2, 15)),
                         new Transaction(505, "santander", new DateTime(2015, 3, 09)),
                         new Transaction(15.1, "insurance", new DateTime(2015, 3, 03)),
                         new Transaction(6.5, "account", new DateTime(2015, 3, 02)),
                         new Transaction(150, "saving", new DateTime(2015, 3, 01)),
                         new Transaction(12.12, "tv", new DateTime(2015, 3, 02)),
                         new Transaction(10, "spotify", new DateTime(2015, 2, 23)),
                         new Transaction(6, "netflix", new DateTime(2015, 2, 21)),
                         new Transaction(3, "equifax", new DateTime(2015, 2, 16)),
                         new Transaction(3.99, "creditex", new DateTime(2015, 03, 11)),
                         new Transaction(25, "tesco", new DateTime(2015, 2, 25)),
                         new Transaction(905.55, "halifax", new DateTime(2015, 03, 12)),
                         new Transaction(14.21, "bos", new DateTime(2015, 03, 12)),
                         new Transaction(19.29, "loyds", new DateTime(2015, 03, 06)),
                         new Transaction(291.67, "zopa", new DateTime(2015, 03, 09)),
                         new Transaction(470, "polska wesele", new DateTime(2015, 02, 03),1),
                         new Transaction(200, "polska karta I pozyczka", new DateTime(2015, 02, 03),1),
                         new Transaction(1400, "santander", new DateTime(2015, 02, 03),1),
                         new Transaction(449, "sofa", new DateTime(2015, 02, 20), 1),
                     };
					 
	transactions.OrderBy(t=>t.Date).Dump();
	transactions.FutureTransactions(DateTime.Now.Date, new DateTime(2015,3,9).Date).OrderBy(t=>t.Date).Dump();
	
	
}

public static class TransactionFilters
{
	public static IEnumerable<Transaction> FutureTransactions(this IEnumerable<Transaction> transactions, DateTime startDate,DateTime endDate)
	{
		return transactions.SelectMany(transaction=>
		{
			var evnt = new Event();
			evnt.Start = new iCalDateTime(transaction.Date);
			evnt.Duration = new TimeSpan(1,0,0);
			
			var rule = new RecurrencePattern(FrequencyType.Monthly);
			evnt.RecurrenceRules.Add(rule);		
			if (transaction.NumberOfTimes.HasValue)
				rule.Count = transaction.NumberOfTimes.Value;
			rule.SetToLastDayOfTheMonth(transaction.Date.Day);
			return RecurrenceUtil.GetOccurrences(evnt,new iCalDateTime(startDate.Date),new iCalDateTime(endDate.Date), true)
			.Select(o=>
				{
					var t =	transaction.Clone();
					t.Date = o.Period.StartTime.Date;
					return t;
				});
		});
	}
}

public static class RecurrencePatterExtensions
{
	public static RecurrencePattern SetToLastDayOfTheMonth(this RecurrencePattern pattern, int eventDay)
	{
		if (eventDay==31)
		{
			pattern.ByMonthDay.Add(-1);
		}
		else if (eventDay>=29)
		{
			pattern.ByMonth.Add(2);
			pattern.ByMonthDay.Add(-1);
		}
		return pattern;
	}
}

public class Transaction
{
	public Transaction(double amount, string description, DateTime date, int? numberOfTimes=null)
	{
		Amount = amount;
		Description = description;
		Date = date;
		NumberOfTimes = numberOfTimes;
	}
   public string Description { get; set; }
   public double Amount { get; set; }
   public DateTime Date { get; set; }
   public int? NumberOfTimes { get; set; }
   public DateTime? EndDate { get; set; }
   
   public Transaction Clone()
   {
   		return (Transaction)this.MemberwiseClone();
   }
}

// Define other methods and classes here
