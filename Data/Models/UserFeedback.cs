using System.ComponentModel.DataAnnotations;

namespace WellnessNavigator1.Data.Models
{
    public class UserFeedback
    {
        [Key]
        public int Id { get; set; }
        public bool Useful { get; set; }
        public bool wouldUseAgain { get; set; }
        public bool wouldContinueToUse { get; set; }

        [Range(1, 10)]    
        public int score { get; set; }

        public string? comment { get; set; }
    }
}
