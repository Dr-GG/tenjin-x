using FluentAssertions;
using FluentAssertions.Common;
using TenjinX.Enums;
using TenjinX.Exceptions;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class HashingExtensionsTests
{
    [Theory]

    // FNV-1a 32-bit
    [InlineData(TenjinXHashingAlgorithm.Fnv1A32Bit, null, 0)]
    [InlineData(TenjinXHashingAlgorithm.Fnv1A32Bit, "", 0)]
    [InlineData(TenjinXHashingAlgorithm.Fnv1A32Bit, "hello", 1335831723)]
    [InlineData(TenjinXHashingAlgorithm.Fnv1A32Bit, "world", 933488787)]
    [InlineData(TenjinXHashingAlgorithm.Fnv1A32Bit, " hello ", -1103685569)]
    [InlineData(TenjinXHashingAlgorithm.Fnv1A32Bit, " world ", 846273863)]
    [InlineData(TenjinXHashingAlgorithm.Fnv1A32Bit, " ", 621580159)]
    [InlineData(TenjinXHashingAlgorithm.Fnv1A32Bit, "  ", -1312443763)]
    [InlineData(TenjinXHashingAlgorithm.Fnv1A32Bit, "   ", -2026355113)]
    public static void GetDeterministicHashCode_String_ReturnsExpectedHashCode
    (
        TenjinXHashingAlgorithm algorithm,
        string? input,
        int expectedHashCode
    )
    {
        var actualHashCode = input.GetDeterministicHashCode(algorithm);

        actualHashCode.Should().Be(expectedHashCode);
    }

    [Fact]
    public static void GetDeterministicHashCode_StringWhenTheAlgorithmIsNotSupported_ThrowsAnException()
    {
        var fakeHashingAlgorithm = (TenjinXHashingAlgorithm)999;
        var action = () => "test".GetDeterministicHashCode(fakeHashingAlgorithm);

        action.Should().Throw<TenjinException>();
    }

    [Fact]
    public static void GetDeterministicHashCode_StructBasedValueType_ReturnsExpectedHashCode()
    {
        // bool
        AssertDeterministicHashCodeForStructBasedValueType<bool>(null);
        AssertDeterministicHashCodeForStructBasedValueType<bool>(true);
        AssertDeterministicHashCodeForStructBasedValueType<bool>(false);

        // byte
        AssertDeterministicHashCodeForStructBasedValueType<byte>(null);
        AssertDeterministicHashCodeForStructBasedValueType<byte>(0);
        AssertDeterministicHashCodeForStructBasedValueType<byte>(42);
        AssertDeterministicHashCodeForStructBasedValueType<byte>(byte.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<byte>(byte.MaxValue);

        // s-byte
        AssertDeterministicHashCodeForStructBasedValueType<sbyte>(null);
        AssertDeterministicHashCodeForStructBasedValueType<sbyte>(0);
        AssertDeterministicHashCodeForStructBasedValueType<sbyte>(42);
        AssertDeterministicHashCodeForStructBasedValueType<sbyte>(sbyte.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<sbyte>(sbyte.MaxValue);

        // char
        AssertDeterministicHashCodeForStructBasedValueType<char>(null);
        AssertDeterministicHashCodeForStructBasedValueType<char>('A');
        AssertDeterministicHashCodeForStructBasedValueType<char>('Z');
        AssertDeterministicHashCodeForStructBasedValueType<char>('a');
        AssertDeterministicHashCodeForStructBasedValueType<char>('z');
        AssertDeterministicHashCodeForStructBasedValueType<char>(char.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<char>(char.MaxValue);

        // int-16
        AssertDeterministicHashCodeForStructBasedValueType<short>(null);
        AssertDeterministicHashCodeForStructBasedValueType<short>(0);
        AssertDeterministicHashCodeForStructBasedValueType<short>(42);
        AssertDeterministicHashCodeForStructBasedValueType<short>(-42);
        AssertDeterministicHashCodeForStructBasedValueType<short>(short.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<short>(short.MaxValue);

        // uint-16
        AssertDeterministicHashCodeForStructBasedValueType<ushort>(null);
        AssertDeterministicHashCodeForStructBasedValueType<ushort>(0);
        AssertDeterministicHashCodeForStructBasedValueType<ushort>(42);
        AssertDeterministicHashCodeForStructBasedValueType<ushort>(ushort.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<ushort>(ushort.MaxValue);

        // int-32
        AssertDeterministicHashCodeForStructBasedValueType<int>(null);
        AssertDeterministicHashCodeForStructBasedValueType<int>(0);
        AssertDeterministicHashCodeForStructBasedValueType<int>(42);
        AssertDeterministicHashCodeForStructBasedValueType<int>(-42);
        AssertDeterministicHashCodeForStructBasedValueType<int>(int.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<int>(int.MaxValue);

        // uint-32
        AssertDeterministicHashCodeForStructBasedValueType<uint>(null);
        AssertDeterministicHashCodeForStructBasedValueType<uint>(0);
        AssertDeterministicHashCodeForStructBasedValueType<uint>(42);
        AssertDeterministicHashCodeForStructBasedValueType<uint>(uint.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<uint>(uint.MaxValue);

        // int-64
        AssertDeterministicHashCodeForStructBasedValueType<long>(null);
        AssertDeterministicHashCodeForStructBasedValueType<long>(0);
        AssertDeterministicHashCodeForStructBasedValueType<long>(42);
        AssertDeterministicHashCodeForStructBasedValueType<long>(-42);
        AssertDeterministicHashCodeForStructBasedValueType<long>(long.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<long>(long.MaxValue);

        // uint-64
        AssertDeterministicHashCodeForStructBasedValueType<ulong>(null);
        AssertDeterministicHashCodeForStructBasedValueType<ulong>(0);
        AssertDeterministicHashCodeForStructBasedValueType<ulong>(42);
        AssertDeterministicHashCodeForStructBasedValueType<ulong>(ulong.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<ulong>(ulong.MaxValue);

        // decimal
        AssertDeterministicHashCodeForStructBasedValueType<decimal>(null);
        AssertDeterministicHashCodeForStructBasedValueType<decimal>(0);
        AssertDeterministicHashCodeForStructBasedValueType<decimal>(42);
        AssertDeterministicHashCodeForStructBasedValueType<decimal>(-42);
        AssertDeterministicHashCodeForStructBasedValueType<decimal>(decimal.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<decimal>(decimal.MaxValue);

        // double
        AssertDeterministicHashCodeForStructBasedValueType<double>(null);
        AssertDeterministicHashCodeForStructBasedValueType<double>(0);
        AssertDeterministicHashCodeForStructBasedValueType<double>(42.42);
        AssertDeterministicHashCodeForStructBasedValueType<double>(-42.42);
        AssertDeterministicHashCodeForStructBasedValueType<double>(double.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<double>(double.MaxValue);

        // float
        AssertDeterministicHashCodeForStructBasedValueType<float>(null);
        AssertDeterministicHashCodeForStructBasedValueType<float>(0);
        AssertDeterministicHashCodeForStructBasedValueType<float>(42.42f);
        AssertDeterministicHashCodeForStructBasedValueType<float>(-42.42f);
        AssertDeterministicHashCodeForStructBasedValueType<float>(float.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<float>(float.MaxValue);

        // DateTime
        AssertDeterministicHashCodeForStructBasedValueType<DateTime>(null);
        AssertDeterministicHashCodeForStructBasedValueType<DateTime>(new DateTime(1983, 10, 03));
        AssertDeterministicHashCodeForStructBasedValueType<DateTime>(new DateTime(1988, 02, 16));
        AssertDeterministicHashCodeForStructBasedValueType<DateTime>(new DateTime(2001, 01, 06));
        AssertDeterministicHashCodeForStructBasedValueType<DateTime>(new DateTime(2018, 02, 15));
        AssertDeterministicHashCodeForStructBasedValueType<DateTime>(new DateTime(2020, 06, 05));
        AssertDeterministicHashCodeForStructBasedValueType<DateTime>(DateTime.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<DateTime>(DateTime.MaxValue);

        // DateTimeOffset
        AssertDeterministicHashCodeForStructBasedValueType<DateTimeOffset>(null);
        AssertDeterministicHashCodeForStructBasedValueType<DateTimeOffset>(new DateTime(1928, 04, 11).ToDateTimeOffset());
        AssertDeterministicHashCodeForStructBasedValueType<DateTimeOffset>(new DateTime(1950, 06, 01).ToDateTimeOffset());
        AssertDeterministicHashCodeForStructBasedValueType<DateTimeOffset>(new DateTime(1956, 10, 26).ToDateTimeOffset());
        AssertDeterministicHashCodeForStructBasedValueType<DateTimeOffset>(new DateTime(1956, 12, 28).ToDateTimeOffset());
        AssertDeterministicHashCodeForStructBasedValueType<DateTimeOffset>(new DateTime(1967, 01, 06).ToDateTimeOffset());
        AssertDeterministicHashCodeForStructBasedValueType<DateTimeOffset>(DateTimeOffset.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<DateTimeOffset>(DateTimeOffset.MaxValue);

        // TimeSpan
        AssertDeterministicHashCodeForStructBasedValueType<TimeSpan>(null);
        AssertDeterministicHashCodeForStructBasedValueType<TimeSpan>(TimeSpan.Zero);
        AssertDeterministicHashCodeForStructBasedValueType<TimeSpan>(TimeSpan.FromSeconds(42));
        AssertDeterministicHashCodeForStructBasedValueType<TimeSpan>(TimeSpan.FromSeconds(-42));
        AssertDeterministicHashCodeForStructBasedValueType<TimeSpan>(TimeSpan.MinValue);
        AssertDeterministicHashCodeForStructBasedValueType<TimeSpan>(TimeSpan.MaxValue);

        // Guid
        AssertDeterministicHashCodeForStructBasedValueType<Guid>(null);
        AssertDeterministicHashCodeForStructBasedValueType<Guid>(Guid.Empty);
        AssertDeterministicHashCodeForStructBasedValueType<Guid>(Guid.Parse("d2719b8e-8c1c-4f0a-9c5e-2b1a1b2c3d4e"));
        AssertDeterministicHashCodeForStructBasedValueType<Guid>(Guid.Parse("e5a1b2c3-d4e5-6f7a-8b9c-0d1e2f3a4b5c"));
        AssertDeterministicHashCodeForStructBasedValueType<Guid>(Guid.NewGuid());
    }

    private static void AssertDeterministicHashCodeForStructBasedValueType<T>(T? input) where T : struct
    {
        var expectedHashCode = input?.GetHashCode() ?? 0;
        var actualHashCode = input.GetDeterministicHashCode();

        actualHashCode.Should().Be(expectedHashCode);
    }
}
