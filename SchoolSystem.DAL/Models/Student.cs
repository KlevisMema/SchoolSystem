using SchoolSystem.DAL.BaseModel;

namespace SchoolSystem.DAL.Models
{
    public class Student : Person
    {
        public string ParentName { get; set; } = String.Empty;
    }
}