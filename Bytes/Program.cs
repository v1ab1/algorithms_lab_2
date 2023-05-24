using System;

public class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Провести тесты? y/n");
    string answer = Console.ReadLine();
    if (answer == "y" || answer == "yes")
    {
      Tests.Run();
    }
    while (true) {
      Console.WriteLine("Введите первую цифру:");
      SignedByteArray a = new SignedByteArray(Convert.ToInt32(Console.ReadLine()));
      Console.WriteLine("Предстваление первой цифры в виде массива однобайтовых элементов:");
      a.PrintArray();

      Console.WriteLine("Введите операцию:");
      Console.WriteLine("+: сумма");
      Console.WriteLine("-: разность");
      Console.WriteLine("*: умножение");
      Console.WriteLine("/: целое");
      Console.WriteLine("%: остаток");
      Console.WriteLine("==: равенство");
      Console.WriteLine("!=: неравенство");
      Console.WriteLine(">: больше");
      Console.WriteLine("<: меньше");
      Console.WriteLine("mod: обратное по модулю");
      string oper = Console.ReadLine();

      Console.WriteLine("Введите вторую цифру:");
      SignedByteArray b = new SignedByteArray(Convert.ToInt32(Console.ReadLine()));
      Console.WriteLine("Предстваление второй цифры в виде массива однобайтовых элементов:");
      b.PrintArray();

      SignedByteArray result;
      bool resultBool;

      switch (oper)
      {
        case "+":
          result = a + b;
          Console.WriteLine("Результат в виде массива однобайтовых элементов:");
          result.PrintArray();
          Console.WriteLine("Результат в числах:");
          Console.WriteLine(result.ToInt());
          break;
        case "-":
          result = a - b;
          Console.WriteLine("Результат в виде массива однобайтовых элементов:");
          result.PrintArray();
          Console.WriteLine("Результат в числах:");
          Console.WriteLine(result.ToInt());
          break;
        case "*":
          result = a * b;
          Console.WriteLine("Результат в виде массива однобайтовых элементов:");
          result.PrintArray();
          Console.WriteLine("Результат в числах:");
          Console.WriteLine(result.ToInt());
          break;
        case "/":
          result = a / b;
          Console.WriteLine("Результат в виде массива однобайтовых элементов:");
          result.PrintArray();
          Console.WriteLine("Результат в числах:");
          Console.WriteLine(result.ToInt());
          break;
        case "%":
          result = a % b;
          Console.WriteLine("Результат в виде массива однобайтовых элементов:");
          result.PrintArray();
          Console.WriteLine("Результат в числах:");
          Console.WriteLine(result.ToInt());
          break;
        case "mod":
          result = a.ModInverse(b.ToInt());
          Console.WriteLine("Результат в виде массива однобайтовых элементов:");
          result.PrintArray();
          Console.WriteLine("Результат в числах:");
          Console.WriteLine(result.ToInt());
          break;
        case "==":
          resultBool = (a == b);
          Console.WriteLine("Результат:");
          Console.WriteLine(resultBool);
          break;
        case "!=":
          resultBool = (a != b);
          Console.WriteLine("Результат:");
          Console.WriteLine(resultBool);
          break;
        case ">":
          resultBool = (a > b);
          Console.WriteLine("Результат:");
          Console.WriteLine(resultBool);
          break;
        case "<":
          resultBool = (a < b);
          Console.WriteLine("Результат:");
          Console.WriteLine(resultBool);
          break;
        default:
          Console.WriteLine("Неправильный оператор");
          continue;
      }
    }
  }
}
