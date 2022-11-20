using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Queries.Subject.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Subject.CommandHandler
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, ObjectResult>
    {
        private readonly ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> _subjectService;
        private readonly IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> _statusCodeResponse;

        public DeleteSubjectCommandHandler
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
            DeleteSubjectCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteSubject = await _subjectService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteSubject);
        }
    }
}