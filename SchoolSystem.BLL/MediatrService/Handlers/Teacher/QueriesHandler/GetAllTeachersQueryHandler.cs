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
    ///     Get teachers query handler class which implements IRequestHandler which gets the get teachers query and object result as response 
    /// </summary>
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, ObjectResult>
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
        public GetAllTeachersQueryHandler
        (
            ICrudService<TeacherViewModel, CreateUpdateTeacherViewModel> teacherService,
            IControllerStatusCodeResponse<TeacherViewModel, List<TeacherViewModel>> statusCodeResponse
        )
        {
            _teacherService = teacherService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get teachers query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetAllTeachersQuery request,
            CancellationToken cancellationToken
        )
        {
            var teachers = await _teacherService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(teachers);
        }
    }
}