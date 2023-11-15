using System.ComponentModel.DataAnnotations;

namespace StudentsMangement.Models
{
    public class Courze
    {
        [Key]

        public int Id { get; set; }
        public string Course { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public string Fees { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Staff>? Staffs { get; set; }

    }
}
