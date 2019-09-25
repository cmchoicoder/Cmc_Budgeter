using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cmc_Budgeter.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string OwnerId { get; set; }
       
        [Required]
        [StringLength(40, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }

        [Display(Name = "Time to live")]
        public int TTL { get; set; }

        public bool IsValid { get; set; }
        public Guid Code { get; set; }

        public virtual ApplicationUser Owner { get; set; }
        public virtual Household Household { get; set; }
        
    }
}