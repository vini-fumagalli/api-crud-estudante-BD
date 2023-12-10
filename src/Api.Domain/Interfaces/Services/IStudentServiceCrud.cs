using Api.Domain.DTOs;
using Api.Domain.DTOs.Student;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services;

public interface IStudentServiceCrud
{
    Task<ResponseEntity> GetStudents();
    Task<ResponseEntity> GetStudentById(string nameId);
    Task<ResponseEntity> CreateStudent(StudentCreateDto student);
    Task<ResponseEntity> UpdateStudent(string nameId, StudentUpdateDto student);
    Task<ResponseEntity> DeleteStudent(string nameId);

}