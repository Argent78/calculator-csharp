namespace CalculatorApp;

internal static class Program
{
    
    private static void Main(string[] args)
    {
        while (true) // while the program is running
        {
            try
            {
                var (firstNumber, calculationType, secondNumber) = ReadUserInput();
                
                var result = Calculate<double>(firstNumber, secondNumber, calculationType);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Unable to calculate");
            }
            Console.WriteLine('\n');
        }
    }
    
    
    /**
     * Calculate the left and right operands using the user-provided calculation type
     */
    private static TResult Calculate<TResult>(string? firstNumber, string? secondNumber, string? calculationType) where TResult : INumber<TResult>
    {
        var left = Calculator.ConvertToNumber<TResult>(firstNumber);
        var right = Calculator.ConvertToNumber<TResult>(secondNumber);
        
        return calculationType switch
        {
            "+" => Calculator.Add(left, right),
            "-" => Calculator.Subtract(left, right),
            "*" => Calculator.Multiply(left, right),
            "/" => Calculator.Divide(left, right),
            _ => throw new UnknownCalculationException()
        };
    }

    
    private static (string? firstNumber, string? calculationType, string? secondNumber) ReadUserInput()
    {
        // read first number
        Console.Write("Enter first number:");
        var firstNumber = Console.ReadLine();

        // read calculation type
        Console.Write("Select calculation + - * / : ");
        var calculationType = Console.ReadLine();

        // read second number
        Console.Write("Enter second number:");
        var secondNumber = Console.ReadLine();
        return (firstNumber, calculationType, secondNumber);
    }
}
