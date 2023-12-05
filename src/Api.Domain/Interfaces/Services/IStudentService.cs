using Api.Domain.DTOs;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repositories;

public interface IStudentService
{
    Task<ResponseEntity> GetStudents();
    Task<ResponseEntity> GetStudentById(string nameId);
    Task<ResponseEntity> CreateStudent(StudentCreateDto student);
    Task<ResponseEntity> UpdateStudent(string nameId, StudentUpdateDto student);
    Task<ResponseEntity> DeleteStudent(string nameId);
    double CalcAverageGrade(double test1Grade, double test2Grade, double projectGrade);
    bool AprovOrNot(double averageGrade);
}