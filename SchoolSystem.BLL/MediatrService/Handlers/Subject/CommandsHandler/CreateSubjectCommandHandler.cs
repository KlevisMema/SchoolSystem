﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Subject;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Queries.Subject.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.Subject.CommandHandler
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, ObjectResult>
    {
        private readonly ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> _subjectService;
        private readonly IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> _statusCodeResponse;

        public CreateSubjectCommandHandler
        (
            ICrudService<SubjectViewModel, CreateUpdateSubjectViewModel> subjectService,
            IControllerStatusCodeResponse<SubjectViewModel, List<SubjectViewModel>> statusCodeResponse
        )
        {
            _subjectService = subjectService;
            _statusCodeResponse = statusCodeResponse;
        }

        public async Task<ObjectResult> Handle
        (
            CreateSubjectCommand request, 
            CancellationToken cancellationToken
        )
        {
            var createSubject = await _subjectService.PostRecord(request._createUpdateSubjectViewModel, cancellationToken);
            return _statusCodeResponse.ControllerResponse(createSubject);
        }
    }
}