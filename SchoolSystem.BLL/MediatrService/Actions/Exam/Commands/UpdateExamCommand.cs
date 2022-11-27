using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DTO.ViewModels.Exam;

namespace SchoolSystem.BLL.MediatrService.Actions.Exam.Commands
{
    public class UpdateExamCommand : IRequest<ObjectResult>
    {
        public Guid Id { get; set; }
        public CreateUpdateExamViewModel _updateExam { get; set; }

        public UpdateExamCommand
        (
            Guid id,
            CreateUpdateExamViewModel updateExam
        )
        {
            Id = id;
            _updateExam = updateExam;
        }
    }
}