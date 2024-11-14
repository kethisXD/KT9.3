using System;

public class Calculator<T> where T : new()
{
    // Статический метод для сложения двух значений типа T
    public static T Add(T x, T y)
    {
        // Приведение типов к dynamic для выполнения операции сложения
        dynamic dx = x;
        dynamic dy = y;
        return dx + dy;
    }

    // Метод для получения нулевого значения типа T с помощью конструктора без параметров
    public T Zero()
    {
        return new T();
    }
}

// Пример использования класса Calculator<T>
public class Program
{
    public static void Main()
    {
        // Пример с типом int
        int a = 5;
        int b = 10;
        int sumInt = Calculator<int>.Add(a, b);
        Console.WriteLine($"Сумма int: {sumInt}"); // Выведет: Сумма int: 15

        Calculator<int> intCalculator = new Calculator<int>();
        int zeroInt = intCalculator.Zero();
        Console.WriteLine($"Ноль int: {zeroInt}"); // Выведет: Ноль int: 0

        // Пример с типом double
        double x = 3.5;
        double y = 2.5;
        double sumDouble = Calculator<double>.Add(x, y);
        Console.WriteLine($"Сумма double: {sumDouble}"); // Выведет: Сумма double: 6.0

        Calculator<double> doubleCalculator = new Calculator<double>();
        double zeroDouble = doubleCalculator.Zero();
        Console.WriteLine($"Ноль double: {zeroDouble}"); // Выведет: Ноль double: 0.0

        // Пример с пользовательским типом, имеющим конструктор без параметров
        var custom = new CustomType { Value = 10 };
        var customSum = Calculator<CustomType>.Add(custom, new CustomType { Value = 20 });
        Console.WriteLine($"Сумма CustomType: {customSum.Value}"); // Выведет: Сумма CustomType: 30

        Calculator<CustomType> customCalculator = new Calculator<CustomType>();
        var zeroCustom = customCalculator.Zero();
        Console.WriteLine($"Ноль CustomType: {zeroCustom.Value}"); // Выведет: Ноль CustomType: 0
    }
}

// Пример пользовательского типа с поддержкой операции сложения
public class CustomType
{
    public int Value { get; set; }

    // Параметрический конструктор
    public CustomType() 
    {
        Value = 0;
    }

    // Оператор сложения для CustomType
    public static CustomType operator +(CustomType a, CustomType b)
    {
        return new CustomType { Value = a.Value + b.Value };
    }
}