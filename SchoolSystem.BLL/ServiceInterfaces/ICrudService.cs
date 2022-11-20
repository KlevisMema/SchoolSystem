using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.RepositoryServiceInterfaces
{
    public interface ICrudService
    <
        TReturnType,
        TInputType
    >
    where TReturnType : class
    where TInputType : class
    {
        Task<Response<List<TReturnType>>> GetRecords(CancellationToken cancellationToken);
        Task<Response<TReturnType>> GetRecord(Guid id, CancellationToken cancellationToken);
        Task<Response<TReturnType>> DeleteRecord(Guid id, CancellationToken cancellationToken);
        Task<Response<TReturnType>> PostRecord(TInputType viewModel, CancellationToken cancellationToken);
        Task<Response<TReturnType>> PutRecord(Guid id, TInputType viewModel, CancellationToken cancellationToken);
    }
}