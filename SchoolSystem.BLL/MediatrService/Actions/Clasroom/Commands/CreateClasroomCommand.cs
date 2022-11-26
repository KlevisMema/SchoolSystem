using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Clasroom;

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands
{
    public class CreateClasroomCommand : IRequest<ObjectResult>
    {
        public CreateUpdateClasroomViewModel _createClasroom { get; set; }

        public CreateClasroomCommand
        (
            CreateUpdateClasroomViewModel createClasroom
        )
        {
            _createClasroom = createClasroom;
        }
    }
}