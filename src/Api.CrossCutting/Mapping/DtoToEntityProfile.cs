using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using AutoMapper;

namespace Api.CrossCutting.Mapping;

public class DtoToEntityProfile : Profile, IStudentServiceLogics
{
    public DtoToEntityProfile()
    {
        CreateMap<StudentCreateDto, StudentEntity>()
        .ForMember(dest => dest.NameId, opt => opt.MapFrom(src => src.NameId!.Replace(" ", ".").ToUpper()))
        .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()))
        .AfterMap((src, dest) =>
        {
            dest.AverageGrade = CalcAverageGrade(src.Test1Grade, src.Test2Grade, src.ProjectGrade);
            dest.Aprov = AprovOrNot(dest.AverageGrade);
        });

        CreateMap<StudentUpdateDto, StudentEntity>()
        .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()))
        .AfterMap((src, dest) =>
        {
            dest.AverageGrade = CalcAverageGrade(src.Test1Grade, src.Test2Grade, src.ProjectGrade);
            dest.Aprov = AprovOrNot(dest.AverageGrade);
        });
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
}