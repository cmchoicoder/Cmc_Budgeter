using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cmc_Budgeter.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int BankAccountId { get; set; }
        public  int? BudgetItemId { get; set; }
        public int TransactionTypeId { get; set; }
        public string OwnerId { get; set; }

        public string Memo { get; set; }
        public double Amount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        
        

        public virtual BankAccount BankAccount { get; set; }
        public virtual BudgetItem BudgetItem { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}