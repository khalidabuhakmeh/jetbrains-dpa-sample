namespace PerformanceIssues.Models;

public record Fruit(string Name, string Color, int WeightInOunces)
{
    public static List<Fruit> All =
    [
        new Fruit("Apple", "Red", 6),
        new Fruit("Banana", "Yellow", 4),
        new Fruit("Orange", "Orange", 5),
        new Fruit("Grape", "Purple", 1),
        new Fruit("Strawberry", "Red", 0),
        new Fruit("Pineapple", "Brown", 45),
        new Fruit("Mango", "Orange", 12),
        new Fruit("Blueberry", "Blue", 0),
        new Fruit("Watermelon", "Green", 144),
        new Fruit("Peach", "Pink", 6),
        new Fruit("Cherry", "Red", 0),
        new Fruit("Pear", "Green", 5),
        new Fruit("Plum", "Purple", 4),
        new Fruit("Lemon", "Yellow", 5),
        new Fruit("Lime", "Green", 2),
        new Fruit("Kiwi", "Brown", 5),
        new Fruit("Avocado", "Green", 8),
        new Fruit("Pomegranate", "Red", 12),
        new Fruit("Tangerine", "Orange", 4),
        new Fruit("Coconut", "Brown", 40)
    ];
}