using AutoMapper;
using SchoolSystem.DAL.DataBase;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.ResponseService;


namespace SchoolSystem.BLL.RepositoryService.CrudService
{
    public class CRUD
    <
        ReturnType,
        ModelType,
        PostUpdateModelType
    >
        where ModelType : class
        where ReturnType : class
        where PostUpdateModelType : class
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CRUD<ReturnType, ModelType, PostUpdateModelType>> _logger;

        public CRUD
        (
            IMapper mapper,
            ApplicationDbContext context,
            ILogger<CRUD<ReturnType, ModelType, PostUpdateModelType>> logger
        )
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get all records from an entity in database.
        /// </summary>
        /// <returns>A list of records</returns>
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

        /// <summary>
        /// Get a specific record from an entity in database.
        /// </summary>
        /// <param name="id">Id of the that entity </param>
        /// <param name="customMessage">Custom message for the response </param>
        /// <returns>A record correspondig to that id</returns>
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

        /// <summary>
        /// Create a record of an entity
        /// </summary>
        /// <param name="record">Object type with records</param>
        /// <param name="customMessage">Custom message for the response</param>
        /// <returns>A string message if record was created or not</returns>
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

        /// <summary>
        /// Upadate a record of an Entity 
        /// </summary>
        /// <param name="id">Id of that entity</param>
        /// <param name="recordFromClient">Object type with records</param>
        /// <param name="customMessage">Custom message for response </param>
        /// <returns>The updated record</returns>
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

        /// <summary>
        /// Delete a record from database
        /// </summary>
        /// <param name="id">Id of the entity to be deleted</param>
        /// <param name="customMessage">Custom message for response message</param>
        /// <returns>A message if the record was deleted or not </returns>
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
    }
}