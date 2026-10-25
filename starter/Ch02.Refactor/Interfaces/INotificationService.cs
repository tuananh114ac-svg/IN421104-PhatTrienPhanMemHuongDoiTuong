namespace EduHub.Ch02.Interfaces;

public interface INotificationService
{
    void SendNotification(string recipient, string message);
}