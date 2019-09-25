using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cmc_Budgeter.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationUser : IdentityUser
    {
        public int HouseholdId { get; set; }

        [Required]
        [StringLength(40, ErrorMessage ="Must be between {2} and {1} characters long.",MinimumLength =1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string AvatarUrl { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
                //return FirstName + " " + LastName;
            }
        }
        [NotMapped]
        public string FullNameWithEmail
        {
            get
            {
                return $"\'{FirstName} {LastName}\'<{Email}>";
                //return $"{FullName}, {Email}";
            }
        }
        public virtual Household Household { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public ApplicationUser()
        {
            Notifications = new HashSet<Notification>();
            Transactions = new HashSet<Transaction>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Exception> Exceptions { get; set; }
    }
}