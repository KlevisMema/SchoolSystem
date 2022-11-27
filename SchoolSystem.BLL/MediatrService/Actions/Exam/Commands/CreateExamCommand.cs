using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Commands
{
    public class CreateExamCommand : IRequest<ObjectResult>
    {
        public CreateUpdateExamViewModel _createExam { get; set; }

        public CreateExamCommand
        (
            CreateUpdateExamViewModel createExam
        )
        {
            _createExam = createExam;
        }
    }
}