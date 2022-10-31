using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.RepositoryServiceInterfaces
{
    public interface ICrudService<TReturnType, TInputType> 
        where TReturnType : class
        where TInputType  : class
    {
        Task<Response<List<TReturnType>>> GetRecords();
        Task<Response<TReturnType>> GetRecord(Guid id);
        Task<Response<TReturnType>> PostRecord(TInputType viewModel);
        Task<Response<TReturnType>> PutRecord(Guid id, TInputType viewModel);
        Task<Response<TReturnType>> DeleteRecord(Guid id);
    }
}