using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.RepositoryServiceInterfaces
{
    /// <summary>
    ///     Generic interface for create, read, update and delete
    /// </summary>
    /// <typeparam name="TReturnType"> The return type you want to return </typeparam>
    /// <typeparam name="TInputType"> Input type  </typeparam>
    public interface ICrudService
    <
        TReturnType,
        TInputType
    >
    where TReturnType : class
    where TInputType : class
    {
        /// <summary>
        ///     Get all records from an entity
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of object of that entity </returns>
        Task<Response<List<TReturnType>>> GetRecords(CancellationToken cancellationToken);
        /// <summary>
        ///     Get a single record by id of a type entity
        /// </summary>
        /// <param name="id"> Id record of that entity </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The record corresponding to that id </returns>
        Task<Response<TReturnType>> GetRecord(Guid id, CancellationToken cancellationToken);
        /// <summary>
        ///     Delete an existing record from the database by id of a type entity
        /// </summary>
        /// <param name="id"> Id record of that entity </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A message if operation was completed succsessfully or not </returns>
        Task<Response<TReturnType>> DeleteRecord(Guid id, CancellationToken cancellationToken);
        /// <summary>
        ///     Create a record in the database for a type entity
        /// </summary>
        /// <param name="viewModel"> The view model from input </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The created record </returns>
        Task<Response<TReturnType>> PostRecord(TInputType viewModel, CancellationToken cancellationToken);
        /// <summary>
        ///     Update an existing record form the databse for a type entity
        /// </summary>
        /// <param name="id"> Id record of that type entity</param>
        /// <param name="viewModel"> The view model input </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated record </returns>
        Task<Response<TReturnType>> PutRecord(Guid id, TInputType viewModel, CancellationToken cancellationToken);
    }
}