using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Exam.CommandsHandler
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, ObjectResult>
    {
        private readonly ICrudService<ExamViewModel, CreateUpdateExamViewModel> _examService;
        private readonly IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> _statusCodeResponse;

        public CreateExamCommandHandler
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
            CreateExamCommand request,
            CancellationToken cancellationToken
        )
        {
            var createStudent = await _examService.PostRecord(request._createExam, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createStudent);
        }
    }
}