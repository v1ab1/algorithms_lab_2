using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

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
            string publicKeyFile = path + "/public_key.txt";
            string publicKeyText = (publicKey.Modulus != null ? Convert.ToBase64String(publicKey.Modulus) : string.Empty) + ";" +
                                   (publicKey.Exponent != null ? Convert.ToBase64String(publicKey.Exponent) : string.Empty);
            File.WriteAllText(publicKeyFile, publicKeyText);

            // Записываем закрытый ключ в файл
            string privateKeyFile = path + "/private_key.txt";
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
            string inputFile = path + "/input.txt";
            string encryptedFile = path + "/encrypted.txt";
            RSAEncryption.EncryptFile(inputFile, encryptedFile, publicKey);

            // Расшифровываем файл с помощью закрытого ключа
            string decryptedFile = path + "/decrypted.txt";
            RSAEncryption.DecryptFile(encryptedFile, decryptedFile, privateKey);

            Console.WriteLine("Провести тест? y/n");
            if (Console.ReadLine() == "y") {
                string origin = File.ReadAllText(inputFile);
                string decrypted = File.ReadAllText(decryptedFile);
                Console.WriteLine("Оригинальный файл: {0}", origin);
                Console.WriteLine("Расшифрованный файл: {0}", decrypted);
                if (origin == decrypted) {
                    Console.WriteLine("Тест успешно пройден");
                } else {
                    Console.WriteLine("Тест не пройден");
                }
            }
        }
    }
}
