using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Queries.Subject.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Subject.QueriesHandler
{
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, ObjectResult>
    {
        private readonly ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> _subjectService;
        private readonly IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> _statusCodeResponse;

        public GetSubjectByIdQueryHandler
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
            GetSubjectByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var subjects = await _subjectService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(subjects);
        }
    }
}