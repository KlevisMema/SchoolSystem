using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Issues.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Issues.QueriesHandler
{
    public class DoesIssueExistsQueryHandler : IRequestHandler<DoesIssueExistsQuery, CustomMesageResponse>
    {
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Issue> _Issue_Valid_Id;

        public DoesIssueExistsQueryHandler
        (
            I_Valid_Id<DAL.Models.Issue> issue_Valid_Id
        )
        {
            _Issue_Valid_Id = issue_Valid_Id;
        }

        public async Task<CustomMesageResponse> Handle
        (
            DoesIssueExistsQuery request, 
            CancellationToken cancellationToken
        )
        {
            var issue = await _Issue_Valid_Id.Bool(request.Id, cancellationToken);

            if (issue)
                return CustomMesageResponse.Succsess();

            return CustomMesageResponse.NotFound(issue, "Invalid exam id");
        }
    }
}