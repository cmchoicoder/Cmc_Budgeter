using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cmc_Budgeter.Models
{
    public class TransactionType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }


        public virtual ICollection<Transaction> Transactions { get; set; }
        
        public TransactionType()
        {
            Transactions = new HashSet<Transaction>();
        }
    }
}