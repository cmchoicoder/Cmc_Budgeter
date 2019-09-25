using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cmc_Budgeter.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        //[Required]
        //[StringLength(20, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Type { get; set; }

        //[Required]
        //[StringLength(50, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Description { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }
        public AccountType()
        {
            BankAccounts = new HashSet<BankAccount>();
        }
    }
}