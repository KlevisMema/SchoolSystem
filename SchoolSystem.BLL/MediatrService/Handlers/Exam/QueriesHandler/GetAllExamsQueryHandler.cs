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
    ///     Get exams query handler class which implements IRequestHandler which gets the get exams query and object result as response 
    /// </summary>
    public class GetAllExamsQueryHandler : IRequestHandler<GetAllExamsQuery, ObjectResult>
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
        public GetAllExamsQueryHandler
        (
            ICrudService<ExamViewModel, CreateUpdateExamViewModel> examService,
            IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> statusCodeResponse
        )
        {
            _examService = examService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get exams by
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetAllExamsQuery request,
            CancellationToken cancellationToken
        )
        {
            var exams = await _examService.GetRecords(cancellationToken);
            return _statusCodeResponse.ControllerResponse(exams);
        }
    }
}