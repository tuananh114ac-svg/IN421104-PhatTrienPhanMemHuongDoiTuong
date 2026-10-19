using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Services;

public class ClubService
{
    private readonly IClubRepository _repository;
    private readonly IAppLogger _logger;
    private readonly INotificationService _notificationService;

    // Tiêm phụ thuộc qua Constructor (DIP)
    public ClubService(IClubRepository repository, IAppLogger logger, INotificationService notificationService)
    {
        _repository = repository;
        _logger = logger;
        _notificationService = notificationService;
    }

    public void CreateClub(string name, string description, string presidentEmail)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Club name is required");
        if (name.Length > 100)
            throw new ArgumentException("Club name too long");

        var club = new Club { Id = Guid.NewGuid(), Name = name, Description = description };
        _repository.AddClub(club);

        _logger.Log($"Club created: {name}");

        // Tạm thời gọi trực tiếp, Nhiệm vụ 3 sẽ dùng Factory
        _notificationService.SendNotification(presidentEmail, $"Welcome president of {name}");
    }

    public void AddMemberToClub(Guid clubId, string memberName, string email)
    {
        var club = _repository.GetClub(clubId) ?? throw new InvalidOperationException("Club not found");

        if (_repository.GetMemberCount(clubId) >= 50)
            throw new InvalidOperationException("Club is full (max 50 members)");

        var member = new Member { Id = Guid.NewGuid(), Name = memberName, Email = email, ClubId = clubId };
        _repository.AddMember(member);

        _logger.Log($"Member {memberName} joined {club.Name}");
        _notificationService.SendNotification(email, $"Welcome to {club.Name}");
    }
}