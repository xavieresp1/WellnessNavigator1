using System.ComponentModel.DataAnnotations;

namespace WellnessNavigator.Data.Models
{
    public class UserAccount
    {
        [Key]
        public int userID { get; set; }

        [Required]
        [MaxLength(50)]
        public string displayName { get; set; }

        [Required]
        [MaxLength(50)]
        public string username { get; set; }

        [Required]
        [MaxLength(50)]
        public string password { get; set; }

        public bool isAdmin { get; set; }

        public string? message { get; set; }

        public byte[]? salt { get; set; }

        public int hashSelection { get; set; }
        public DateTime accountCreation { get; set; }

        public bool cracked { get; set; }

    }
}
