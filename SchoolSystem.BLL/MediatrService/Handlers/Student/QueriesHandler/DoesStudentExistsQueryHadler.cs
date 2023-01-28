#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Student.QueriesHandler
{
    /// <summary>
    ///     Does student exists query handler class which implements IRequestHandler which gets the Does Student Exists Query and CustomMesageResponse as response.
    /// </summary>
    public class DoesStudentExistsQueryHadler : IRequestHandler<DoesStudentExistsQuery, CustomMesageResponse>
    {
        /// <summary>
        ///     I_Valid_Id interface 
        /// </summary>
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Student> _Student_Valid_Id;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="student_Valid_Id"> Valid id service  </param>
        public DoesStudentExistsQueryHadler
        (
            I_Valid_Id<DAL.Models.Student> student_Valid_Id
        )
        {
            _Student_Valid_Id = student_Valid_Id;
        }

        /// <summary>
        ///     Handle the does student exists command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<CustomMesageResponse> Handle
        (
            DoesStudentExistsQuery request,
            CancellationToken cancellationToken
        )
        {
            var student = await _Student_Valid_Id.Bool(request.StudentId, cancellationToken);

            if (student)
                return CustomMesageResponse.Succsess();

            return CustomMesageResponse.NotFound(student, "invalid student id !");
        }
    }
}