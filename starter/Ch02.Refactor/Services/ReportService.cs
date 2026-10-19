using EduHub.Ch02.Interfaces;
using EduHub.Ch02.Patterns;
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

    // Trong ReportService.cs, thay thế hàm PrintClubReport cũ bằng:
    public void Generate(IReportStrategy strategy)
    {
        var clubs = _repository.GetAllClubs();
        strategy.GenerateReport(clubs, _repository);
        _logger.Log("Report generated via strategy.");
    }
}