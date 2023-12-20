using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace WellnessNavigator.Data.Models
{
    public class Goals
    {
        [Key]
        public int GoalID { get; set; }
        public int GoalTypeID { get; set; }
        public int PriorityLevel { get; set; }
        public Int32 Color { get; set; }
        public string GoalDescription { get; set; }
        public DateTime GoalDueDate { get; set; }
        public DateTime GoalCreationDate { get; set; }
    }
}
