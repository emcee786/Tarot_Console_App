using System;                // Required for Console.WriteLine and Random.
using System.Collections.Generic; // Required for List<Card>.
using System.Net.Http;       // Required for HttpClient (to call the API).
using System.Text.Json;      // Required for JsonSerializer (to parse JSON).
using System.Threading.Tasks;// Required for async/await with Task.

namespace TarotReader
{
    public class Deck
    {
        private List<Card> _cards;
        private Random _random;

        public Deck()
        {
            _cards = new List<Card>();
            _random = new Random();
            
        }


        public async Task InitializeDeckAsync()
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://tarotapi.dev/api/v1/cards");

            var apiResponse = JsonSerializer.Deserialize<TarotApiResponse>(response);

            if (apiResponse?.Cards != null)
            {
                foreach (var tarotCard in apiResponse.Cards)
                {
                    _cards.Add(new Card(tarotCard.Name, tarotCard.MeaningUpright, tarotCard.MeaningReversed));
                }
                Console.WriteLine($"Loaded {_cards.Count} cards from the API.");
            }
            else
            {
                Console.WriteLine("Failed to load cards from API.");
            }
        }

        public void Shuffle()
        {
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
            Console.WriteLine("Deck shuffled!");
        }

        public List<Card> DrawCards(int count)
        {
            if (count > _cards.Count)
            {
                Console.WriteLine("Not enough cards in the deck to draw that many.");
                return new List<Card>();
            }

            List<Card> drawn = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                // Simulate drawing from the top of the shuffled deck
                drawn.Add(_cards[i]);
            }
            // Remove drawn cards from the deck (optional for this simple app)
            _cards.RemoveRange(0, count);
            return drawn;
        }

        public bool IsCardReversed()
        {
            // Simulate a 50/50 chance of a card being reversed
            return _random.Next(2) == 0;
        }
    }
}
