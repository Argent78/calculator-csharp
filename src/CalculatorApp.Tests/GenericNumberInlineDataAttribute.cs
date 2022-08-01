using System.Reflection;
using Xunit.Sdk;
// ReSharper disable StringLiteralTypo

namespace CalculatorApp.Tests;

[DataDiscoverer("Xunit.Sdk.InlineDataDiscoverer", "xunit.core")]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
internal class GenericNumberInlineDataAttribute: DataAttribute
{
    private readonly object[] data;

    public GenericNumberInlineDataAttribute(params object[] data)
    {
        this.data = data;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod) =>
        new[]
        {
            this.data
        };
}