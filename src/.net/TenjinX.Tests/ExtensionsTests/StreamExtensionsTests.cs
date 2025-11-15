using FluentAssertions;
using System.Text;
using System.Text.Json;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StreamExtensionsTests
{
    private record TestJsonObject
    {
        public string Name { get; init; } = string.Empty;

        public int Age { get; init; }
    }

    [Fact]
    public static async Task ReadAsJsonObject_WhenEmpty_ReturnsNull()
    {
        var stream = CreateStreamFromString(string.Empty);
        var result = await stream.ReadAsJsonObject<TestJsonObject>();

        Assert.Null(result);
    }
    [Fact]
    public static async Task ReadAsJsonObject_WhenValidJson_ReturnsDeserializedObject()
    {
        var jsonObject = new TestJsonObject
        {
            Name = "John Doe",
            Age = 30
        };
        var jsonString = JsonSerializer.Serialize(jsonObject);
        var stream = CreateStreamFromString(jsonString);
        var result = await stream.ReadAsJsonObject<TestJsonObject>();

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(jsonObject);
    }

    [Fact]
    public static async Task ReadAsString_GivenStream_ReturnsCorrectString()
    {
        var stringValue = Guid.NewGuid().ToString();
        var stream = CreateStreamFromString(stringValue);
        var result = await stream.ReadAsString();

        result.Should().Be(stringValue);
    }

    [Fact]
    public static async Task ReadAsByteArray_GivenStream_ReturnsCorrectByteArray()
    {
        var stringValue = Guid.NewGuid().ToString();
        var expectedBytes = Encoding.UTF8.GetBytes(stringValue);
        var stream = CreateStreamFromString(stringValue);
        var result = await stream.ReadAsByteArray();

        result.Should().BeEquivalentTo(expectedBytes);
    }

    private static Stream CreateStreamFromString(string content)
    {
        var byteArray = Encoding.UTF8.GetBytes(content);

        return new MemoryStream(byteArray);
    }
}
