using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Teacher.QueriesHandler
{
    public class DoesTeacherExistsQueryHandler : IRequestHandler<DoesTeacherExistsQuery, CustomMesageResponse>
    {
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Teacher> _Teacher_Valid_Id;

        public DoesTeacherExistsQueryHandler
        (
            I_Valid_Id<DAL.Models.Teacher> teacher_Valid_Id
        )
        {
            _Teacher_Valid_Id = teacher_Valid_Id;
        }

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