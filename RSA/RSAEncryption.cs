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