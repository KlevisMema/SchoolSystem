using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Exam.CommandsHandler
{
    internal class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, ObjectResult>
    {
        private readonly ICrudService<ExamViewModel, CreateUpdateExamViewModel> _examService;
        private readonly IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> _statusCodeResponse;

        public UpdateExamCommandHandler
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
            UpdateExamCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedExam = await _examService.PutRecord(request.Id, request._updateExam, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedExam);
        }
    }
}