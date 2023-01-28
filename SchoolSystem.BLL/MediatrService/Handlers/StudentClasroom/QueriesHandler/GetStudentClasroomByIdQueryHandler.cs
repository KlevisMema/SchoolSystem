#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentClasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentClasroom.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentClasroom.QueriesHandler
{
    /// <summary>
    ///     Get student clasroom query handler class which implements IRequestHandler which gets the get student clasroom query and object result as response 
    /// </summary>
    public class GetStudentClasroomByIdQueryHandler : IRequestHandler<GetStudentClasroomByIdQuery, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> _studentClasroomService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="studentClasroomService"> Student Clasroom service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public GetStudentClasroomByIdQueryHandler
        (
            ICrudService<StudentClasroomViewModel, CreateUpdateStudentClasroomViewModel> studentClasroomService,
            IControllerStatusCodeResponse<StudentClasroomViewModel, List<StudentClasroomViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentClasroomService = studentClasroomService;
        }

        /// <summary>
        ///     Handle the get student clasroom by id query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetStudentClasroomByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var studentClasroom = await _studentClasroomService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(studentClasroom);
        }
    }
}