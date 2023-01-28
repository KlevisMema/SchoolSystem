#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries; 

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Teacher.QueriesHandler
{
    /// <summary>
    ///     Does teacher exists query handler class which implements IRequestHandler which gets the Does Clasroom Exists Query and CustomMesageResponse as response.
    /// </summary>
    public class DoesTeacherExistsQueryHandler : IRequestHandler<DoesTeacherExistsQuery, CustomMesageResponse>
    {
        /// <summary>
        ///     I_Valid_Id interface 
        /// </summary>
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Teacher> _Teacher_Valid_Id;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="teacher_Valid_Id"> Valid id service  </param>
        public DoesTeacherExistsQueryHandler
        (
            I_Valid_Id<DAL.Models.Teacher> teacher_Valid_Id
        )
        {
            _Teacher_Valid_Id = teacher_Valid_Id;
        }

        /// <summary>
        ///     Handle the does teacher exists command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<CustomMesageResponse> Handle
        (
            DoesTeacherExistsQuery request, 
            CancellationToken cancellationToken
        )
        {
            var teacher = await _Teacher_Valid_Id.Bool(request.TeacherId, cancellationToken);

            if (teacher)
                return CustomMesageResponse.Succsess();

            return CustomMesageResponse.NotFound(teacher, "Invalid teacher id");
        }
    }
}