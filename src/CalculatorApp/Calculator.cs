namespace CalculatorApp;

public static class Calculator
{
    //TODO: Document this class
    public static T Add<T>(T left, T right) where T : INumber<T> => left + right;

    public static T Subtract<T>(T left, T right) where T : INumber<T> => left - right;

    public static T Multiply<T>(T factor1, T factor2) where T : INumber<T> => factor1 * factor2;

    public static T Divide<T>(T dividend, T divisor) where T : INumber<T> => dividend / divisor;
}