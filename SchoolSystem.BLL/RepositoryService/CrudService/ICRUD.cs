using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.RepositoryService.CrudService
{
    public interface ICRUD<ReturnType, ModelType, PostUpdateModelType>
        where ReturnType : class
        where PostUpdateModelType : class
        where ModelType : class
    {
        Task<Response<ReturnType>> DeleteRecord(Guid id, string customMessage);
        Task<Response<List<ReturnType>>> GetAll();
        Task<Response<ReturnType>> GetSpecificRecord(Guid id, string customMessage);
        Task<Response<ReturnType>> PostRecord(PostUpdateModelType record, string customMessage);
        Task<Response<ReturnType>> PutRecord(Guid id, PostUpdateModelType recordFromClient, string customMessage);
    }
}