﻿using SchoolSystem.BLL.ResponseService;
using SchoolSystem.DTO.ViewModels;

namespace SchoolSystem.BLL.RepositoryServiceInterfaces
{
    public interface IStudentService
    {
        Task<Response<List<StudentViewModel>>> GetStudets();
        Task<Response<StudentViewModel>> GetSpecificStudent(Guid id);
        Task<Response<StudentViewModel>> CreateStudent(CreateStudentViewModel newStudent);
    }
}