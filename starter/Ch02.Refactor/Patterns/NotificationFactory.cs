using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Patterns;

public enum NotificationChannel { Gmail, Yahoo, Default }

// Các class thực thi cụ thể
public class GmailNotification : INotificationService
{
    public void SendNotification(string recipient, string message) =>
        Console.WriteLine($"[Gmail] Sending to {recipient}: {message}");
}

public class YahooNotification : INotificationService
{
    public void SendNotification(string recipient, string message) =>
        Console.WriteLine($"[Yahoo] Sending to {recipient}: {message}");
}

public class DefaultNotification : INotificationService
{
    public void SendNotification(string recipient, string message) =>
        Console.WriteLine($"[Generic] Sending to {recipient}: {message}");
}

// Factory
public static class NotificationFactory
{
    public static INotificationService Create(NotificationChannel channel)
    {
        return channel switch
        {
            NotificationChannel.Gmail => new GmailNotification(),
            NotificationChannel.Yahoo => new YahooNotification(),
            _ => new DefaultNotification()
        };
    }
}