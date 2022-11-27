using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Querys;

namespace SchoolSystem.BLL.MediatrService.Handlers.Exam.QueriesHandler
{
    public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, ObjectResult>
    {
        private readonly ICrudService<ExamViewModel, CreateUpdateExamViewModel> _examService;
        private readonly IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> _statusCodeResponse;

        public GetExamByIdQueryHandler
        (
            ICrudService<ExamViewModel, CreateUpdateExamViewModel> examService,
            IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> statusCodeResponse
        )
        {
            _examService = examService;
            _statusCodeResponse = statusCodeResponse;
        }

        public async Task<ObjectResult> Handle
        (
            GetExamByIdQuery request, CancellationToken cancellationToken
        )
        {
            var exam = await _examService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(exam);
        }
    }
}