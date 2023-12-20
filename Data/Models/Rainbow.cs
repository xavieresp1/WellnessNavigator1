using System.ComponentModel.DataAnnotations;

namespace WellnessNavigator.Data.Models
{
    public class Rainbow
    {
        [Key]
        public int Id { get; set; }
        public string plaintext_passwords { get; set; }
        public string hashed_passwords { get; set; }
    }
}
