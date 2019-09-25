using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cmc_Budgeter.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public double Target { get; set; }
        public double Actual { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
     
        public virtual Budget Budget { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public BudgetItem()
        {
            Transactions = new HashSet<Transaction>();
        }
    }
}