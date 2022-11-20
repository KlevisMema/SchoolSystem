using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Subject;

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Commands
{
    public class UpdateSubjectCommand : IRequest<ObjectResult>
    {
        public CreateUpdateSubjectViewModel CreateUpdateSubjectViewModel;
        public Guid Id { get; set; }

        public UpdateSubjectCommand
        (
            CreateUpdateSubjectViewModel createUpdateSubjectViewModel,
            Guid id
        )
        {
            CreateUpdateSubjectViewModel = createUpdateSubjectViewModel;
            Id = id;
        }
    }
}