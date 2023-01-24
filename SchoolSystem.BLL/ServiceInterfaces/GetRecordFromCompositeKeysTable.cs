using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.ServiceInterfaces
{
    /// <summary>
    ///     Inteface that provides a method to get a record from a table which is a composite key table
    /// </summary>
    /// <typeparam name="TReturnType"> The return type you wish to return from the function </typeparam>
    public interface GetRecordFromCompositeKeysTable<TReturnType> where TReturnType : class
    {
        /// <summary>
        ///     Get a specific record from an entity in database of a composite key table.
        /// </summary>
        /// <param name="FirstId"> Id of the record </param>
        /// <param name="SecondId"> Id of the other record </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A record correspondig to that id </returns>
        Task<Response<TReturnType>> GetRecordCompositeKeysTable(Guid FirstId, Guid SecondId, CancellationToken cancellationToken);
    }
}