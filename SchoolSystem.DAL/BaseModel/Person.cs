using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SchoolSystem.DAL.Enums.GenderEnum;

namespace SchoolSystem.DAL.BaseModel
{
    public abstract class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string FullName { get; set; }  

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 

        [DataType(DataType.Password)]
        public string Password { get; set; } 

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } 

        public DateTime Date_Of_Join { get; set; }

        public Gender Sex { get; set; } 

        public string Adress { get; set; } 
    }
}