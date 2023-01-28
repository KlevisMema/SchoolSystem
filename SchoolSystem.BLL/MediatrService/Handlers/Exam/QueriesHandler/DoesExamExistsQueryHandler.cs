#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Exam.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Exam.QueriesHandler
{
    /// <summary>
    ///     Does exam exists query handler class which implements IRequestHandler which gets the Does Exam Exists Query and CustomMesageResponse as response.
    /// </summary>
    public class DoesExamExistsQueryHandler : IRequestHandler<DoesExamExistsQuery, CustomMesageResponse>
    {
        /// <summary>
        ///     I_Valid_Id interface 
        /// </summary>
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Exam> _Exam_Valid_Id;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="exam_Valid_Id"> Valid id service  </param>
        public DoesExamExistsQueryHandler
        (
            I_Valid_Id<DAL.Models.Exam> exam_Valid_Id
        )
        {
            _Exam_Valid_Id = exam_Valid_Id;
        }

        /// <summary>
        ///     Handle the does exam exists command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<CustomMesageResponse> Handle
        (
            DoesExamExistsQuery request,
            CancellationToken cancellationToken
        )
        {
            var exam = await _Exam_Valid_Id.Bool(request.Id, cancellationToken);

            if (exam)
                return CustomMesageResponse.Succsess();

            return CustomMesageResponse.NotFound(exam, "Invalid exam id");
        }
    }
}