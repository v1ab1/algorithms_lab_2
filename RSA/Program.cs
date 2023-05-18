using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class RSAEncryption
{
    public static string Encrypt(string plaintext, RSAParameters publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(publicKey);

            byte[] data = Encoding.UTF8.GetBytes(plaintext);
            byte[] encryptedData = rsa.Encrypt(data, true);

            return Convert.ToBase64String(encryptedData);
        }
    }

    public static string Decrypt(string ciphertext, RSAParameters privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(privateKey);

            byte[] encryptedData = Convert.FromBase64String(ciphertext);
            byte[] decryptedData = rsa.Decrypt(encryptedData, true);

            return Encoding.UTF8.GetString(decryptedData);
        }
    }

    public static void EncryptFile(string inputFile, string outputFile, RSAParameters publicKey)
    {
        string plaintext = File.ReadAllText(inputFile);
        string encryptedText = Encrypt(plaintext, publicKey);
        File.WriteAllText(outputFile, encryptedText);
    }

    public static void DecryptFile(string inputFile, string outputFile, RSAParameters privateKey)
    {
        string encryptedText = File.ReadAllText(inputFile);
        string decryptedText = Decrypt(encryptedText, privateKey);
        File.WriteAllText(outputFile, decryptedText);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Генерируем RSA-ключи
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            RSAParameters publicKey = rsa.ExportParameters(false);
            RSAParameters privateKey = rsa.ExportParameters(true);

            // Записываем открытый ключ в файл
            string publicKeyFile = "./files/public_key.txt";
            string publicKeyText = (publicKey.Modulus != null ? Convert.ToBase64String(publicKey.Modulus) : string.Empty) + ";" +
                                   (publicKey.Exponent != null ? Convert.ToBase64String(publicKey.Exponent) : string.Empty);
            File.WriteAllText(publicKeyFile, publicKeyText);

            // Шифруем файл с помощью открытого ключа
            string inputFile = "./files/input.txt";
            string encryptedFile = "./files/encrypted.txt";
            RSAEncryption.EncryptFile(inputFile, encryptedFile, publicKey);

            // Расшифровываем файл с помощью закрытого ключа
            string decryptedFile = "./files/decrypted.txt";
            RSAEncryption.DecryptFile(encryptedFile, decryptedFile, privateKey);
        }
    }
}
