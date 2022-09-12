using FluentAssertions;

namespace CalculatorApp.Tests;

public class CalculatorTests
{
    [Theory]
    [GenericNumberInlineData(1, 2, 3)]
    [GenericNumberInlineData(-2, 2, 0)]
    [GenericNumberInlineData(int.MinValue, -1, int.MaxValue)] //silent overflows
    [GenericNumberInlineData(int.MinValue, int.MinValue, 0)]  //silent overflows
    [GenericNumberInlineData(int.MaxValue, int.MaxValue, -2)] //silent overflows
    [GenericNumberInlineData(1.11, 2.22, 3.33)]
    [GenericNumberInlineData(10.13, 20.22, 30.35)]
    [GenericNumberInlineData(-40.111111, -6.00001, -46.111121)]
    [GenericNumberInlineData(550.5, 26, 576.5)]
    [GenericNumberInlineData(double.MaxValue, double.MaxValue, double.PositiveInfinity)] // overflow
    [GenericNumberInlineData(double.MinValue, double.MinValue, double.NegativeInfinity)] // overflow
    public void TestAddition<T>(T addend1, T addend2, T sum) where T : INumber<T>
    {
        var result = Calculator.Add(addend1, addend2);
        result.Should().Be(sum);
    }

        
    [Theory]
    [GenericNumberInlineData(1, 2, -1)]
    [GenericNumberInlineData(-2, 2, -4)]
    [GenericNumberInlineData(int.MinValue, -1, -int.MaxValue)] //silent overflows
    [GenericNumberInlineData(int.MinValue, int.MinValue, 0)]
    [GenericNumberInlineData(int.MaxValue, int.MaxValue, 0)]
    [GenericNumberInlineData(int.MinValue, int.MaxValue, 1)] //silent overflows
    [GenericNumberInlineData(1.11, 2.22, -1.11)]
    [GenericNumberInlineData(10.120840, 20.020280, -9.89944)]
    [GenericNumberInlineData(-40.131417, -6.005010, -34.126407)]
    [GenericNumberInlineData(550.5, 26, 524.5)]
    [GenericNumberInlineData(double.MaxValue, double.MaxValue, 0.0)]
    [GenericNumberInlineData(double.MinValue, double.MinValue, 0.0)]
    public void TestSubtraction<T>(T minuend, T subtrahend, T difference) where T : INumber<T>
    {
        var result = Calculator.Subtract(minuend, subtrahend);
        result.Should().Be(difference);
    }
        
    [Theory]
    [GenericNumberInlineData(10, 20, 200)]
    [GenericNumberInlineData(-21, 22, -462)]
    [GenericNumberInlineData(int.MinValue, -1, int.MinValue)] //silent overflows
    [GenericNumberInlineData(int.MinValue, int.MinValue, 0)] //silent overflows
    [GenericNumberInlineData(int.MaxValue, int.MaxValue, 1)] //silent overflows
    [GenericNumberInlineData(int.MinValue, int.MaxValue, int.MinValue)] //silent overflows
    [GenericNumberInlineData(1.11, 2.22, 2.4642000000000004)]
    [GenericNumberInlineData(10.120840, 20.020280, 202.6220506352)]
    [GenericNumberInlineData(-40.131417, -6.005010, 240.98956039917002)]
    [GenericNumberInlineData(550.5, 26, 14313)]
    [GenericNumberInlineData(double.MaxValue, double.MaxValue, double.PositiveInfinity)]
    [GenericNumberInlineData(double.MinValue, double.MinValue, double.PositiveInfinity)]
    public void TestMultiplication<T>(T factor1, T factor2, T product) where T : INumber<T>
    {
        var result = Calculator.Multiply(factor1, factor2);
        result.Should().Be(product);
    }
        
    [Theory]
    [GenericNumberInlineData(10.0, 0.0, double.PositiveInfinity)]
    [GenericNumberInlineData(int.MinValue, int.MinValue, 1)] //silent overflows
    [GenericNumberInlineData(int.MaxValue, int.MaxValue, 1)] //silent overflows
    [GenericNumberInlineData(int.MinValue, int.MaxValue, -1)] //silent overflows
    [GenericNumberInlineData(1.11, 2.22, 0.5)]
    [GenericNumberInlineData(10.120840, 20.020280, 0.5055293931953)]
    [GenericNumberInlineData(-40.131417, -6.005010, 6.682989204014647)]
    [GenericNumberInlineData(550.5, 26, 21.173076923076923)]
    [GenericNumberInlineData(double.MaxValue, double.MaxValue, 1.0)]
    [GenericNumberInlineData(double.MinValue, double.MinValue, 1.0)]
    public void TestDivision<T>(T dividend, T divisor, T quotient) where T : INumber<T>
    {
        var result = Calculator.Divide(dividend, divisor);
        result.Should().Be(quotient);
    }

    //TODO: Test for exceptions
    // [GenericNumberInlineData(int.MinValue, -1, int.MinValue)] //silent overflows
}