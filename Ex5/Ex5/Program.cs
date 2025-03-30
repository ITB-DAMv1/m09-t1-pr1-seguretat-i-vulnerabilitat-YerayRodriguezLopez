using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Verification");
        Console.WriteLine("3. RSA Encryption");

        int option = int.Parse(Console.ReadLine());

        if (option == 1)
        {
            Console.Write("User: ");
            string user = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            string hash = GenerateSHA256(password);
            Console.WriteLine($"SHA256 Hash: {hash}");
        }
        else if (option == 3)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                Console.Write("Enter text: ");
                string text = Console.ReadLine();

                byte[] encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(text), false);
                Console.WriteLine($"Encrypted: {Convert.ToBase64String(encrypted)}");

                byte[] decrypted = rsa.Decrypt(encrypted, false);
                Console.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decrypted)}");
            }
        }
    }

    public static string GenerateSHA256(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
