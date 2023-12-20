using WellnessNavigator1.Data.Models;

namespace WellnessNavigator1.Data.Repositories
{
    public interface IFeedbackService
    {
        public void SaveFeedback(UserFeedback uf);
    }
}
