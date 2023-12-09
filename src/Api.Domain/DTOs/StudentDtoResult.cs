namespace Api.Domain.DTOs;

public class StudentDtoResult
{
    public string? NameId { get; set; }
    public double Test1Grade { get; set; }
    public double Test2Grade { get; set; }
    public double ProjectGrade { get; set; }
    public double AverageGrade { get; set; }
    public bool Aprov { get; set; }
    public string? CreatedAt { get; set; }
    public string? UpdatedAt { get; set; }
}