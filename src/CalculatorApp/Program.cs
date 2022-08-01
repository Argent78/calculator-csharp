// using System.Runtime.CompilerServices;
// using System.Runtime.Versioning;
// [assembly: InternalsVisibleTo("Calculator.Tests")]

namespace Calculator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}!");
    }
}