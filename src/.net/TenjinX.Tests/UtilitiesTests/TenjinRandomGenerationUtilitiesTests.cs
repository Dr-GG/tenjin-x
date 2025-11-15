using FluentAssertions;
using System.Text.RegularExpressions;
using TenjinX.Exceptions.Random;
using TenjinX.Models.Random;
using TenjinX.Utilities;

namespace TenjinX.Tests.UtilitiesTests;

public static class TenjinRandomGenerationUtilitiesTests
{
    private const int TestIterations = 10000;
    private const int DistinctThreshold = TestIterations / 10;
    private const string DefaultAllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private static readonly int RandomSeed = Guid.NewGuid().GetHashCode();
    private static readonly Regex AllowedCharactersRegex = new($"^[{Regex.Escape(DefaultAllowedCharacters)}]*$");

    [Theory]
    [InlineData(10.0, 3.0)]
    [InlineData(10.0, 10.0)]
    public static void GetRandomDouble_WhenParametersAreInvalid_ShouldThrowException
    (
        double? minimumValue,
        double? maximumValue
    )
    {
        var parameters = new TenjinRandomGenerationParameters
        {
            MinimumDouble = minimumValue,
            MaximumDouble = maximumValue,
        };
        var act = () => TenjinRandomGenerationUtilities.GetRandomDouble(parameters);

        act.Should().Throw<TenjinRandomGenerationException>();
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData(0.0, null)]
    [InlineData(null, 1.0)]
    [InlineData(0.2, 0.8)]
    public static void GetRandomDouble_WhenParametersAreValid_ShouldGenerateRandomDoubles
    (
        double? minimumValue,
        double? maximumValue
    )
    {
        var finalMinimumValue = minimumValue ?? TenjinRandomGenerationUtilities.MinimumDouble;
        var finalMaximumValue = maximumValue ?? TenjinRandomGenerationUtilities.MaximumDouble;
        var parameters = new TenjinRandomGenerationParameters
        {
            MinimumDouble = minimumValue,
            MaximumDouble = maximumValue,
        };

        RunDoubleRandomTests(finalMinimumValue, finalMaximumValue, parameters);
    }

    [Fact]
    public static void GetRandomDouble_WhenUsingTheSameRandom_ShouldGenerateTheSameDoubles()
    {
        var parameters1 = new TenjinRandomGenerationParameters
        {
            Random = new Random(RandomSeed)
        };
        var parameters2 = new TenjinRandomGenerationParameters
        {
            Random = new Random(RandomSeed)
        };
        var firstRunValues = RunDoubleRandomTests
        (
            TenjinRandomGenerationUtilities.MinimumDouble,
            TenjinRandomGenerationUtilities.MaximumDouble,
            parameters1
        ).ToList();
        var secondRunValues = RunDoubleRandomTests
        (
            TenjinRandomGenerationUtilities.MinimumDouble,
            TenjinRandomGenerationUtilities.MaximumDouble,
            parameters2
        ).ToList();

        firstRunValues.Should().BeEquivalentTo(secondRunValues);
    }

    [Fact]
    public static void GetRandomDouble_WhenUsingTheSameSeed_ShouldGenerateTheSameValues()
    {
        var parameters = new TenjinRandomGenerationParameters
        {
            Seed = RandomSeed
        };
        var firstRunValues = RunDoubleRandomTests
        (
            TenjinRandomGenerationUtilities.MinimumDouble,
            TenjinRandomGenerationUtilities.MaximumDouble,
            parameters,
            false
        ).ToList();
        var secondRunValues = RunDoubleRandomTests
        (
            TenjinRandomGenerationUtilities.MinimumDouble,
            TenjinRandomGenerationUtilities.MaximumDouble,
            parameters,
            false

        ).ToList();

        firstRunValues.Should().BeEquivalentTo(secondRunValues);
        firstRunValues.Distinct().Count().Should().Be(1);
    }

    [Theory]
    [InlineData(10, 3)]
    [InlineData(10, 10)]
    public static void GetRandomInt32_WhenParametersAreInvalid_ShouldThrowException
    (
        int? minimumValue,
        int? maximumValue
    )
    {
        var parameters = new TenjinRandomGenerationParameters
        {
            MinimumInt32 = minimumValue,
            MaximumInt32 = maximumValue,
        };
        var act = () => TenjinRandomGenerationUtilities.GetRandomInt32(parameters);

        act.Should().Throw<TenjinRandomGenerationException>();
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData(0, null)]
    [InlineData(null, 9999999)]
    [InlineData(-9999999, 9999999)]
    public static void GetRandomInt32_WhenParametersAreValid_ShouldGenerateRandomDoubles
    (
        int? minimumValue,
        int? maximumValue
    )
    {
        var finalMinimumValue = minimumValue ?? TenjinRandomGenerationUtilities.MinimumInt32;
        var finalMaximumValue = maximumValue ?? TenjinRandomGenerationUtilities.MaximumInt32;
        var parameters = new TenjinRandomGenerationParameters
        {
            MinimumInt32 = minimumValue,
            MaximumInt32 = maximumValue,
        };

        RunInt32RandomTests(finalMinimumValue, finalMaximumValue, parameters);
    }

    [Fact]
    public static void GetRandomInt32_WhenUsingTheSameRandom_ShouldGenerateTheSameInts()
    {
        var parameters1 = new TenjinRandomGenerationParameters
        {
            Random = new Random(RandomSeed)
        };
        var parameters2 = new TenjinRandomGenerationParameters
        {
            Random = new Random(RandomSeed)
        };
        var firstRunValues = RunInt32RandomTests
        (
            TenjinRandomGenerationUtilities.MinimumInt32,
            TenjinRandomGenerationUtilities.MaximumInt32,
            parameters1
        ).ToList();
        var secondRunValues = RunInt32RandomTests
        (
            TenjinRandomGenerationUtilities.MinimumInt32,
            TenjinRandomGenerationUtilities.MaximumInt32,
            parameters2
        ).ToList();

        firstRunValues.Should().BeEquivalentTo(secondRunValues);
    }

    [Fact]
    public static void GetRandomInt32_WhenUsingTheSameSeed_ShouldGenerateTheSameValues()
    {
        var parameters = new TenjinRandomGenerationParameters
        {
            Seed = RandomSeed
        };
        var firstRunValues = RunInt32RandomTests
        (
            TenjinRandomGenerationUtilities.MinimumInt32,
            TenjinRandomGenerationUtilities.MaximumInt32,
            parameters,
            false
        ).ToList();
        var secondRunValues = RunInt32RandomTests
        (
            TenjinRandomGenerationUtilities.MinimumInt32,
            TenjinRandomGenerationUtilities.MaximumInt32,
            parameters,
            false

        ).ToList();

        firstRunValues.Should().BeEquivalentTo(secondRunValues);
        firstRunValues.Distinct().Count().Should().Be(1);
    }

    [Fact]
    public static void GetRandomString_WhenAllowedCharactersIsEmpty_ShouldThrowException()
    {
        var parameters = new TenjinRandomGenerationParameters
        {
            AllowedCharacters = string.Empty
        };
        var act = () => TenjinRandomGenerationUtilities.GetRandomString(parameters);

        act.Should().Throw<TenjinRandomGenerationException>();
    }

    [Theory]
    [InlineData(null, null, null)]
    [InlineData(10u, 5u, null)]
    [InlineData(null, 5u, 10u)]
    [InlineData(5u, null, 10u)]
    [InlineData(5u, null, null)]
    [InlineData(null, 5u, null)]
    public static void GetRandomString_WhenLengthParametersAreInvalid_ShouldThrowException
    (
        uint? minimumLength,
        uint? maximumLength,
        uint? length
    )
    {
        var parameters = new TenjinRandomGenerationParameters
        {
            MinimumLength = minimumLength,
            MaximumLength = maximumLength,
            Length = length,
            AllowedCharacters = DefaultAllowedCharacters
        };
        var act = () => TenjinRandomGenerationUtilities.GetRandomString(parameters);

        act.Should().Throw<TenjinRandomGenerationException>();
    }

    [Theory]
    [InlineData(null, null, 10u)]
    [InlineData(5u, 15u, null)]
    [InlineData(25u, 50u, null)]
    [InlineData(5u, 5u, null)]
    public static void GetRandomString_WhenLengthParametersAreValid_ShouldGenerateRandomStrings
    (
        uint? minimumLength,
        uint? maximumLength,
        uint? length
    )
    {
        var finalMinimumLength = (int)(minimumLength ?? length!);
        var finalMaximumLength = (int)(maximumLength ?? length!);
        var parameters = new TenjinRandomGenerationParameters
        {
            MinimumLength = minimumLength,
            MaximumLength = maximumLength,
            Length = length,
            AllowedCharacters = DefaultAllowedCharacters
        };

        RunStringRandomTests(finalMinimumLength, finalMaximumLength, parameters);
    }

    [Fact]
    public static void GetRandomString_WhenUsingTheSameRandom_ShouldGenerateTheSameStrings()
    {
        var parameters1 = new TenjinRandomGenerationParameters
        {
            Random = new Random(RandomSeed),
            Length = 10u,
            AllowedCharacters = DefaultAllowedCharacters
        };
        var parameters2 = new TenjinRandomGenerationParameters
        {
            Random = new Random(RandomSeed),
            Length = 10u,
            AllowedCharacters = DefaultAllowedCharacters
        };
        var firstRunValues = RunStringRandomTests(10, 10, parameters1).ToList();
        var secondRunValues = RunStringRandomTests(10, 10, parameters2).ToList();

        firstRunValues.Should().BeEquivalentTo(secondRunValues);
    }

    [Fact]
    public static void GetRandomString_WhenUsingTheSameSeed_ShouldGenerateTheSameValues()
    {
        var parameters = new TenjinRandomGenerationParameters
        {
            Seed = RandomSeed,
            Length = 10u,
            AllowedCharacters = DefaultAllowedCharacters
        };
        var firstRunValues = RunStringRandomTests
        (
            10,
            10,
            parameters,
            false
        ).ToList();
        var secondRunValues = RunStringRandomTests
        (
            10,
            10,
            parameters,
            false
        ).ToList();

        firstRunValues.Should().BeEquivalentTo(secondRunValues);
        firstRunValues.Distinct().Count().Should().Be(1);
    }

    private static IEnumerable<double> RunDoubleRandomTests
    (
        double expectedMinimumValue,
        double expectedMaximumValue,
        TenjinRandomGenerationParameters parameters,
        bool checkUniqueness = true
    )
    {
        var values = new List<double>();

        for (var i = 0; i < TestIterations; i++)
        {
            var value = TenjinRandomGenerationUtilities.GetRandomDouble(parameters);

            value.Should().BeGreaterThanOrEqualTo(expectedMinimumValue);
            value.Should().BeLessThanOrEqualTo(expectedMaximumValue);

            values.Add(value);
        }

        if (checkUniqueness)
        {
            values.Distinct().Count().Should().BeGreaterThan(DistinctThreshold);
        }

        return values;
    }

    private static IEnumerable<int> RunInt32RandomTests
    (
        int expectedMinimumValue,
        int expectedMaximumValue,
        TenjinRandomGenerationParameters parameters,
        bool checkUniqueness = true
    )
    {
        var values = new List<int>();

        for (var i = 0; i < TestIterations; i++)
        {
            var value = TenjinRandomGenerationUtilities.GetRandomInt32(parameters);

            value.Should().BeGreaterThanOrEqualTo(expectedMinimumValue);
            value.Should().BeLessThanOrEqualTo(expectedMaximumValue);

            values.Add(value);
        }

        if (checkUniqueness)
        {
            values.Distinct().Count().Should().BeGreaterThan(DistinctThreshold);
        }

        return values;
    }

    private static IEnumerable<string> RunStringRandomTests
    (
        int expectedMinimumLength,
        int expectedMaximumLength,
        TenjinRandomGenerationParameters parameters,
        bool checkUniqueness = true
    )
    {
        var values = new List<string>();

        for (var i = 0; i < TestIterations; i++)
        {
            var value = TenjinRandomGenerationUtilities.GetRandomString(parameters);

            values.Add(value);
            value.Length.Should().BeGreaterThanOrEqualTo(expectedMinimumLength);
            value.Length.Should().BeLessThanOrEqualTo(expectedMaximumLength);

            AllowedCharactersRegex.IsMatch(value).Should().BeTrue();
        }

        if (checkUniqueness)
        {
            values.Distinct().Count().Should().BeGreaterThan(DistinctThreshold);
        }

        return values;
    }
}
