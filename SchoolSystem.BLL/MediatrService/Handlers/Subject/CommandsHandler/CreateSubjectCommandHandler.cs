#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Queries.Subject.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Subject.CommandHandler
{
    /// <summary>
    ///     Create subject command handler class which implements IRequestHandler which gets the get create subject command and object result as response 
    /// </summary>
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> _subjectService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="subjectService"> Subject service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public CreateSubjectCommandHandler
        (
            ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> subjectService,
            IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> statusCodeResponse
        )
        {
            _subjectService = subjectService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the create subject command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            CreateSubjectCommand request,
            CancellationToken cancellationToken
        )
        {
            var createSubject = await _subjectService.PostRecord(request._createUpdateSubjectViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createSubject);
        }
    }
}