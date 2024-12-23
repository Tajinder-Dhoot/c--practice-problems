using DependencyInversion.WithDIP;
using DependencyInversion.WithoutDIP;

namespace DependencyInversion;

public class Program
{
    public static void Main()
    {
    //     var notificationService = new NotificationServiceWithoutDIP();
    //     var notificationServiceDIP = new NotificationServiceDIP1();
        NotificationServiceWithoutDIP.Run();
        NotificationServiceDIP1.Run();

        var user = new User("Tajinder SIngh", "111 Westmount, Markham");
        var userService = new UserService(new UserRepository());
        userService.SaveUser(user);
    }
}
