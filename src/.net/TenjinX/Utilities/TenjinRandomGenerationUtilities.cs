using System;
using System.Security.Cryptography;
using System.Text;
using TenjinX.Exceptions.Random;
using TenjinX.Extensions;
using TenjinX.Models.Random;

namespace TenjinX.Utilities;

/// <summary>
/// A collection of methods used for random generation.
/// </summary>
public static class TenjinRandomGenerationUtilities
{
    /// <summary>
    /// The minimum <see cref="int"/> value that can be generated.
    /// </summary>
    public const int MinimumInt32 = int.MinValue;

    /// <summary>
    /// The maximum <see cref="int"/> value that can be generated.
    /// </summary>
    public const int MaximumInt32 = int.MaxValue - 1;

    /// <summary>
    /// The minimum <see cref="double"/> value that can be generated.
    /// </summary>
    public const double MinimumDouble = 0.0;

    /// <summary>
    /// The maximum <see cref="double"/> value that can be generated.
    /// </summary>
    public const double MaximumDouble = 1.0;

    /// <summary>
    /// Generates a random <see cref="double"/>.
    /// </summary>
    public static double GetRandomDouble(TenjinRandomGenerationParameters parameters)
    {
        AssertRandomDoubleGenerationParameters(parameters);

        var random = GetRandom(parameters);
        var minimum = parameters.MinimumDouble ?? MinimumDouble;
        var maximum = parameters.MaximumDouble ?? MaximumDouble;

        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    /// <summary>
    /// Generates a random <see cref="int"/> value.
    /// </summary>
    public static int GetRandomInt32(TenjinRandomGenerationParameters parameters)
    {
        AssertRandomInt32GenerationParameters(parameters);

        var random = GetRandom(parameters);
        var minimum = parameters.MinimumInt32 ?? MinimumInt32;
        var maximum = parameters.MaximumInt32 ?? MaximumInt32;

        return random.Next(minimum, maximum + 1);
    }

    /// <summary>
    /// Generates a random <see cref="string"/>.
    /// </summary>
    public static string GetRandomString(TenjinRandomGenerationParameters parameters)
    {
        AssertRandomStringGenerationParameters(parameters);

        var random = GetRandom(parameters);
        var length = GetRandomLength(parameters, random);
        var output = new StringBuilder((int)length);

        for (var i = 0u; i < length; i++)
        {
            output.Append(GetRandomCharacter(parameters, random));
        }

        return output.ToString();
    }

    private static char GetRandomCharacter(TenjinRandomGenerationParameters parameters, Random random)
    {
        var index = random.Next(0, parameters.AllowedCharacters.Length);

        return parameters.AllowedCharacters[index];
    }

    private static uint GetRandomLength(TenjinRandomGenerationParameters parameters, Random random)
    {
        if (parameters.Length.HasValue)
        {
            return parameters.Length.Value;
        }

        // If this point is reached, both minimum and maximum are guaranteed to be non-null.
        var minimum = parameters.MinimumLength!;
        var maximum = parameters.MaximumLength!;

        return (uint)random.Next((int)minimum, (int)maximum + 1);
    }

#pragma warning disable S2245 // Make sure that using this pseudorandom number generator is safe here.

    private static Random GetRandom(TenjinRandomGenerationParameters parameters)
    {
        if (parameters.Random != null)
        {
            return parameters.Random;
        }

        if (parameters.Seed.HasValue)
        {
            return new Random(parameters.Seed.Value);
        }

        var seedBytes = new byte[16];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(seedBytes);
        }

        var seed = BitConverter.ToInt32(seedBytes, 0);

        return new Random(seed);
    }

#pragma warning restore S2245 // Make sure that using this pseudorandom number generator is safe here.

    private static void AssertRandomDoubleGenerationParameters(TenjinRandomGenerationParameters parameters)
    {
        switch (parameters)
        {
            case { MinimumDouble: not null, MaximumDouble: not null }
            when parameters.MinimumDouble > parameters.MaximumDouble:
                throw new TenjinRandomGenerationException("Minimum double cannot be greater than maximum double.");

            case { MinimumDouble: not null, MaximumDouble: not null }
            when parameters.MinimumDouble.Value.EqualsWithinTolerance(parameters.MaximumDouble.Value):
                throw new TenjinRandomGenerationException("Minimum and maximum double cannot be of the same value.");
        }
    }

    private static void AssertRandomInt32GenerationParameters(TenjinRandomGenerationParameters parameters)
    {
        switch (parameters)
        {
            case { MinimumInt32: not null, MaximumInt32: not null }
            when parameters.MinimumInt32 > parameters.MaximumInt32:
                throw new TenjinRandomGenerationException("Minimum Int32 cannot be greater than maximum Int32.");

            case { MinimumInt32: not null, MaximumInt32: not null }
            when parameters.MinimumInt32.Value == parameters.MaximumInt32.Value:
                throw new TenjinRandomGenerationException("Minimum and maximum Int32 cannot be of the same value.");
        }
    }

    private static void AssertRandomStringGenerationParameters(TenjinRandomGenerationParameters parameters)
    {
        if (parameters.AllowedCharacters.IsNullOrEmpty())
        {
            throw new TenjinRandomGenerationException("AllowedRandomCharacters not allowed to be null or empty.");
        }

        if (
            parameters.MinimumLength == null &&
            parameters.MaximumLength == null &&
            parameters.Length == null
           )
        {
            throw new TenjinRandomGenerationException("Minimum/maximum or fixed lengths must be specified.");
        }

        if (parameters.Length == null &&
           (parameters.MinimumLength == null || parameters.MaximumLength == null))
        {
            throw new TenjinRandomGenerationException("Minimum and maximum length should both be set.");
        }

        if (parameters.Length != null &&
           (parameters.MinimumLength != null || parameters.MaximumLength != null))
        {
            throw new TenjinRandomGenerationException("Minimum and/or maximum and/or fixed lengths were specified.");
        }

        if (parameters.MinimumLength.HasValue &&
            parameters.MinimumLength > parameters.MaximumLength)
        {
            throw new TenjinRandomGenerationException("Minimum length cannot be greater than maximum length.");
        }
    }
}