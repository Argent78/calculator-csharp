namespace CalculatorApp;

/// <summary>
/// A simple arithmetic calculator
/// </summary>
public static class Calculator
{
    /// <summary>
    /// Evaluate the sum of two numbers.
    /// </summary>
    /// <typeparam name="T"> Number-types should match between left & right.</typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>Sum of left and right</returns>
    public static T Add<T>(T left, T right) where T : INumber<T> => left + right;

    /// <summary>
    /// Subtract right from left.
    /// </summary>
    /// <typeparam name="T"> Number-types should match between left & right.</typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns>Difference between right and left</returns>
    public static T Subtract<T>(T left, T right) where T : INumber<T> => left - right;

    /// <summary>
    /// Multiply two factors.
    /// </summary>
    /// <typeparam name="T"> Number-types should match between left & right.</typeparam>
    /// <param name="factor1"></param>
    /// <param name="factor2"></param>
    /// <returns>Product of factor1 and factor2</returns>
    public static T Multiply<T>(T factor1, T factor2) where T : INumber<T> => factor1 * factor2;

    /// <summary>
    /// Divide dividend by divisor.
    /// </summary>
    /// <typeparam name="T"> Number-types should match between left & right.</typeparam>
    /// <param name="dividend"></param>
    /// <param name="divisor"></param>
    /// <returns></returns>
    public static T Divide<T>(T dividend, T divisor) where T : INumber<T> => dividend / divisor;



    public static T ConvertToNumber<T>(string? number) where T : INumber<T>
    {
        if (string.IsNullOrEmpty(number)) throw new ArgumentNullException(nameof(number));

        try
        {
            return (T)Convert.ChangeType(number, typeof(T));
        }
        catch (Exception)
        {
            throw new InvalidNumberException();
        }
    }
}