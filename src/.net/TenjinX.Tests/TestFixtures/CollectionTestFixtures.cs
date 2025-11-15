namespace TenjinX.Tests.TestFixtures;

public static class CollectionTestFixtures
{
    public static IEnumerable<int> PartialNumberEnumerable =>
    [
        1,
        2,
        3,
        4,
        5
    ];

    public static IEnumerable<int> AdditionalNumberEnumerable =>
    [
        6,
        7,
        8,
        9,
        10
    ];

    public static IEnumerable<int> FullNumberEnumerable =>
    [
        .. PartialNumberEnumerable,
        .. AdditionalNumberEnumerable
    ];

    public static IEnumerable<string> PartialFruitEnumerable =>
    [
        "Apple",
        "Banana",
        "Cherry"
    ];

    public static IEnumerable<string> AdditionalFruitEnumerable =>
    [
        "Date",
        "Elderberry",
        "Fig",
        "Grape"
    ];

    public static IEnumerable<string> FullFruitEnumerable =>
    [
        .. PartialFruitEnumerable,
        .. AdditionalFruitEnumerable
    ];

    public static ICollection<string> PartialFruitCollection => [.. PartialFruitEnumerable];
    public static ICollection<string> FullFruitCollection => [.. FullFruitEnumerable];

    public static IDictionary<int, string> PartialFruitDictionary => new Dictionary<int, string>
    {
        [1] = "Apple",
        [2] = "Banana",
        [3] = "Cherry"
    };

    public static IDictionary<int, string> FullFruitDictionary => new Dictionary<int, string>
    {
        [1] = "Apple",
        [2] = "Banana",
        [3] = "Cherry",
        [4] = "Date",
        [5] = "Elderberry",
        [6] = "Fig",
        [7] = "Grape"
    };
}
