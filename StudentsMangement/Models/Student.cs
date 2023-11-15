using System.ComponentModel.DataAnnotations;

namespace StudentsMangement.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Degree { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public Courze? Courzes { get; set; }
        public Clazz? Clazzes { get; set; }

    }
}
