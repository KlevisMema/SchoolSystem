using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Student.QueriesHandler
{
    public class DoesStudentExistsQueryHadler : IRequestHandler<DoesStudentExistsQuery, CustomMesageResponse>
    {
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Student> _Student_Valid_Id;

        public DoesStudentExistsQueryHadler
        (
            I_Valid_Id<DAL.Models.Student> student_Valid_Id
        )
        {
            _Student_Valid_Id = student_Valid_Id;
        }

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