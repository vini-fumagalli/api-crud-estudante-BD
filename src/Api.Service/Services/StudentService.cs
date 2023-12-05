using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Azure;

namespace Api.Service.Services;

public class StudentService : IStudentService
{
    private IStudentRepository _repository;

    public StudentService(IStudentRepository studentRepository)
    {
        _repository = studentRepository;
    }

    public bool AprovOrNot(double averageGrade)
    {
        double schoolAverageGrade = 7.0;
        return (averageGrade >= schoolAverageGrade) ? true : false;
    }

    public double CalcAverageGrade(double test1Grade, double test2Grade, double projectGrade)
    {
        return Math.Round((0.35 * test1Grade) + (0.35 * test2Grade) + (0.3 * projectGrade), 2);
    }

    public async Task<ResponseEntity> CreateStudent(StudentCreateDto student)
    {
        var studentToCreate = new StudentEntity
        {
            NameId = student.NameId!.Replace(" ", ".").ToUpper(),
            Test1Grade = student.Test1Grade,
            Test2Grade = student.Test2Grade,
            ProjectGrade = student.ProjectGrade,
            CreatedAt = DateTime.Now.ToLocalTime()
        };
        studentToCreate.AverageGrade = CalcAverageGrade(
        studentToCreate.Test1Grade, studentToCreate.Test2Grade, studentToCreate.ProjectGrade);

        studentToCreate.Aprov = AprovOrNot(studentToCreate.AverageGrade);

        var response = await _repository.CreateStudent(studentToCreate);

        return new ResponseEntity
        {
            Success = true,
            Response = response
        };
    }

    public async Task<ResponseEntity> DeleteStudent(string nameId)
    {
        nameId = nameId.Replace(" ", ".").ToUpper();
        var response = await _repository.DeleteStudent(nameId);

        return new ResponseEntity
        {
            Success = true,
            Response = response
        };
    }

    public async Task<ResponseEntity> GetStudentById(string nameId)
    {
        nameId = nameId.Replace(" ", ".").ToUpper();
        var response = await _repository.GetStudentById(nameId);

        return new ResponseEntity
        {
            Success = true,
            Response = response
        };
    }

    public async Task<ResponseEntity> GetStudents()
    {
        var response = await _repository.GetStudents();

        return new ResponseEntity
        {
            Success = true,
            Response = response
        };
    }

    public async Task<ResponseEntity> UpdateStudent(string nameId, StudentUpdateDto student)
    {
        var studentToUpdate = new StudentEntity
        {
            NameId = nameId.Replace(" ", ".").ToUpper(),
            Test1Grade = student.Test1Grade,
            Test2Grade = student.Test2Grade,
            ProjectGrade = student.ProjectGrade,
            UpdatedAt = DateTime.Now.ToLocalTime()
        };
        studentToUpdate.AverageGrade = CalcAverageGrade(
        studentToUpdate.Test1Grade, studentToUpdate.Test2Grade,
        studentToUpdate.ProjectGrade);

        studentToUpdate.Aprov = AprovOrNot(studentToUpdate.AverageGrade);

        var response = await _repository.UpdateStudent(studentToUpdate);

        return new ResponseEntity
        {
            Success = true,
            Response = response
        };
    }
}