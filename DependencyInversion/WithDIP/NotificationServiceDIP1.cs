namespace DependencyInversion.WithDIP;

public class NotificationServiceDIP1
{
    public static void Run()
    {
        Console.WriteLine("******** With Dependency Inversion) ********");
        var email = new EmailSender();
        email.Send("Meeting is scheduled at 10am.");

        var sms = new SMSSender();
        sms.Send("Meeting is scheduled at 10am.");

        var emailNotification = new NotificationService(email);
        var smsNotification = new NotificationService(sms);

        emailNotification.Notify("You have a meeting in 15 mins.");
        smsNotification.Notify("You have a meeting in 15 mins.");
    }

    // Step 1: Define an abstraction
    public interface INotificationSender
    {
        void Send(string message);
    }

    // Step 2: Implement concrete classes
    public class EmailSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class SMSSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    // Step 3: Depend on abstraction in the high-level module
    public class NotificationService
    {
        private readonly INotificationSender _notificationSender;

        // Dependency injection via constructor
        public NotificationService(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        public void Notify(string message)
        {
            _notificationSender.Send(message); // Works with any INotificationSender
        }
    }
}
