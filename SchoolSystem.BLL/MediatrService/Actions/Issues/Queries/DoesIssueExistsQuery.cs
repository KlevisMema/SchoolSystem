using MediatR;
using SchoolSystem.BLL.ResponseService;

namespace SchoolSystem.BLL.MediatrService.Actions.Issues.Queries
{
    public class DoesIssueExistsQuery : IRequest<CustomMesageResponse>
    {
        public Guid Id { get; set; }

        public DoesIssueExistsQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}