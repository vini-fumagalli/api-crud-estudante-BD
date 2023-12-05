using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities;

public class StudentEntity : BaseEntity
{
    [Key]
    public string? NameId { get; set; }
    public double Test1Grade { get; set; }
    public double Test2Grade { get; set; }
    public double ProjectGrade { get; set; }
    public double AverageGrade { get; set; }
    public bool Aprov { get; set; }
}