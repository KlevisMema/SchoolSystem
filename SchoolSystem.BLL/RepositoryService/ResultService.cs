﻿using Microsoft.EntityFrameworkCore;
using SchoolSystem.BLL.RepositoryService.CrudService;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DAL.Models;
using SchoolSystem.DTO.ViewModels.Result;

namespace SchoolSystem.BLL.RepositoryService
{
    public class ResultService : ICrudService<ResultViewModel, CreateUpdateResultViewModel>, IExists
    {
        private readonly CRUD<ResultViewModel, Result, CreateUpdateResultViewModel> _CRUD;
        private readonly ApplicationDbContext _context;

        public ResultService(
             CRUD<ResultViewModel, Result, CreateUpdateResultViewModel> CRUD, ApplicationDbContext context)
        {
            _CRUD = CRUD;
            _context = context;
        }

        /// <summary>
        /// Get all result from database
        /// </summary>
        /// <returns> A list of all results</returns>
        public async Task<Response<List<ResultViewModel>>> GetRecords()
        {
            var getAllResults = await _CRUD.GetAll();
            return getAllResults;
        }

        /// <summary>
        /// Get a single result
        /// </summary>
        /// <param name="id"> Id of a result</param>
        /// <returns> The object of a specific result</returns>
        public async Task<Response<ResultViewModel>> GetRecord(Guid id)
        {
            var getResult = await _CRUD.GetSpecificRecord(id, "Result");
            return getResult;
        }

        /// <summary>
        /// Updates a result  
        /// </summary>
        /// <param name="id">Id of a result</param>
        /// <param name="viewModel">Object that holds the new values of result </param>
        /// <returns>The updated result</returns>
        public async Task<Response<ResultViewModel>> PutRecord(Guid id, CreateUpdateResultViewModel viewModel)
        {
            var updateResult = await _CRUD.PutRecord(id, viewModel, "Result");
            return updateResult;
        }

        /// <summary>
        /// Creates a new result 
        /// </summary>
        /// <param name="viewModel">  Result object </param>
        /// <returns> The created result </returns>
        public async Task<Response<ResultViewModel>> PostRecord(CreateUpdateResultViewModel viewModel)
        {
            var postResult = await _CRUD.PostRecord(viewModel, "Result");
            return postResult;
        }

        /// <summary>
        /// Deletes a result 
        /// </summary>
        /// <param name="id"> Id of the result </param>
        /// <returns> A message telling if the result was deleted or not </returns>
        public async Task<Response<ResultViewModel>> DeleteRecord(Guid id)
        {
            var deleteResult = await _CRUD.DeleteRecord(id, "Result");
            return deleteResult;
        }

        public async Task<bool> DoesExists(Guid examId, Guid studentId, Guid subjectId)
        {
            try
            {
                var exam = await _context.Exams.AnyAsync(exam => exam.Id.Equals(examId));
                var student = await _context.Students.AnyAsync(student => student.Id.Equals(studentId));
                var subject = await _context.Subjects.AnyAsync(subject => subject.Id.Equals(subjectId));

                if (exam is false || student is false || subject is false)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}