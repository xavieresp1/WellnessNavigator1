using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.ComponentModel.DataAnnotations;

namespace WellnessNavigator.Data.Models
{
    public class JournalEntry
    {
        [Key]
        public int EntryID { get; set; }
        public int UserID { get; set; }
        public string? SentimentType { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }

        [MinLength(1)]
        [MaxLength(2000, ErrorMessage ="Entry cannot exceed 2000 characters")]
        [Required]
        public string? Content { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime? editedDate { get; set; }
  
    }
}
