using System;

public class Tests
{
    public static void TestAddition()
    {
        Console.WriteLine("Тест сложения:");
        
        SignedByteArray a = new SignedByteArray(5);
        SignedByteArray b = new SignedByteArray(3);
        
        SignedByteArray result = a + b;
        
        Console.WriteLine("Ожидаемый результат: [8]");
        Console.Write("Фактический результат: ");
        result.PrintArray();
        Console.WriteLine();
    }
    
    public static void TestSubtraction()
    {
        Console.WriteLine("Тест вычитания:");
        
        SignedByteArray a = new SignedByteArray(10);
        SignedByteArray b = new SignedByteArray(7);
        
        SignedByteArray result = a - b;
        
        Console.WriteLine("Ожидаемый результат: [3]");
        Console.Write("Фактический результат: ");
        result.PrintArray();
        Console.WriteLine();
    }
    
    public static void TestMultiplication()
    {
        Console.WriteLine("Тест умножения:");
        
        SignedByteArray a = new SignedByteArray(4);
        SignedByteArray b = new SignedByteArray(5);
        
        SignedByteArray result = a * b;
        
        Console.WriteLine("Ожидаемый результат: [20]");
        Console.Write("Фактический результат: ");
        result.PrintArray();
        Console.WriteLine();
    }
    
    public static void TestDivision()
    {
        Console.WriteLine("Тест целочисленного деления:");
        
        SignedByteArray a = new SignedByteArray(15);
        SignedByteArray b = new SignedByteArray(4);
        
        SignedByteArray result = a / b;
        
        Console.WriteLine("Ожидаемый результат: [3]");
        Console.Write("Фактический результат: ");
        result.PrintArray();
        Console.WriteLine();
    }
    
    public static void TestModulus()
    {
        Console.WriteLine("Тест остатка от деления:");
        
        SignedByteArray a = new SignedByteArray(17);
        SignedByteArray b = new SignedByteArray(5);
        
        SignedByteArray result = a % b;
        
        Console.WriteLine("Ожидаемый результат: [2]");
        Console.Write("Фактический результат: ");
        result.PrintArray();
        Console.WriteLine();
    }
    
    public static void TestEquality()
    {
        Console.WriteLine("Тест равенства:");
        
        SignedByteArray a = new SignedByteArray(5);
        SignedByteArray b = new SignedByteArray(5);
        
        bool result = a == b;
        
        Console.WriteLine("Ожидаемый результат: True");
        Console.WriteLine("Фактический результат: " + result);
        Console.WriteLine();
    }
    
    public static void TestInequality()
    {
        Console.WriteLine("Тест неравенства:");
        
        SignedByteArray a = new SignedByteArray(5);
        SignedByteArray b = new SignedByteArray(7);
        
        bool result = a != b;
        
        Console.WriteLine("Ожидаемый результат: True");
        Console.WriteLine("Фактический результат: " + result);
        Console.WriteLine();
    }
    
    public static void TestGreaterThan()
    {
        Console.WriteLine("Тест больше:");
        
        SignedByteArray a = new SignedByteArray(8);
        SignedByteArray b = new SignedByteArray(5);
        
        bool result = a > b;
        
        Console.WriteLine("Ожидаемый результат: True");
        Console.WriteLine("Фактический результат: " + result);
        Console.WriteLine();
    }
    
    public static void TestLessThan()
    {
        Console.WriteLine("Тест меньше:");
        
        SignedByteArray a = new SignedByteArray(3);
        SignedByteArray b = new SignedByteArray(5);
        
        bool result = a < b;
        
        Console.WriteLine("Ожидаемый результат: True");
        Console.WriteLine("Фактический результат: " + result);
        Console.WriteLine();
    }
    
    public static void TestModInverse()
    {
        Console.WriteLine("Тест обратного по модулю:");
        
        SignedByteArray a = new SignedByteArray(3);
        SignedByteArray b = new SignedByteArray(7);
        
        SignedByteArray result = a.ModInverse(b.ToInt());
        
        Console.WriteLine("Ожидаемый результат: [5]");
        Console.Write("Фактический результат: ");
        result.PrintArray();
        Console.WriteLine();
    }
    
    public static void Run()
    {
        TestAddition();
        TestSubtraction();
        TestMultiplication();
        TestDivision();
        TestModulus();
        TestEquality();
        TestInequality();
        TestGreaterThan();
        TestLessThan();
        TestModInverse();
    }
}
