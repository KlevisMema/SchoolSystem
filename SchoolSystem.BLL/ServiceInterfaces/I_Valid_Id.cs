namespace SchoolSystem.BLL.ServiceInterfaces
{
    public interface I_Valid_Id<T>
    {
       Task<bool> Bool(Guid id);
    }
}