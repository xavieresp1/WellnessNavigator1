using WellnessNavigator.Data.Models;
using WellnessNavigator1.Data.Models;

namespace WellnessNavigator1.Data.Repositories
{
    public interface IAccountService
    {
        public bool SaveUserAccount(UserAccount ua);
        public void UpdateUserAccount(UserAccount ua);
        public List<UserAccount> GetUserAccounts();
        public UserAccount GetUserAccount(string username);
        public List<UserAccount> GetNonRainbowAccounts();
        public List<UserAccount> GetCrackedAccounts();
        public void UpdateUserAccounts(List<UserAccount> ua);
        public void AccountUpgrader(UserAccount ua);
        public void AccountUpgrader(List<UserAccount> uas);
        public void AccountUpgrader(UserAccount ua, string pwrd);
        public void MassUpgrader();
        public List<UserAccount> GetUsersWithWeakPasswords();
    }
}
