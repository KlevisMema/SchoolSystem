﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.StudentIssues;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.StudentIssue.Commands;

namespace SchoolSystem.BLL.MediatrService.Handlers.StudentIssue.CommandsHandler
{
    public class UpdateStudentIssueCommandHandler : IRequestHandler<UpdateStudentIssueCommand, ObjectResult>
    {
        private readonly ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> _studentIssueService;
        private readonly IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> _statusCodeResponse;

        public UpdateStudentIssueCommandHandler
        (
            ICrudService<StudentIssueViewModel, CreateUpdateStudentIssueViewModel> studentIssueService,
            IControllerStatusCodeResponse<StudentIssueViewModel, List<StudentIssueViewModel>> statusCodeResponse
        )
        {
            _statusCodeResponse = statusCodeResponse;
            _studentIssueService = studentIssueService;
        }

        public async Task<ObjectResult> Handle
        (
            UpdateStudentIssueCommand request, 
            CancellationToken cancellationToken
        )
        {
            var updatedStudentIssue = await _studentIssueService.PutRecord(request.Id, request._updateStudentIssue, cancellationToken);
            return _statusCodeResponse.ControllerResponse(updatedStudentIssue);
        }
    }
}