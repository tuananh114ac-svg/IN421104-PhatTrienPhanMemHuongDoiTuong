using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Patterns;

public class LoggingClubRepository : IClubRepository
{
    private readonly IClubRepository _innerRepository;
    private readonly IAppLogger _logger;

    public LoggingClubRepository(IClubRepository innerRepository, IAppLogger logger)
    {
        _innerRepository = innerRepository;
        _logger = logger;
    }

    public void AddClub(Club club)
    {
        _logger.Log($"[DB LOG] Bắt đầu thêm CLB {club.Name}...");
        _innerRepository.AddClub(club);
        _logger.Log($"[DB LOG] Thêm thành công CLB {club.Name}.");
    }

    public Club GetClub(Guid id) => _innerRepository.GetClub(id);
    public List<Club> GetAllClubs() => _innerRepository.GetAllClubs();
    public void AddMember(Member member) => _innerRepository.AddMember(member);
    public int GetMemberCount(Guid clubId) => _innerRepository.GetMemberCount(clubId);
    public List<Member> GetMembersByClub(Guid clubId) => _innerRepository.GetMembersByClub(clubId);
}