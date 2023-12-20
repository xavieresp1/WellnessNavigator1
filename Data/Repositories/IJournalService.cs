using WellnessNavigator.Data.Models;

namespace WellnessNavigator1.Data.Repositories
{
    public interface IJournalService
    {
        public void SaveJournalEntry(JournalEntry je);
        public void UpdateJournalEntry(JournalEntry je);
        public List<JournalEntry> GetJournalEntries();
        public JournalEntry GetJournalEntry(int id);
        public string StripHtmlTags(string html);
    }
}
