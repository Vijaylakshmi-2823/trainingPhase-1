using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//namespace ConsoleApp8
//{
//    internal class User_Authentication
//    {
//    }
//}


public class UserAuthentication
{
    public string Username { get; private set; }=string.Empty;
    private string HashedPassword { get; set; } = string.Empty; 

    public void Register(string username, string password)
    {
        Username = username;
        HashedPassword = HashPassword(password);
    }

    public bool Authenticate(string username, string password)
    {
        return Username == username && HashedPassword == HashPassword(password);
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}

