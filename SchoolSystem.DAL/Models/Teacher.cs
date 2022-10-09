using SchoolSystem.DAL.BaseModel;

namespace SchoolSystem.DAL.Models
{
    public class Teacher : Person
    {
       public virtual ICollection<Clasroom>? Clasrooms { get; set; }
    }
}