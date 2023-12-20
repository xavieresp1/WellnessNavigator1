using System.ComponentModel.DataAnnotations;

namespace WellnessNavigator1.Data.Models
{
    public class EditUser
    {
        public int userID { get; set; }

        [Required]
        [MaxLength(50)]
        public string username { get; set; }

        [Required]
        [MaxLength(50)]
        public string oldPassword { get; set; }

        [Required]
        [MaxLength(50)]
        public string newPassword { get; set; }

        [Required]
        [MaxLength(50)]
        public string confirmPassword { get; set; }

        public byte[]? salt { get; set; }

        public int hashSelection { get; set; }

        public bool cracked { get; set; }
    }
}
