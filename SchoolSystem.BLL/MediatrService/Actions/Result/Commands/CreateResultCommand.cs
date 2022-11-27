using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Result;

namespace SchoolSystem.BLL.MediatrService.Actions.Result.Commands
{
    public class CreateResultCommand : IRequest<ObjectResult>
    {
        public CreateUpdateResultViewModel _createResult { get; set; }

        public CreateResultCommand
        (
            CreateUpdateResultViewModel createResult
        )
        {
            _createResult = createResult;
        }
    }
}