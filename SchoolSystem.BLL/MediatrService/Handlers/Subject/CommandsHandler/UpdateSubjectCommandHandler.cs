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
    ///     Update subject command handler class which implements IRequestHandler which gets the get update subject command and object result as response 
    /// </summary>
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, ObjectResult>
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
        public UpdateSubjectCommandHandler
        (
            ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> subjectService,
            IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> statusCodeResponse
        )
        {
            _subjectService = subjectService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the update subject command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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