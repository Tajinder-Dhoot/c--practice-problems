namespace DependencyInversion.WithDIP;

public interface IUserRepository
{
    void Save(User user);
}
public class UserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void SaveUser(User user)
    {
        _userRepository.Save(user);
    }
}

// Low-level module
public class UserRepository : IUserRepository
{
    public void Save(User user)
    {
        // Save user to database
        Console.WriteLine($"Name is : {user.Name}");
        Console.WriteLine($"Address is : {user.Address}");
    }
}

public class User
{
    public string Name { get; }
    public string Address { get; }

    public User(string name, string address)
    {
        Name = name;
        Address = address;
    }
}
