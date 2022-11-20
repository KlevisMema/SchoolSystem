using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Queries.Subject.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Subject.CommandHandler
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, ObjectResult>
    {
        private readonly ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> _subjectService;
        private readonly IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> _statusCodeResponse;

        public UpdateSubjectCommandHandler
        (
            ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> subjectService,
            IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> statusCodeResponse
        )
        {
            _subjectService = subjectService;
            _statusCodeResponse = statusCodeResponse;
        }

        public async Task<ObjectResult> Handle
        (
            UpdateSubjectCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedSubject = await _subjectService.PutRecord(request.Id, request.CreateUpdateSubjectViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedSubject);
        }
    }
}