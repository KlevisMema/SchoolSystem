using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Subject;

namespace SchoolSystem.BLL.MediatrService.Queries.Subject.Commands
{
    public class CreateSubjectCommand : IRequest<ObjectResult>
    {
        public CreateUpdateSubjectViewModel _createUpdateSubjectViewModel;

        public CreateSubjectCommand(CreateUpdateSubjectViewModel createUpdateSubjectViewModel)
        {
            _createUpdateSubjectViewModel = createUpdateSubjectViewModel;
        }
    }
}