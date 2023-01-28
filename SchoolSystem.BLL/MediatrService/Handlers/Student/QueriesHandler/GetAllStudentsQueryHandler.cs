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
    ///     Get students query handler class which implements IRequestHandler which gets the get students query and object result as response 
    /// </summary>
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, ObjectResult>
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
        public GetAllStudentsQueryHandler
        (
            ICrudService<StudentViewModel, CreateUpdateStudentViewModel> studentService,
            IControllerStatusCodeResponse<StudentViewModel, List<StudentViewModel>> statusCodeResponse
        )
        {
            _studentService = studentService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get students query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(students);
        }
    }
}