#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Queries.Subject.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Subject.QueriesHandler
{
    /// <summary>
    ///     Get subject query handler class which implements IRequestHandler which gets the get subject query and object result as response 
    /// </summary>
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, ObjectResult>
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
        public GetSubjectByIdQueryHandler
        (
            ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> subjectService,
            IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> statusCodeResponse
        )
        {
            _subjectService = subjectService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get subject by id query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
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