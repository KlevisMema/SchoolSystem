#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Commands;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Exam.CommandsHandler
{
    /// <summary>
    ///     Delete exam command handler class which implements IRequestHandler which gets the get delete exam command and object result as response 
    /// </summary>
    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, ObjectResult>
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
        public DeleteExamCommandHandler
        (
            ICrudService<ExamViewModel, CreateUpdateExamViewModel> examService,
            IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> statusCodeResponse
        )
        {
            _examService = examService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the delete exam command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            DeleteExamCommand request,
            CancellationToken cancellationToken
        )
        {
            var deleteExam = await _examService.DeleteRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(deleteExam);
        }
    }
}