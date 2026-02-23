using System;
interface IAuthenticationService
{
    bool AuthenticateUser(string username, string password);
    bool AuthorizeUser(string username, string role);
}

class BasicAuthenticationService : IAuthenticationService
{
    private string storedUsername = "admin";
    private string storedPassword = "admin1234";
    private string storedRole = "Hr";

    public bool AuthenticateUser(string username, string password)
    {
        return username == storedUsername && password == storedPassword;
    }
    public bool AuthorizeUser(string username, string role)
    {
        return username == storedUsername && role == storedRole;
    }
}

class Program
{
    static void Main()
    {
        IAuthenticationService authService = new BasicAuthenticationService();

        Console.Write("Enter username: ");
        string un = Console.ReadLine();

        Console.Write("Enter password: ");
        string pass = Console.ReadLine();

        bool isAuth = authService.AuthenticateUser(un, pass);
        Console.WriteLine("Authenticated: " + isAuth);

        Console.Write("Enter role: ");
        string role = Console.ReadLine();

        bool isAuthorized = authService.AuthorizeUser(un, role);
        Console.WriteLine("Authorized: " + isAuthorized);
    }
}