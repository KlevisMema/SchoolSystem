#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Student;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Student.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Student.QueriesHandler
{
    /// <summary>
    ///     Get student query handler class which implements IRequestHandler which gets the get student query and object result as response 
    /// </summary>
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<StudentViewModel, CreateUpdateStudentViewModel> _studentService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="studentService"> Student service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public GetStudentByIdQueryHandler
        (
            ICrudService<StudentViewModel, CreateUpdateStudentViewModel> studentService,
            IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentService = studentService;
        }

        /// <summary>
        ///     Handle the get student by id query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(student);
        }
    }
}