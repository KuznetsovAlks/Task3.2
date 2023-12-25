using System.Text;

namespace task3._2.Extensions;


public static class ConsoleExtensions
{
    public static int ReadInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine()!.Trim(), out int number))
                return number;

            Console.WriteLine("Введите число");
        }
    }
}
public static class ArrayExtensions
{
    public static string ToStringTable(this int[,] intArray)
    {
        int rows = intArray.GetLength(0);
        int columns = intArray.GetLength(1);
        var sb = new StringBuilder();

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
                sb.Append($"{intArray[i, j],4}");
            sb.AppendLine();
        }

        return sb.ToString();
    }
}

internal static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Кол-во строк: ");
        int rows = ConsoleExtensions.ReadInt();
        Console.Write("Кол-во столбцов: ");
        int columns = ConsoleExtensions.ReadInt();

        var frstMatrix = new int[rows, columns];
        var scndMatrix = new int[rows, columns];

        var random = new Random();
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                frstMatrix[i, j] = random.Next(0, 100);
                scndMatrix[i, j] = random.Next(0, 100);
            }
        }

        Console.WriteLine($"Матрица 1: \n{frstMatrix.ToStringTable()}");
        Console.WriteLine($"Матрица 2: \n{scndMatrix.ToStringTable()}");

        var sumMatrix = new int[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
                
            sumMatrix[i, j] = frstMatrix[i, j] + scndMatrix[i, j];
        }

        Console.WriteLine($"Сумма матриц: \n{sumMatrix.ToStringTable()}");
    }
}