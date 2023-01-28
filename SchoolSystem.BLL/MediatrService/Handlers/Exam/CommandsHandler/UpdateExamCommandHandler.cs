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
    ///     Update exam command handler class which implements IRequestHandler which gets the get update exam command and object result as response 
    /// </summary>
    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, ObjectResult>
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
        public UpdateExamCommandHandler
        (
            ICrudService<ExamViewModel, CreateUpdateExamViewModel> examService,
            IControllerStatusCodeResponse<ExamViewModel, List<ExamViewModel>> statusCodeResponse
        )
        {
            _examService = examService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the update exam command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            UpdateExamCommand request,
            CancellationToken cancellationToken
        )
        {
            var updatedExam = await _examService.PutRecord(request.Id, request._updateExam, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedExam);
        }
    }
}