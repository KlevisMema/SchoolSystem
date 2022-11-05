using AutoMapper;
using SchoolSystem.DAL.DataBase;
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
        where ModelType           : class
        where ReturnType          : class
        where PostUpdateModelType : class
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public CRUD
        (
            ApplicationDbContext context, 
            IMapper mapper
        )
        {
            _mapper = mapper;
            _context = context;
        }

        // Get all records from an entity in database.
        public async Task<Response<List<ReturnType>>> GetAll
        (
        )
        {
            try
            {
                List<ModelType> recordsFromDb = await _context.Set<ModelType>().ToListAsync();

                List<ReturnType> trasfromObjectToReturnType = _mapper.Map<List<ReturnType>>(recordsFromDb);

                return Response<List<ReturnType>>.Ok(trasfromObjectToReturnType);
            }
            catch (Exception)
            {
                return Response<List<ReturnType>>.ErrorMsg("Server error, try again !!");
            }
        }

        // Get a specific record from an entity in database.
        public async Task<Response<ReturnType>> GetSpecificRecord
        (
            Guid id, 
            string customMessage
        )
        {
            try
            {
                ModelType recordFromDb = await _context.Set<ModelType>().FindAsync(id);

                ArgumentNullException.ThrowIfNull(recordFromDb);

                ReturnType transformObjectToReturnType = _mapper.Map<ReturnType>(recordFromDb);

                return Response<ReturnType>.Ok(transformObjectToReturnType);
            }
            catch (ArgumentNullException)
            {
                return Response<ReturnType>.NotFound($"{customMessage} doesn't exists");
            }
            catch (Exception)
            {
                return Response<ReturnType>.ErrorMsg("Server error, try again !!");
            }
        }

        // Create a record of an entity
        public async Task<Response<ReturnType>> PostRecord
        (
            PostUpdateModelType record, 
            string customMessage
        )
        {
            try
            {
                ModelType transformObjectToModelType = _mapper.Map<ModelType>(record);

                _context.Set<ModelType>().Add(transformObjectToModelType);

                Console.WriteLine(transformObjectToModelType);

                await _context.SaveChangesAsync();

                return Response<ReturnType>.SuccessMessage($"{customMessage} created succsessuflly");
            }
            catch (Exception)
            {
                return Response<ReturnType>.ErrorMsg($"Server error, {customMessage.ToLower()} wasn't created succsessuflly try again!!");
            }
        }

        // Upadate a record of an Entity 
        public async Task<Response<ReturnType>> PutRecord
        (
            Guid id, 
            PostUpdateModelType recordFromClient, 
            string customMessage
        )
        {
            try
            {
                ModelType _recordFromDb = await _context.Set<ModelType>().FindAsync(id);

                ArgumentNullException.ThrowIfNull(_recordFromDb);

                _context.Entry(_recordFromDb).CurrentValues.SetValues(recordFromClient);

                await _context.SaveChangesAsync();

                return await GetSpecificRecord(id, string.Empty);
            }
            catch (ArgumentNullException)
            {
                return Response<ReturnType>.NotFound($"{customMessage} doesnt exists");
            }
            catch (Exception)
            {
                return Response<ReturnType>.ErrorMsg("Server error, couldn't update record, try again!!");
            }
        }

        // Delete a record of an Entity 
        public async Task<Response<ReturnType>> DeleteRecord
        (
            Guid id, 
            string customMessage
        )
        {
            try
            {
                ModelType record = await _context.Set<ModelType>().FindAsync(id);

                ArgumentNullException.ThrowIfNull(record);

                _context.Set<ModelType>().Remove(record);

                await _context.SaveChangesAsync();

                return Response<ReturnType>.SuccessMessage($"{customMessage} deleted successfully...");
            }
            catch (ArgumentNullException)
            {
                return Response<ReturnType>.NotFound($"{customMessage} doesn't exists!");
            }
            catch (Exception)
            {
                return Response<ReturnType>.ErrorMsg("Server error, could't delete try again!");
            }
        }
    }
}