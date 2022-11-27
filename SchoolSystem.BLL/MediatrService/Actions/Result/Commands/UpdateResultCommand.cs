using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Result;

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Commands
{
    public class UpdateResultCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateResultViewModel _updateResult { get; set; }

        public UpdateResultCommand
        (
            Guid id,
            CreateUpdateResultViewModel updateResult
        )
        {
            Id = id;
            _updateResult = updateResult;
        }
    }
}