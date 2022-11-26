using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.TimeTable;

namespace SchoolSystem.BLL.MediatrService.Actions.TimeTable.Commands
{
    public class UpdateTimeTableCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateTimeTableViewModel _updateTimeTable { get; set; }

        public UpdateTimeTableCommand
        (
            Guid id,
            CreateUpdateTimeTableViewModel updateTimeTable
        )
        {
            Id = id;
            _updateTimeTable = updateTimeTable;
        }
    }
}