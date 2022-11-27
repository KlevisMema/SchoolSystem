using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Exam.QueriesHandler
{
    public class DoesExamExistsQueryHandler : IRequestHandler<DoesExamExistsQuery, CustomMesageResponse>
    {
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Exam> _Exam_Valid_Id;

        public DoesExamExistsQueryHandler
        (
            I_Valid_Id<DAL.Models.Exam> exam_Valid_Id
        )
        {
            _Exam_Valid_Id = exam_Valid_Id;
        }
        public async Task<CustomMesageResponse> Handle
        (
            DoesExamExistsQuery request,
            CancellationToken cancellationToken
        )
        {
            var exam = await _Exam_Valid_Id.Bool(request.Id, cancellationToken);

            if (exam)
                return CustomMesageResponse.Succsess();

            return CustomMesageResponse.NotFound(exam, "Invalid exam id");
        }
    }
}