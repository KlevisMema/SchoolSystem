#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Issues.QueriesHandler
{

    /// <summary>
    ///     Does issue exists query handler class which implements IRequestHandler which gets the Does Issue Exists Query and CustomMesageResponse as response.
    /// </summary>
    public class DoesIssueExistsQueryHandler : IRequestHandler<DoesIssueExistsQuery, CustomMesageResponse>
    {
        /// <summary>
        ///     I_Valid_Id interface 
        /// </summary>
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Issue> _Issue_Valid_Id;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="issue_Valid_Id"> Valid id service  </param>
        public DoesIssueExistsQueryHandler
        (
            I_Valid_Id<DAL.Models.Issue> issue_Valid_Id
        )
        {
            _Issue_Valid_Id = issue_Valid_Id;
        }

        /// <summary>
        ///     Handle the does issue exists command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<CustomMesageResponse> Handle
        (
            DoesIssueExistsQuery request,
            CancellationToken cancellationToken
        )
        {
            var issue = await _Issue_Valid_Id.Bool(request.Id, cancellationToken);

            if (issue)
                return CustomMesageResponse.Succsess();

            return CustomMesageResponse.NotFound(issue, "Invalid issue id");
        }
    }
}