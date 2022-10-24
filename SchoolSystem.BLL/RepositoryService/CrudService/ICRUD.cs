using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.RepositoryService.CrudService
{
    public interface ICRUD<ReturnType, ModelType, PostModelType, UpdateModelType>
        where ReturnType : class
        where PostModelType : class
        where UpdateModelType : class
        where ModelType : class
    {
        Task<Response<ReturnType>> DeleteRecord(Guid id, string customMessage);
        Task<Response<List<ReturnType>>> GetAll();
        Task<Response<ReturnType>> GetSpecificRecord(Guid id, string customMessage);
        Task<Response<ReturnType>> PostRecord(PostModelType record, string customMessage);
        Task<Response<ReturnType>> PutRecord(Guid id, UpdateModelType recordFromClient, string customMessage);
    }
}