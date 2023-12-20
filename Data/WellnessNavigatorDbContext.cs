using Microsoft.EntityFrameworkCore;
using WellnessNavigator.Data.Models;
using WellnessNavigator1.Data.Models;

namespace WellnessNavigator.Data
{
    public class WellnessNavigatorDbContext : DbContext
    {
        public WellnessNavigatorDbContext(DbContextOptions<WellnessNavigatorDbContext> options) : base(options)
        {

        }

        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserFeedback> Feedback { get; set; }
        public DbSet<Rainbow> Rainbow { get; set; }
        //public DbSet<UserName> Usernames { get; set; }
    }

}
