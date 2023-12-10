using Api.Domain.DTOs;
using Api.Domain.DTOs.Student;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentServiceCrud _service;

    public StudentController(IStudentServiceCrud studentService)
    {
        _service = studentService;
    }


    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult<ResponseEntity>> CreateStudent([FromBody] StudentCreateDto student)
    {
        try
        {
            if (student.NameId!.Equals(null))
            {
                return BadRequest();
            }

            var response = await _service.CreateStudent(student);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex.Message);
            throw new Exception("ERRO AO CADASTRAR ESTUDANTE => ", ex);
        }
    }


    [HttpGet]
    [Route("Get/{nameId}")]
    public async Task<ActionResult<ResponseEntity>> GetStudentById(string nameId)
    {
        try
        {
            var response = await _service.GetStudentById(nameId);

            return Ok(response);
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex.Message);
            throw new Exception("ERRO AO OBTER ESTUDANTE DESEJADO => ", ex);
        }
    }


    [HttpPut]
    [Route("Update/{nameId}")]
    public async Task<ActionResult<ResponseEntity>> UpdateStudent(string nameId, [FromBody] StudentUpdateDto student)
    {
        try
        {
            var response = await _service.UpdateStudent(nameId, student);

            return Ok(response);
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex.Message);
            throw new Exception("ERRO AO ATUALIZAR ESTUDANTE => ", ex);
        }
    }


    [HttpGet]
    [Route("Get-All")]
    public async Task<ActionResult<ResponseEntity>> GetStudents()
    {
        try
        {
            var response = await _service.GetStudents();

            if(response.Success.Equals(false))
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex.Message);
            throw new Exception("ERRO AO OBTER ESTUDANTES => ", ex);
        }
    }


    [HttpDelete]
    [Route("Delete/{nameId}")]
    public async Task<ActionResult<ResponseEntity>> DeleteStudent(string nameId)
    {
        try
        {
            var response = await _service.DeleteStudent(nameId);

            if(response.Success.Equals(false))
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex.Message);
            throw new Exception("ERRO AO EXCLUIR ESTUDANTE => ", ex);
        }
    }



}
