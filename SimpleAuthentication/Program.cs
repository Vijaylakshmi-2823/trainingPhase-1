using System;

namespace SimpleAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            var auth = new UserAuthentication(); // Created an instance of authentication
            var encryption = new DataEncryption(); // Created an instance of encryption
            bool ex = true;

            while (ex)
            {
                Console.WriteLine("\nWelcome to the Secure Application!");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter username: ");
                        string? registerUsername = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(registerUsername))
                        {
                            Console.WriteLine("Username cannot be empty.");
                            break;
                        }

                        Console.Write("Enter password: ");
                        string? registerPassword = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(registerPassword))
                        {
                            Console.WriteLine("Password cannot be empty.");
                            break;
                        }

                        Console.Write("Enter sensitive data to encrypt: ");
                        string? sensitiveData = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(sensitiveData))
                        {
                            Console.WriteLine("Sensitive data cannot be empty.");
                            break;
                        }

                        // Register user
                        auth.Register(registerUsername, registerPassword);

                        // Encrypt sensitive data
                        string encryptedData = encryption.Encrypt(sensitiveData);
                        Console.WriteLine("User registered successfully!");
                        Console.WriteLine($"Encrypted Sensitive Data: {encryptedData}");
                        break;

                    case "2":
                        Console.Write("Enter username: ");
                        string? loginUsername = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(loginUsername))
                        {
                            Console.WriteLine("Username cannot be empty.");
                            break;
                        }

                        Console.Write("Enter password: ");
                        string? loginPassword = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(loginPassword))
                        {
                            Console.WriteLine("Password cannot be empty.");
                            break;
                        }

                        // Authenticate user
                        if (auth.Authenticate(loginUsername, loginPassword))
                        {
                            Console.Write("Enter encrypted data to decrypt: ");
                            string? encryptedDataToDecrypt = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(encryptedDataToDecrypt))
                            {
                                Console.WriteLine("Encrypted data cannot be empty.");
                                break;
                            }

                            // Decrypt sensitive data
                            try
                            {
                                string decryptedData = encryption.Decrypt(encryptedDataToDecrypt);
                                Console.WriteLine($"Decrypted Sensitive Data: {decryptedData}");
                            }
                            catch
                            {
                                Console.WriteLine("Invalid encrypted data.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password.");
                        }
                        break;

                    case "3":
                        ex = false;
                        Console.WriteLine("Exiting the application...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }
    }
}
