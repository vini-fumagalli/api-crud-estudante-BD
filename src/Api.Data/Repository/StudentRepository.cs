using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly DbSet<StudentEntity> _dataset;
    private readonly MyContext _contextStudent;

    public StudentRepository(MyContext context)
    {
        _contextStudent = context;
        _dataset = _contextStudent.Set<StudentEntity>();
    }
    public async Task<StudentEntity?> CreateStudent(StudentEntity student)
    {
        try
        {
            var exists = await ExistsStudent(student.NameId!);
            if (!exists)
            {
                await _dataset.AddAsync(student);
                await _contextStudent.SaveChangesAsync();

                return student;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("ERRO AO CADASTRAR ESTUDANTE => ", ex);
        }
    }

    public async Task<bool> DeleteStudent(string nameId)
    {
        try
        {
            var student = await _dataset
            .SingleOrDefaultAsync(s => s.NameId!.Equals(nameId));

            if (student != null)
            {
                _dataset.Remove(student);
                await _contextStudent.SaveChangesAsync();

                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception("ERRO AO EXCLUIR ESTUDANTE => ", ex);
        }
    }

    public async Task<bool> ExistsStudent(string nameId)
    {
        return await _dataset
        .AsNoTracking()
        .AnyAsync(s => s.NameId!.Equals(nameId));
    }

    public async Task<StudentEntity?> GetStudentById(string nameId)
    {
        try
        {
            var student = await _dataset
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.NameId!.Equals(nameId));

            return student;
        }
        catch (Exception ex)
        {
            throw new Exception("ERRO AO VISUALIZAR ESTUDANTE DESEJADO => ", ex);
        }
    }

    public async Task<List<StudentEntity>> GetStudents()
    {
        try
        {
            return await _dataset.AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("ERRO AO VISUALIZAR ESTUDANTES => ", ex);
        }
    }

    public async Task<StudentEntity?> UpdateStudent(StudentEntity student)
    {
        try
        {
            var studentToUpdate = await _dataset
            .SingleOrDefaultAsync(s => s.NameId!.Equals(student.NameId));

            if (studentToUpdate != null)
            {
                student.CreatedAt = studentToUpdate!.CreatedAt;

                _dataset.Entry(studentToUpdate).CurrentValues.SetValues(student);
                await _contextStudent.SaveChangesAsync();

                return student;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("ERRO AO ATUALIZAR ESTUDANTE => ", ex);
        }
    }
}