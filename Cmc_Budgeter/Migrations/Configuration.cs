namespace Cmc_Budgeter.Migrations
{
    using Cmc_Budgeter.Helpers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Cmc_Budgeter.Models;
    using Cmc_Budgeter.Enumerations;

    internal sealed class Configuration : DbMigrationsConfiguration<Cmc_Budgeter.Models.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Cmc_Budgeter.Models.ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(
               new UserStore<ApplicationUser>(context));

            #region Roles creation
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "HOH"))
            {
                roleManager.Create(new IdentityRole { Name = "HOH" });
            }
            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                roleManager.Create(new IdentityRole { Name = "Member" });
            }
            if (!context.Roles.Any(r => r.Name == "Lobbyist"))
            {
                roleManager.Create(new IdentityRole { Name = "Lobbyist" });
            }
            #endregion


            #region Seed a few "Houses"

            context.Households.AddOrUpdate(
                h => h.Name,
                    new Household { Name = "The Lobby", Greeting = "This is the Seeded Lobby.", Established = DateTime.Now },
                    new Household { Name = "Seeded Demo House", Greeting = "This is the Seeded Demo House.", Established = DateTime.Now }
                );
            context.SaveChanges();

            #endregion



            #region User creation
            var houses = context.Households.AsNoTracking();
            var lobbyId = houses.FirstOrDefault(h => h.Name == "The Lobby").Id;
            var seededHouseId = houses.FirstOrDefault(h => h.Name == "Seeded Demo House").Id;

            if (!context.Users.Any(u => u.Email == "DemoAdmin@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoAdmin@Mailinator.com",
                    Email = "DemoAdmin@Mailinator.com",
                    FirstName = "Caleb",
                    LastName = "Choi",
                    DisplayName = "Cmc Man",
                    HouseholdId = lobbyId
                }, "Abc&123!");

            }

            var userId = userManager.FindByEmail("DemoAdmin@Mailinator.com").Id;
            userManager.AddToRole(userId, "Admin");

            if (!context.Users.Any(u => u.Email == "DemoHOH@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoHOH@Mailinator.com",
                    Email = "DemoHOH@Mailinator.com",
                    FirstName = "Erika",
                    LastName = "Choi",
                    DisplayName = "Mrs Erika",
                    HouseholdId = seededHouseId
                }, "Abc&123!");
            }

            var hohId = userManager.FindByEmail("DemoHOH@Mailinator.com").Id;
            userManager.AddToRole(hohId, "HOH");

            if (!context.Users.Any(u => u.Email == "DemoMember@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoMember@Mailinator.com",
                    Email = "DemoMember@Mailinator.com",
                    FirstName = "Naomi",
                    LastName = "Choi",
                    DisplayName = "Ms Naomi",
                    HouseholdId = seededHouseId
                }, "Abc&123!");
            }
            userId = userManager.FindByEmail("DemoMember@Mailinator.com").Id;
            userManager.AddToRole(userId, "Member");

            if (!context.Users.Any(u => u.Email == "DemoLobbyist@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoLobbyist@Mailinator.com",
                    Email = "DemoLobbyist@Mailinator.com",
                    FirstName = "Ruth",
                    LastName = "Choi",
                    DisplayName = "Ms Ruth",
                    HouseholdId = lobbyId
                }, "Abc&123!");
            }
            userId = userManager.FindByEmail("DemoLobbyist@Mailinator.com").Id;
            userManager.AddToRole(userId, "Lobbyist");

            context.SaveChanges();
            #endregion

            var ownerId = userManager.FindByEmail("DemoAdmin@Mailinator.com").Id;
            var lobby = context.Households.Find(lobbyId);
            lobby.OwnerId = ownerId;
            context.SaveChanges();



            #region Seed Account Types
            context.AccountTypes.AddOrUpdate(
                a => a.Type,
                    new AccountType { Type = "Checking", Description = "Default Checking" },
                    new AccountType { Type = "Savings", Description = "Default Savings" }
                );
            #endregion

            #region Seed Transaction Types
            context.TransactionTypes.AddOrUpdate(
                a => a.Name,
                    new TransactionType { Name = "Deposit", Description = "Default Checking" },
                    new TransactionType { Name = "Withdrawal", Description = "Default Savings" }
                );
            context.SaveChanges();
            #endregion

            #region Seed Budget(s)
            var now = DateTime.Now;

            context.Budgets.AddOrUpdate(
                t => t.Name,
                    new Budget { Name = "Household Utilities", HouseholdId = seededHouseId, Created = now, Target = 600.00 },
                    new Budget { Name = "Automotive Maintenance", HouseholdId = seededHouseId, Created = now, Target = 500.00 },
                    new Budget { Name = "Entertainment", HouseholdId = seededHouseId, Created = now, Target = 250.00 },
                    new Budget { Name = "Clothing", HouseholdId = seededHouseId, Created = now, Target = 200.00 },
                    new Budget { Name = "Groceries", HouseholdId = seededHouseId, Created = now, Target = 400.00 }
                );
            context.SaveChanges();
            #endregion

            #region Seed BudgetItem(s)
            var budgets = context.Budgets.AsNoTracking();
            var utilitiesBudgetId = budgets.FirstOrDefault(b => b.Name == "Household Utilities").Id;
            var autoMaintenanceBudgetId = budgets.FirstOrDefault(b => b.Name == "Automotive Maintenance").Id;

            context.BudgetItems.AddOrUpdate(
                t => t.Name,
                    new BudgetItem { Name = "Gas", BudgetId = utilitiesBudgetId, Created = now, Target = 150.00 },
                    new BudgetItem { Name = "Electric", BudgetId = utilitiesBudgetId, Created = now, Target = 150.00 },
                    new BudgetItem { Name = "Water/Sewage", BudgetId = utilitiesBudgetId, Created = now, Target = 150.00 },
                    new BudgetItem { Name = "Internet", BudgetId = utilitiesBudgetId, Created = now, Target = 150.00},
                    new BudgetItem { Name = "Repairs", BudgetId = autoMaintenanceBudgetId, Created = now, Target = 200.00 },
                    new BudgetItem { Name = "Fuel", BudgetId = autoMaintenanceBudgetId, Created = now, Target = 300.00}
                );
            context.SaveChanges();
            #endregion

            #region Seed Bank Account(s)
            var accountTypes = context.AccountTypes.AsNoTracking();

            context.BankAccounts.AddOrUpdate(
                b => b.Name,
                    new BankAccount
                    {
                        Name = "Wells Fargo Checking",
                        HouseholdId = seededHouseId,
                        StartingBalance = 2500.00,
                        CurrentBalance = 2500.00,
                        AccountTypeId = accountTypes.FirstOrDefault(a => a.Type == "Checking").Id,
                        Created = DateTime.Now,
                        Description = "This is the Seeded Checking Account",
                        LowBalanceLevel = 250.00,
                        OwnerId = hohId,
                        Address1 = "123 Main Street",
                        Address2 = "Suite 300",
                        City = "High Point",
                        State = State.NC,
                        Zip = "27265",
                        Phone = "3365551212"
                    },
                    new BankAccount
                    {
                        Name = "Wells Fargo Savings",
                        HouseholdId = seededHouseId,
                        StartingBalance = 50000.00,
                        CurrentBalance = 50000.00,
                        AccountTypeId = accountTypes.FirstOrDefault(a => a.Type == "Savings").Id,
                        Created = DateTime.Now,
                        Description = "This is the Seeded Savings Account",
                        LowBalanceLevel = 50000.00,
                        OwnerId = hohId,
                        Address1 = "123 Main Street",
                        Address2 = "Suite 300",
                        City = "High Point",
                        State = State.NC,
                        Zip = "27265",
                        Phone = "3365551212"
                    }
                );
            context.SaveChanges();
            #endregion

            #region Seed Transactions
            var budgetItems = context.BudgetItems.AsNoTracking();
            var gasBudgetItemId = budgetItems.FirstOrDefault(b => b.Name == "Gas").Id;
            var electricBudgetItemId = budgetItems.FirstOrDefault(b => b.Name == "Electric").Id;

            var checkingAccountId = accountTypes.FirstOrDefault(a => a.Type == "Checking").Id;
            var savingsAccountId = accountTypes.FirstOrDefault(a => a.Type == "savings").Id;

            var transactionTypes = context.TransactionTypes.AsNoTracking();
            var depositTransactionTypeId = transactionTypes.FirstOrDefault(t => t.Name == "Deposit").Id;
            var withdrawalTransactionTypedId = transactionTypes.FirstOrDefault(t => t.Name == "Withdrawal").Id;

            context.Transactions.AddOrUpdate(
               t => t.Memo,
                    new Transaction
                    {
                        BankAccountId = checkingAccountId,
                        BudgetItemId = gasBudgetItemId,
                        OwnerId = hohId,
                        TransactionTypeId = withdrawalTransactionTypedId,
                        Amount = 145.57,
                        Created = now,
                        Memo = "Paid monthly budgeted Gas Bill..."
                    },
                    new Transaction
                    {
                        BankAccountId = checkingAccountId,
                        BudgetItemId = electricBudgetItemId,
                        OwnerId = hohId,
                        TransactionTypeId = withdrawalTransactionTypedId,
                        Amount = 64.25,
                        Created = now,
                        Memo = "Paid monthly budgeted Electric Bill..."
                    },
                    new Transaction
                    {
                        BankAccountId = savingsAccountId,
                        BudgetItemId = null,
                        OwnerId = hohId,
                        TransactionTypeId = depositTransactionTypeId,
                        Amount = 500.00,
                        Created = now,
                        Memo = "Automated monthly Savings transfer"
                    }
                );
            context.SaveChanges();
            #endregion

        }
    }
}
