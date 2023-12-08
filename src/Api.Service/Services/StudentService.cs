using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using AutoMapper;
using Azure;

namespace Api.Service.Services;

public class StudentService : IStudentServiceCrud
{
    private IStudentRepository _repository;
    private IMapper _mapper;

    public StudentService(IMapper mapper, IStudentRepository studentRepository)
    {
        _repository = studentRepository;
        _mapper = mapper;
    }

    public async Task<ResponseEntity> CreateStudent(StudentCreateDto student)
    {
        var studentToCreate = _mapper.Map<StudentEntity>(student);

        var response = await _repository.CreateStudent(studentToCreate);

        return new ResponseEntity
        {
            Success = true,
            Response = response
        };
    }

    public async Task<ResponseEntity> UpdateStudent(string nameId, StudentUpdateDto student)
    {
        var studentToUpdate = _mapper.Map<StudentEntity>(student);
        studentToUpdate.NameId = nameId.Replace(" ", ".").ToUpper();

        var response = await _repository.UpdateStudent(studentToUpdate);

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

}