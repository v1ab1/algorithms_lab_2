using System;

public class SignedByteArray
{
  private byte[] value;

  // Конструкторы
  public SignedByteArray()
  {
    value = new byte[1];
  }

  public SignedByteArray(int number)
  {
    value = BitConverter.GetBytes(number);
  }

  public SignedByteArray(byte[] bytes)
  {
    value = bytes;
  }

  // Деструктор
  ~SignedByteArray()
  {
    // Освобождение ресурсов
  }

  // Перегрузка операторов аддитивных операций (+, -)
  public static SignedByteArray operator +(SignedByteArray a, SignedByteArray b)
  {
    int sum = a.ToInt() + b.ToInt();
    return new SignedByteArray(sum);
  }

  public static SignedByteArray operator -(SignedByteArray a, SignedByteArray b)
  {
    int difference = a.ToInt() - b.ToInt();
    return new SignedByteArray(difference);
  }

  // Перегрузка операторов мультипликативных операций (*, /, %)
  public static SignedByteArray operator *(SignedByteArray a, SignedByteArray b)
  {
    int product = a.ToInt() * b.ToInt();
    return new SignedByteArray(product);
  }

  public static SignedByteArray operator /(SignedByteArray a, SignedByteArray b)
  {
    int quotient = a.ToInt() / b.ToInt();
    return new SignedByteArray(quotient);
  }

  public static SignedByteArray operator %(SignedByteArray a, SignedByteArray b)
  {
    int remainder = a.ToInt() % b.ToInt();
    return new SignedByteArray(remainder);
  }

  // Перегрузка операторов сравнения (==, !=, <, >)
  public static bool operator ==(SignedByteArray a, SignedByteArray b)
  {
    return a.ToInt() == b.ToInt();
  }

  public static bool operator !=(SignedByteArray a, SignedByteArray b)
  {
    return a.ToInt() != b.ToInt();
  }

  public static bool operator <(SignedByteArray a, SignedByteArray b)
  {
    return a.ToInt() < b.ToInt();
  }

  public static bool operator >(SignedByteArray a, SignedByteArray b)
  {
    return a.ToInt() > b.ToInt();
  }

  // Взятие обратного по заданному модулю
  public SignedByteArray ModInverse(int modulus)
  {
    int valueInt = ToInt();
    int modInverse = CalculateModInverse(valueInt, modulus);
    return new SignedByteArray(modInverse);
  }

  // Вспомогательный метод для вычисления обратного по модулю
  private int CalculateModInverse(int value, int modulus)
  {
    int m0 = modulus;
    int y = 0, x = 1;

    while (value > 1)
    {
      int quotient = value / modulus;
      int temp = modulus;

      modulus = value % modulus;
      value = temp;
      temp = y;

      y = x - quotient * y;
      x = temp;
    }

    if (x < 0)
      x += m0;

    return x;
  }

  // Метод преобразования к int
  public int ToInt()
  {
    return BitConverter.ToInt32(value, 0);
  }
  public override bool Equals(object obj)
  {
    if (obj == null || GetType() != obj.GetType())
    {
      return false;
    }

    SignedByteArray other = (SignedByteArray)obj;
    return this.Equals(other);
  }

  public bool Equals(SignedByteArray other)
  {
    if (other == null)
    {
      return false;
    }

    if (this.value.Length != other.value.Length)
    {
      return false;
    }

    for (int i = 0; i < this.value.Length; i++)
    {
      if (this.value[i] != other.value[i])
      {
        return false;
      }
    }

    return true;
  }

  public override int GetHashCode()
  {
    unchecked
    {
      int hash = 17;
      foreach (byte b in this.value)
      {
        hash = hash * 23 + b.GetHashCode();
      }
      return hash;
    }
  }
  public byte[] GetArray()
  {
    return this.value;
  }

  public void SetArray(byte[] newArray)
  {
    this.value = newArray;
  }

  public void PrintArray()
{
  Console.Write("[");
  for (int i = 0; i < value.Length; i++)
  {
    Console.Write(value[i]);
    if (i < value.Length - 1)
    {
      Console.Write(", ");
    }
  }
  Console.WriteLine("]");
}


}

public class Program
{
  public static void Main(string[] args)
  {
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
