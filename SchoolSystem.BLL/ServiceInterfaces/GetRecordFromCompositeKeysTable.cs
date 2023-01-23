using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.ServiceInterfaces
{
    public interface GetRecordFromCompositeKeysTable<TReturnType> where TReturnType : class
    {
        Task<Response<TReturnType>> GetRecordCompositeKeysTable(Guid FirstId, Guid SecondId, CancellationToken cancellationToken);
    }
}