using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WellnessNavigator.Data;

namespace WellnessNavigator1.Data.Services
{
    public class GoalsService
    {
        private readonly WellnessNavigatorDbContext WNC;

        public GoalsService(WellnessNavigatorDbContext wellnessNavigatorDbContext)
        {
            WNC = wellnessNavigatorDbContext ?? throw new NullReferenceException("couldnt establish the DB context");
        }
    }
}
