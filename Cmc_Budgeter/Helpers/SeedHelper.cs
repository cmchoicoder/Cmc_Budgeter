using Cmc_Budgeter.Enumerations;
using Cmc_Budgeter.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Cmc_Budgeter.Helpers
{
    public class SeedHelper
    {
       // private ApplicationDbContext Db { get; set; }
       // private RoleManager<IdentityRole> RoleManager { get; set; }
       // private UserManager<ApplicationUser> UserManager { get; set; }
       // private readonly string DefaultAvatar, DefaultPassword, DefaultHouseName;
       // private readonly char SplitCharacter;

       // public SeedHelper()
       // {
       //     Db = new ApplicationDbContext();
       //     RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Db));
       //     UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Db));

       //     DefaultAvatar = ReadKeyValue(Setting.DefaultAvatar);
       //     DefaultPassword = ReadkeyValue(Setting.DefaultPassword);
       //     SplitCharacter = char.Parse(ReadkeyValue(Setting.SplitCharacter));
       //     DefaultHouseName = ReadKeyValue(Setting.SeededHouseName);
       // }

       // public void SeedRoles()
       // {
       //     foreach(var role in Enum.GetValues(typeof(Role)).Cast<Role>().ToList())
       //     {
       //         SeedRole(role);
       //     }
       // }
       // public void SeedHouse()
       // {
       //     Db.Households.AddOrUpdate(t => t.Name, new Models.Household { Name = DefaultHouseName, Greeting = "This is the default greeting", Established = DateTime.Now });
       //     Db.SaveChanges();
       // }
       // public void SeedUsers()
       // {
       //     var houseId = Db.Households.AsNoTracking().FirstOrDefault(h => h.Name == DefaultHouseName).Id;
       //     foreach (var user in Enum.GetValues(typeof(Role)).Cast<Role>().ToList())
       //     {
       //         var userData = WebConfigurationManager.AppSettings[user.ToString()];
       //         SeedUser(userData);
       //     }
       // }
       // public void AssignRoles()
       // {
       //     string userId = null;
       //     foreach (var role in Enum.GetValues(typeof(Role)).Cast<Role>().ToList())
       //     {
       //         var userData = WebConfigurationManager.AppSettings[role.ToString()];
       //         var userEmail = userData.Split(SplitCharacter)[0];

       //         userId = UserManager.FindByEmail(userEmail).Id;
       //         UserManager.AddToRole(userId, role.ToString());
       //     }
       // }

       // public void SeedNotification()
       // {
       //     var headOfHouseholdEmail = ReadKeyValue(Setting.HeadOfHouseholdEmail);
       //     var ownerId = Db.Users.FirstOrDefault(u => u.Email == headOfHouseholdEmail).Id;
       //     var householdId = Db.Households.AsNoTracking().FirstOrDefault(h => h.Name == DefaultHouseName).Id;
       //     var subject = WebConfigurationManager.AppSettings[Setting.DefaultNotificationSubject.ToString()];
       //     var body = WebConfigurationManager.AppSettings[Setting.DefaultNotificationBody.ToString()];
       //     var currentDate = DateTime.Now;
       //     try
       //     {
       //         Db.Notifications.AddOrUpdate(
       //             n => n.Subject,
       //                 new Notification
       //                 {
       //                     Created = currentDate,
       //                     OwnerId = ownerId,
       //                     HouseholdId = householdId,
       //                     Subject = subject,
       //                     Body = body,
       //                     Read = false
       //                 });
       //         Db.SaveChanges();
       //     }
       //     catch (System.Exception ex)
       //     {
       //         Logger.AddException(ex);
       //     }
       // }
       // public void SeedAccountTypes()
       // {
       //     foreach (var type in Enum.GetValues(typeof(Enumerations.AccountType)).Cast<Enumerations.AccountType>().ToList())
       //     {
       //         Db.AccountTypes.AddOrUpdate(
       //             t => t.Type,
       //             new Models.AccountType { Type = type.ToString(), Description = "This is a description of the " + type.ToString() + "" }
       //             );
       //     }
       //     Db.SaveChanges();
       // }
       // public void SeedTransactionTypes()
       // {

       //     try
       //     {
       //         foreach (var type in Enum.GetValues(typeof(Enumerations.TransactionType)).Cast<Enumerations.TransactionType>().ToList())
       //         {
       //             Db.TransactionTypes.AddOrUpdate(
       //                 t => t.Name,
       //                     new Models.TransactionType { Name = type.ToString(), Description = "This is a description of the " + type.ToString + "" }
       //                 );
       //         }
       //         Db.SaveChanges();
       //     }
       //     catch (System.Exception ex)
       //     {
       //         Logger.AddException(ex);
       //     }
       // }

       // public void SeedBudgets()
       //         {
       //             try
       //             {
       //                 var seededHouseId = Db.Households.AsNoTracking().FirstOrDefault(h => h.Name == DefaultHouseName).Id;
       //                 var now = DateTime.Now;

       //                 Db.Budgets.AddOrUpdate(
       //                     t => t.Name,
       //                         new Models.Budget { Name = "Household Utilities", HouseholdId = seededHouseId, Created = now, Target = 600.00 },
       //                         new Models.Budget { Name = "Automotive Maintenance", Household = seededHouseId, Created = now, Target = 500.00 },
       //                         new Models.Budget { Name = "Clothing", Household = seededHouseId, Created = now, Target = 250.00 },
       //                         new Models.Budget { Name = "Groceries", Household = seededHouseId, Created = now, Target = 400.00 }
       //                     );
       //                 Db.SaveChanges();
       //             }
       //             catch (System.Exception ex)
       //             {
       //                 Logger.AddException(ex);
       //             }
       //         }

       // public void SeedBudgeItems()
       // {
       //     try
       //     {
       //         //var utilitiesBudgetId = Db.Budgets.AsNoTracking().FirstOrDefault(b =>b.Name == "Household Utilities").Id
       //         //var autoMaintenanceBudgetId = Db.Budgets.AsNoTracking().FirstOrDefault(b =>b.Name == "Automotive Maintenance").Id

       //         var now = DateTime.Now;
       //         Db.BudgetItems.AddOrUpdate(
       //             t => t.Name,
       //                 new Models.BudgetItem { Name = "Gas", BudgetId = utilitiesBudgetId, Created = now, Target = 150.00}
       //                 new Models.BudgetItem { Name = "Electric", BudgetId = utilitiesBudgeId, Created = now, Target = }
       //                 new Models.BudgetItem { Name = "Water/Sewage", BudgetId = utilitiesBudgeId, Created = now, Target = }
       //                 new Models.BudgetItem { Name = "Internet", BudgetId = utilitiesBudgeId, Created = now, Target = }
       //                 new Models.BudgetItem { Name = "Repairs", BudgetId = utilitiesBudgeId, Created = now, Target = }
       //                 new Models.BudgetItem { Name = "Fuel", BudgetId = utilitiesBudgeId, Created = now, Target = }
       //             )



       //     }


       // }
       // public void Seedtransactions()
       // {
       //     var ownerEmail = ReadKeyValue(Setting.HeadOfHouseholdEmail);
       //     var ownerId = UserManager.FindByEmail(ownerEmail).Id;

       //     var accountTypes = Db.BankAccounts;
       //     var budgetItems = Db.BudgetItems;
       //     var transactionTypes = Db.TransactionTypes;

       //     //var checkingAccountId = accountTypes.FirstOrDefault(b => b.AccountTypeId == (int)Enumerations.AccountTypes)
       //     //var savingsAccountId = accountTypes.FirstOrDefault(b => b.AccountTypeId == (int)Enumerations.AccountTypes)

       //     //var depositTransactionTypeId = transactionTypes.FirstOrDefault(t => t.Name == Enumerations.TransactionTypes)
       //     //var withdrawalTransactionTypeId = transactionTypes.FirstOrDefault(t => t.Name == Enumerations.TransactionTypes)
       //     var gasBudgetItemId = budgetItems.FirstOrDefault(b => b.Name == "Gas").Id;
       //     var electricBudgetItemId = budgetItems.FirstOrDefault(b => b.Name == "Electric").Id;

       //     Db.Transactions.AddOrUpdate(
       //         t => t.Memo,
       //             new Transaction {
       //                 BankAccountId = checkingAccountId,
       //                 BudgetItemId = gasBudgetItemId,
       //                 OwnerId = ownerId,
       //                 TransactionTypeId = withdrawalTransactionTypeId,
       //                 Amount = 145.57,
       //                 Created = DateTime.Now,
       //                 Memo = "Paid monthly budgeted Gas Bill..."
       //             },
       //             //new Transaction
       //             //new Transaction
       //         );
       //     Db.SaveChanges();
       // }


       ////Private section only for internal calls...
       // private void SeedRole(Role role)
       // {
       //     var roleName = role.ToString();
       //     if (!Db.Roles.Any(r => r.Name == roleName))
       //         RoleManager.Create(new IdentityRole { Name = roleName });
       // }
       // private void SeedUser(string userData)
       // {


       //     var data = userData.Split(SplitCharacter);
       //     var email = data[0];

       //     try
       //     {
       //         if (!Db.Users.Any(u => u.Email == email))
       //         {
       //             UserManager.Create(new ApplicationUser
       //             {
       //                 HouseholdId = houseId,
       //                 Email = email,
       //                 UserName = email,
       //                 FirstName = data[1],
       //                 LastName = data[2],
       //                 DisplayName = data[3],
       //                 AvatarUrl = DefaultAvatar
       //             }, DefaultPassword);
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         Db.Errors.Add(new Error { Name = "Exception", Message = ex.Message });
       //         Console.WriteLine(ex.Message);
       //     }
       // }


    }
}