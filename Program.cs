using System;
using TarotReader;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to the Tarot Card Reader!");
        Console.WriteLine("**********************************");

        Deck deck = new Deck();
        await deck.InitializeDeckAsync(); // Load cards from the API

        while (true)
        {
            Console.WriteLine("\n What would you like to do?");
            Console.WriteLine("1. Shuffle and Draw Cards");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice (1 or 2): ");
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    PerformReading(deck);
                    break;
                case "2":
                    Console.WriteLine("Thank you for using the Tarot Card Reader. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

            }
        }
    }

    public static void PerformReading(Deck deck)
    {
        deck.Shuffle();

        Console.Write("How many cards would you like to draw? (e.g., 1, 3, 5): ");
        if (int.TryParse(Console.ReadLine(), out int numCards) && numCards > 0)
        {
            var drawnCards = deck.DrawCards(numCards);

            if (drawnCards.Count > 0)
            {
                Console.WriteLine($"\n--- Your {numCards}-Card Reading ---");
                foreach (var card in drawnCards)
                {
                    bool reversed = deck.IsCardReversed();
                    Console.WriteLine($"\nCard: {card.Name}");
                    Console.WriteLine($"Orientation: {(reversed ? "Reversed" : "Upright")}");
                    Console.WriteLine($"Meaning: {(reversed ? card.MeaningReversed : card.MeaningUpright)}");
                    Console.WriteLine("------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No cards were drawn. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}
            
