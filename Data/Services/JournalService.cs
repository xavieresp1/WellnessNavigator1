using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WellnessNavigator.Data;
using WellnessNavigator.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using WellnessNavigator1.Data.Repositories;
using System.Text.RegularExpressions;

namespace WellnessNavigator1.Data.Services
{
    public class JournalService : IJournalService
    {
        private readonly IDbContextFactory<WellnessNavigatorDbContext> factory;

        public JournalService(IDbContextFactory<WellnessNavigatorDbContext> f)
        {
            factory = f ?? throw new NullReferenceException("Couldn't create the context factory");
        }

        public void SaveJournalEntry(JournalEntry je)
        {
            using (var context = factory.CreateDbContext())
            {
                context.JournalEntries.Add(je);
                context.SaveChanges();
            }
        }
        public void UpdateJournalEntry(JournalEntry je)
        {
            
            using (var context = factory.CreateDbContext())
            {
                context.JournalEntries.Update(je);
                context.SaveChanges();
            }
           
        }
        public List<JournalEntry> GetJournalEntries()
        {
            List<JournalEntry> tempList = new List<JournalEntry>();
            using(var context = factory.CreateDbContext())
            {
                var query = (from j in context.JournalEntries
                             select j).ToList();
                tempList.AddRange(query);
            }
            return tempList;
        }
        public JournalEntry GetJournalEntry(int id) {
            JournalEntry tempEntry = new JournalEntry();
         
            using(var context= factory.CreateDbContext())
            {
                var query = (from j in context.JournalEntries
                             where j.EntryID == id
                             select j).FirstOrDefault();
                tempEntry = query;
            }
            return tempEntry;
        }
        

        public string StripHtmlTags(string input)
        {
            // Regular expression to match HTML tags
            string pattern = @"<[^>]+>";

            // Remove all HTML tags from the input string
            string result = Regex.Replace(input, pattern, string.Empty);

            return result;
        }

    }
}
