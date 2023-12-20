using Microsoft.EntityFrameworkCore;
using WellnessNavigator.Data;
using WellnessNavigator.Data.Models;
using WellnessNavigator1.Data.Models;
using WellnessNavigator1.Data.Repositories;

namespace WellnessNavigator1.Data.Services
{
    public class FeedbackService:IFeedbackService
    {
        private readonly IDbContextFactory<WellnessNavigatorDbContext> factory;

        public FeedbackService(IDbContextFactory<WellnessNavigatorDbContext> f)
        {
            factory = f ?? throw new NullReferenceException("Couldn't create the context factory");
        }

        

        public void SaveFeedback(UserFeedback UF)
        {
            using (var context = factory.CreateDbContext())
            {
                context.Feedback.Add(UF);
                context.SaveChanges();
            }
        }
    }
}
