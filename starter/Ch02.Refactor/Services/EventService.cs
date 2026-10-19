using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Services;

public class EventService
{
    private readonly IClubRepository _repository;
    private readonly IAppLogger _logger;
    private readonly INotificationService _notificationService;

    public EventService(IClubRepository repository, IAppLogger logger, INotificationService notificationService)
    {
        _repository = repository;
        _logger = logger;
        _notificationService = notificationService;
    }

    public Event CreateEvent(Guid clubId, string title, DateTime date)
    {
        var club = _repository.GetClub(clubId) ?? throw new InvalidOperationException("Club not found");

        var ev = new Event { Id = Guid.NewGuid(), ClubId = clubId, Title = title, Date = date };

        _logger.Log($"Event created: {title}");

        // Tạm thời giữ logic loop gửi thông báo. Nhiệm vụ 3 sẽ dùng Observer Pattern gỡ cái này ra.
        var members = _repository.GetMembersByClub(clubId);
        foreach (var m in members)
        {
            _notificationService.SendNotification(m.Email, $"New event '{title}' at {club.Name}");
        }

        return ev;
    }
}