using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repositories;

public interface IStudentRepository
{
    Task<List<StudentEntity>> GetStudents();
    Task<StudentEntity?> GetStudentById(string nameId);
    Task<StudentEntity?> CreateStudent(StudentEntity student);
    Task<StudentEntity?> UpdateStudent(StudentEntity student);
    Task<bool> DeleteStudent(string nameId);
    Task<bool> ExistsStudent(string nameId);
}