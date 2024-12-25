namespace DependencyInversion.WithoutDIP;

public class NotificationServiceWithoutDIP
{
    public static void Run()
    {
        Console.WriteLine("******** Without Dependency Inversion) ********");
        var email = new EmailSender();
        email.Send("Meeting is scheduled at 10am.");

        var sms = new SmsSender();
        sms.Send("Meeting is scheduled at 10am.");

        var emailNotification = new NotificationService();
        var smsNotification = new NotificationService();

        emailNotification.NotifyViaEmail("You have a meeting in 15 mins.");
        smsNotification.NotifyViaSms("You have a meeting in 15 mins.");
    }

    public class EmailSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class SmsSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    public class NotificationService
    {
        private EmailSender _emailSender = new EmailSender(); // Direct dependency
        private SmsSender _smsSender = new SmsSender(); // Direct dependency


        public void NotifyViaEmail(string message)
        {
            _emailSender.Send(message); // Tightly coupled
        }

        public void NotifyViaSms(string message)
        {
            _smsSender.Send(message); // Tightly coupled
        }
    }
}
