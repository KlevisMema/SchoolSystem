using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.TimeTable;

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands
{
    public class CreateTimeTableCommand : IRequest<ObjectResult>
    {
        public CreateUpdateTimeTableViewModel _createTimeTable { get; set; }

        public CreateTimeTableCommand
        (
            CreateUpdateTimeTableViewModel createTimeTable
        )
        {
            _createTimeTable = createTimeTable;
        }
    }
}