namespace Api.Domain.Interfaces.Services;

public interface IStudentServiceLogics
{
    double CalcAverageGrade(double test1Grade, double test2Grade, double projectGrade);
    bool AprovOrNot(double averageGrade);
}