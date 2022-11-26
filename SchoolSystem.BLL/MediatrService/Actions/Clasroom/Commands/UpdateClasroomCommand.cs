using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Clasroom;

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Commands
{
    public class UpdateClasroomCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateClasroomViewModel _updateClasroom { get; set; }

        public UpdateClasroomCommand
        (
            Guid id,
            CreateUpdateClasroomViewModel updateClasroom
        )
        {
            Id = id;
            _updateClasroom = updateClasroom;
        }
    }
}