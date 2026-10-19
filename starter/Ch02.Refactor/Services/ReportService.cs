using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Services;

public class ReportService
{
    private readonly IClubRepository _repository;
    private readonly IAppLogger _logger;

    public ReportService(IClubRepository repository, IAppLogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public void PrintClubReport()
    {
        var clubs = _repository.GetAllClubs();
        foreach (var club in clubs)
        {
            var memberCount = _repository.GetMemberCount(club.Id);

            // Tạm in ra Console. Nhiệm vụ 3 sẽ áp dụng Strategy Pattern ở đây.
            Console.WriteLine($"Club: {club.Name} | Members: {memberCount}");

            _logger.Log($"Report generated for {club.Name}");
        }
    }
}