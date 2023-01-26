#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Teacher;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Teacher.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Teacher.QueriesHandler
{
    /// <summary>
    ///     Get teacher query handler class which implements IRequestHandler which gets the get teacher query and object result as response 
    /// </summary>
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> _teacherService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="teacherService"> Teacher service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public GetTeacherByIdQueryHandler
        (
            ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> teacherService,
            IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> statusCodeResponse
        )
        {
            _teacherService = teacherService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get teacher by id query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(teacher);
        }
    }
}
