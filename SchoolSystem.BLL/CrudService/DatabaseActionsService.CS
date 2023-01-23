#region Usings

using AutoMapper;
using SchoolSystem.DAL.DataBase;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.ResponseService;

#endregion

namespace SchoolSystem.BLL.RepositoryService.CrudService
{
    public class DatabaseActionsService
    <
        ReturnType,
        ModelType,
        PostUpdateModelType
    >
        where ModelType : class
        where ReturnType : class
        where PostUpdateModelType : class
    {
        #region Inject services

        /// <summary>
        ///     Mapper interface
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        ///     Database context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        ///     Logger 
        /// </summary>
        private readonly ILogger<DatabaseActionsService<ReturnType, ModelType, PostUpdateModelType>> _logger;

        /// <summary>
        ///     Inject services in controller
        /// </summary>
        /// <param name="mapper"> Mapper service </param>
        /// <param name="context"> Database service </param>
        /// <param name="logger"> Logger service </param>
        public DatabaseActionsService
        (
            IMapper mapper,
            ApplicationDbContext context,
            ILogger<DatabaseActionsService<ReturnType, ModelType, PostUpdateModelType>> logger
        )
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        #endregion

        #region Get all records from a table

        /// <summary>
        ///     Get all records from an entity in database.
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A list of records </returns>

        public async Task<Response<List<ReturnType>>> GetAll
        (
            CancellationToken cancellationToken
        )
        {
            try
            {
                List<ModelType> recordsFromDb = await _context.Set<ModelType>().ToListAsync(cancellationToken);

                List<ReturnType> trasfromObjectToReturnType = _mapper.Map<List<ReturnType>>(recordsFromDb);

                return Response<List<ReturnType>>.Ok(trasfromObjectToReturnType);
            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                    ex,
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );
                return Response<List<ReturnType>>.ErrorMsg("Server error, try again later !!");
            }
        }

        #endregion

        #region Get a specific record from a table

        /// <summary>
        ///     Get a specific record from an entity in database.
        /// </summary>
        /// <param name="id"> Id of the that entity </param>
        /// <param name="customMessage"> Custom message for the response </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A record correspondig to that id </returns>
         
        public async Task<Response<ReturnType>> GetSpecificRecord
        (
            Guid id,
            string customMessage,
            CancellationToken cancellationToken
        )
        {
            try
            {
                ModelType recordFromDb = await _context.Set<ModelType>().FindAsync(id, cancellationToken);

                ArgumentNullException.ThrowIfNull(recordFromDb);

                ReturnType transformObjectToReturnType = _mapper.Map<ReturnType>(recordFromDb);

                return Response<ReturnType>.Ok(transformObjectToReturnType);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, $"Argument null exeption {typeof(ModelType)} || {ex.ParamName} ||");

                return Response<ReturnType>.NotFound($"{customMessage} doesn't exists");
            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                    ex,
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );
                return Response<ReturnType>.ErrorMsg("Server error, try again later !!");
            }
        }

        #endregion

        #region Create a new record in a specific table

        /// <summary>
        ///     Create a record of an entity
        /// </summary>
        /// <param name="record"> Object type with records </param>
        /// <param name="customMessage"> Custom message for the response </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A string message if record was created or not </returns>
         
        public async Task<Response<ReturnType>> PostRecord
        (
            PostUpdateModelType record,
            string customMessage,
            CancellationToken cancellationToken
        )
        {
            try
            {
                ModelType transformObjectToModelType = _mapper.Map<ModelType>(record);

                _context.Set<ModelType>().Add(transformObjectToModelType);

                Console.WriteLine(transformObjectToModelType);

                await _context.SaveChangesAsync(cancellationToken);

                return Response<ReturnType>.SuccessMessage($"{customMessage} created succsessuflly");
            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                    ex,
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );
                return Response<ReturnType>.ErrorMsg($"Server error, {customMessage.ToLower()} wasn't created succsessuflly try again!!");
            }
        }

        #endregion

        #region Update an existing record from a specific table 

        /// <summary>
        ///     Upadate a record of an Entity 
        /// </summary>
        /// <param name="id">Id of that entity</param>
        /// <param name="recordFromClient"> Object type with records </param>
        /// <param name="customMessage"> Custom message for response </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> The updated record </returns>
         
        public async Task<Response<ReturnType>> PutRecord
        (
            Guid id,
            PostUpdateModelType recordFromClient,
            string customMessage,
            CancellationToken cancellationToken
        )
        {
            try
            {
                ModelType _recordFromDb = await _context.Set<ModelType>().FindAsync(id, cancellationToken);

                ArgumentNullException.ThrowIfNull(_recordFromDb);

                _context.Entry(_recordFromDb).CurrentValues.SetValues(recordFromClient);

                await _context.SaveChangesAsync(cancellationToken);

                return await GetSpecificRecord(id, string.Empty, cancellationToken);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, $"Argument null exeption {typeof(ModelType)} || {ex.ParamName}");

                return Response<ReturnType>.NotFound($"{customMessage} doesnt exists");
            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                    ex,
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );
                return Response<ReturnType>.ErrorMsg("Server error, couldn't update record, try again!!");
            }
        }

        #endregion

        #region Delete a record form a specific table

        /// <summary>
        ///     Delete a record from database
        /// </summary>
        /// <param name="id"> Id of the entity to be deleted </param>
        /// <param name="customMessage"> Custom message for response message </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A message if the record was deleted or not </returns>
         
        public async Task<Response<ReturnType>> DeleteRecord
        (
            Guid id,
            string customMessage,
            CancellationToken cancellationToken
        )
        {
            try
            {
                ModelType record = await _context.Set<ModelType>().FindAsync(id, cancellationToken);

                ArgumentNullException.ThrowIfNull(record);

                _context.Set<ModelType>().Remove(record);

                await _context.SaveChangesAsync(cancellationToken);

                return Response<ReturnType>.SuccessMessage($"{customMessage} deleted successfully...");
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, $"Argument null exeption {typeof(ModelType)} || {ex.ParamName}");

                return Response<ReturnType>.NotFound($"{customMessage} doesn't exists!");
            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                    ex,
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );
                return Response<ReturnType>.ErrorMsg("Server error, could't delete try again!");
            }
        }

        #endregion

        #region Get a specific record from a specific table which is a composite key table

        /// <summary>
        ///     Get a specific record from an entity in database of a composite key table.
        /// </summary>
        /// <param name="id"> Id of the that entity </param>
        /// <param name="customMessage"> Custom message for the response </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A record correspondig to that id </returns>
         
        public async Task<Response<ReturnType>> GetSpecificRecordCompostieKeyTable
        (
            Guid FirstId,
            Guid SecondId,
            string customMessage,
            CancellationToken cancellationToken
        )
        {
            try
            {
                ModelType recordFromDb = await _context.Set<ModelType>().FindAsync(FirstId, SecondId, cancellationToken);

                ArgumentNullException.ThrowIfNull(recordFromDb);

                ReturnType transformObjectToReturnType = _mapper.Map<ReturnType>(recordFromDb);

                return Response<ReturnType>.Ok(transformObjectToReturnType);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, $"Argument null exeption {typeof(ModelType)} || {ex.ParamName} ||");

                return Response<ReturnType>.NotFound($"{customMessage} doesn't exists");
            }
            catch (Exception ex)
            {
                _logger.LogError
                (
                    ex,
                    $"Error, something went wrong !! => \n " +
                    $" Method : {ex.TargetSite} \n" +
                    $" Source : {ex.Source} \n" +
                    $"InnerEx : {ex.InnerException} \n"
                );
                return Response<ReturnType>.ErrorMsg("Server error, try again later !!");
            }
        }

        #endregion
    }
}