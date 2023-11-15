using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsMangement.Models
{
    public class Clazz
    {
        [Key]
        public int Id { get; set; }
        public string Section { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Staff>? Staffs { get; set; }
        public int StudentCount { get; set; }
        public int StaffCount { get; set; }
        [DataType(DataType.MultilineText)]
        public string Properties { get; set; }

    }
}
