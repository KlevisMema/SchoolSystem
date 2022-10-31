namespace SchoolSystem.BLL.ServiceInterfaces
{
    public interface IExists
    {
        Task<bool> DoesExists(Guid examId, Guid studentId, Guid subjectId);
    }
}