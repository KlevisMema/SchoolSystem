#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Querys;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Exam.QueriesHandler
{
    /// <summary>
    ///     Get exam query handler class which implements IRequestHandler which gets the get exam query and object result as response 
    /// </summary>
    public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, ObjectResult>
    {
        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<ExamViewModel, CreateUpdateExamViewModel> _examService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="examService"> Exam service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public GetExamByIdQueryHandler
        (
            ICrudService<ExamViewModel, CreateUpdateExamViewModel> examService,
            IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> statusCodeResponse
        )
        {
            _examService = examService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get exam by id query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetExamByIdQuery request, CancellationToken cancellationToken
        )
        {
            var exam = await _examService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(exam);
        }
    }
}