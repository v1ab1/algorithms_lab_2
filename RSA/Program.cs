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
            Console.WriteLine("Введите путь к папке в которой хранятся файла public_key.txt, private_key.txt, input.txt, encrypted.txt, decrypted.txt");
            string path = Console.ReadLine();
            RSAParameters publicKey = rsa.ExportParameters(false);
            RSAParameters privateKey = rsa.ExportParameters(true);

            // Записываем открытый ключ в файл
            string publicKeyFile = path + "./files/public_key.txt";
            string publicKeyText = (publicKey.Modulus != null ? Convert.ToBase64String(publicKey.Modulus) : string.Empty) + ";" +
                                   (publicKey.Exponent != null ? Convert.ToBase64String(publicKey.Exponent) : string.Empty);
            File.WriteAllText(publicKeyFile, publicKeyText);

            // Записываем закрытый ключ в файл
            string privateKeyFile = path + "./files/private_key.txt";
            string privateKeyText = (privateKey.Modulus != null ? Convert.ToBase64String(privateKey.Modulus) : string.Empty) + ";" +
                                    (privateKey.Exponent != null ? Convert.ToBase64String(privateKey.Exponent) : string.Empty) + ";" +
                                    (privateKey.D != null ? Convert.ToBase64String(privateKey.D) : string.Empty) + ";" +
                                    (privateKey.P != null ? Convert.ToBase64String(privateKey.P) : string.Empty) + ";" +
                                    (privateKey.Q != null ? Convert.ToBase64String(privateKey.Q) : string.Empty) + ";" +
                                    (privateKey.DP != null ? Convert.ToBase64String(privateKey.DP) : string.Empty) + ";" +
                                    (privateKey.DQ != null ? Convert.ToBase64String(privateKey.DQ) : string.Empty) + ";" +
                                    (privateKey.InverseQ != null ? Convert.ToBase64String(privateKey.InverseQ) : string.Empty);
            File.WriteAllText(privateKeyFile, privateKeyText);

            // Шифруем файл с помощью открытого ключа
            string inputFile = path + "./files/input.txt";
            string encryptedFile = path + "./files/encrypted.txt";
            RSAEncryption.EncryptFile(inputFile, encryptedFile, publicKey);

            // Расшифровываем файл с помощью закрытого ключа
            string decryptedFile = path + "./files/decrypted.txt";
            RSAEncryption.DecryptFile(encryptedFile, decryptedFile, privateKey);
        }
    }
}
