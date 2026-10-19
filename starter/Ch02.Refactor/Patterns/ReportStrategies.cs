using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Patterns;

public interface IReportStrategy
{
    void GenerateReport(List<Club> clubs, IClubRepository repository);
}

public class ConsoleReportStrategy : IReportStrategy
{
    public void GenerateReport(List<Club> clubs, IClubRepository repository)
    {
        foreach (var club in clubs)
        {
            Console.WriteLine($"[Console] Club: {club.Name} | Members: {repository.GetMemberCount(club.Id)}");
        }
    }
}

public class CsvReportStrategy : IReportStrategy
{
    public void GenerateReport(List<Club> clubs, IClubRepository repository)
    {
        File.WriteAllText("report.csv", "ClubName,MemberCount\n");
        foreach (var club in clubs)
        {
            File.AppendAllText("report.csv", $"{club.Name},{repository.GetMemberCount(club.Id)}\n");
        }
        Console.WriteLine("CSV report generated at report.csv");
    }
}