namespace WellnessNavigator1.Data.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using WellnessNavigator.Data;
    using WellnessNavigator.Data.Models;
    using WellnessNavigator1.Classes;
    using global::WellnessNavigator1.Data.Repositories;
    using System.Security.Cryptography;
    public class AccountService : IAccountService
    {
        private readonly IDbContextFactory<WellnessNavigatorDbContext> factory;

        public AccountService(IDbContextFactory<WellnessNavigatorDbContext> f)
        {
            factory = f ?? throw new NullReferenceException("Couldn't create the context factory");
        }
        public bool SaveUserAccount(UserAccount ua)
        {
            using (var context = factory.CreateDbContext())
            {
                context.UserAccounts.Add(ua);
                context.SaveChanges();
                return true;
            }
        }

        public void UpdateUserAccount(UserAccount ua)
        {

            using (var context = factory.CreateDbContext())
            {
                context.UserAccounts.Update(ua);
                context.SaveChanges();
            }

        }
        public void UpdateUserAccounts(List<UserAccount> ua)
        {
            using (var context = factory.CreateDbContext())
            {
                context.UserAccounts.UpdateRange(ua);
                context.SaveChanges();
            }
        }
        public List<UserAccount> GetUserAccounts()
        {
            List<UserAccount> tempList = new List<UserAccount>();
            using (var context = factory.CreateDbContext())
            {
                var query = (from u in context.UserAccounts
                                select u).ToList();
                tempList.AddRange(query);
            }
            return tempList;
        }
        public UserAccount GetUserAccount(string username)
        {
            UserAccount tempEntry = new UserAccount();

            using (var context = factory.CreateDbContext())
            {
                var query = (from u in context.UserAccounts
                                where u.username == username
                                select u).FirstOrDefault();
                tempEntry = query;
            }
            return tempEntry;
        }
        public List<UserAccount> GetCrackedAccounts()
        {
            List<UserAccount> tempList = new List<UserAccount>();
            using (var context = factory.CreateDbContext())
            {
                var query = (from u in context.UserAccounts
                                join r in context.Rainbow
                                on u.password equals r.hashed_passwords
                                select u).ToList();
                tempList.AddRange(query);
            }
            UpdateCrackedAccounts(tempList);
            return tempList;
        }
        private void UpdateCrackedAccounts(List<UserAccount> ua)
        {
            foreach (var userAccount in ua)
            {
                userAccount.cracked = true;
            }

            using (var context = factory.CreateDbContext())
            {
                context.UserAccounts.UpdateRange(ua);
                context.SaveChanges();
            }
        }
        public List<UserAccount> GetNonRainbowAccounts()
        {
            List<UserAccount> tempList = new List<UserAccount>();
            using (var context = factory.CreateDbContext())
            {
                var query = (from u in context.UserAccounts
                                where (!context.Rainbow.Any(r => r.hashed_passwords == u.password) && u.hashSelection == 1)
                                select u).ToList();

                tempList.AddRange(query);
            }
            return tempList;
        }

        public void AccountUpgrader(List<UserAccount> uas) 
        {
            SHA256WithSaltandPepper SHA256SP = new SHA256WithSaltandPepper();
            foreach (UserAccount ua in uas)
            {
                int SaltSize = 16;
                // Generate a random salt
                ua.salt = new byte[SaltSize];
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(ua.salt);
                }
                ua.message = "your account security has been automatically upgraded w/ DH SHASP";
                ua.password = SHA256SP.ComputeHash(ua.password, ua.salt);
                ua.hashSelection = 2;
                ua.cracked = false;
            }
            UpdateUserAccounts(uas);
        }
        public void AccountUpgrader(UserAccount ua) 
        {
            SHA256WithSaltandPepper SHA256SP = new SHA256WithSaltandPepper();
            int SaltSize = 16;
            // Generate a random salt
            ua.salt = new byte[SaltSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(ua.salt);
            }
            ua.message = "Double Hash SHASP Protection";
            ua.password = SHA256SP.ComputeHash(ua.password, ua.salt);
            ua.hashSelection = 2;
            ua.cracked = false;
            UpdateUserAccount(ua); 
        }
        public void AccountUpgrader(UserAccount ua, string newPassword)
        {
            MD5Algorithm MD5 = new MD5Algorithm();
            newPassword = MD5.ComputeHash(newPassword);
            SHA256WithSaltandPepper SHA256SP = new SHA256WithSaltandPepper();
            int SaltSize = 16;
            // Generate a random salt
            ua.salt = new byte[SaltSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(ua.salt);
            }
            ua.message = "Double Hash SHASP Protection";
            ua.password = SHA256SP.ComputeHash(newPassword, ua.salt);
            ua.hashSelection = 2;
            ua.cracked = false;
            UpdateUserAccount(ua);
        }
        public void MassUpgrader()
        {
            List<UserAccount> AllAccounts = GetUserAccounts();
            foreach(UserAccount account in AllAccounts)
            {
                if(account.hashSelection == 1)
                {
                    SHA256WithSaltandPepper SHA256SP = new SHA256WithSaltandPepper();
                    int SaltSize = 16;
                    // Generate a random salt
                    account.salt = new byte[SaltSize];
                    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(account.salt);
                    }
                    account.message = "Double Hash SHASP Protection";
                    account.password = SHA256SP.ComputeHash(account.password, account.salt);
                    account.hashSelection = 2;
                }
            }
            UpdateUserAccounts(AllAccounts);
        }
        public List<UserAccount> GetUsersWithWeakPasswords()
        {
            List<UserAccount> tempList = new List<UserAccount>();
            using (var context = factory.CreateDbContext())
            {
                var query = (from u in context.UserAccounts
                             where(u.cracked == true)
                             select u).ToList();
                tempList.AddRange(query);
            }
            return tempList;
        }

    }
}

