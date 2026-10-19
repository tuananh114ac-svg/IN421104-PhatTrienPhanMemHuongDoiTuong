using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Patterns;

public interface IEventObserver
{
    void OnEventCreated(Event ev, Club club);
}

public class EmailNotifierObserver : IEventObserver
{
    private readonly INotificationService _notificationService;
    private readonly IClubRepository _repository;

    public EmailNotifierObserver(INotificationService notificationService, IClubRepository repository)
    {
        _notificationService = notificationService;
        _repository = repository;
    }

    public void OnEventCreated(Event ev, Club club)
    {
        var members = _repository.GetMembersByClub(club.Id);
        foreach (var m in members)
        {
            _notificationService.SendNotification(m.Email, $"New event '{ev.Title}' at {club.Name}");
        }
    }
}

public class LogNotifierObserver : IEventObserver
{
    private readonly IAppLogger _logger;
    public LogNotifierObserver(IAppLogger logger) => _logger = logger;

    public void OnEventCreated(Event ev, Club club)
    {
        _logger.Log($"[OBSERVER LOG] Event '{ev.Title}' was broadcasted to members.");
    }
}