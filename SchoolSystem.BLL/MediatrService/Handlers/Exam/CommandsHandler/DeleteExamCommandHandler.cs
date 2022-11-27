using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Exam.CommandsHandler
{
    internal class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, ObjectResult>
    {
        private readonly ICrudService<ExamViewModel, CreateUpdateExamViewModel> _examService;
        private readonly IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> _statusCodeResponse;

        public DeleteExamCommandHandler
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
            DeleteExamCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteExam = await _examService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteExam);
        }
    }
}