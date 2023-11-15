using System.ComponentModel.DataAnnotations;

namespace StudentsMangement.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Qualification { get; set; }
        public string Salary { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }
        public ICollection<Courze>? Department { get; set; }
        public ICollection<Clazz>? Clazzes { get; set; }

    }
}
