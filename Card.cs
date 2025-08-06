
namespace TarotReader
{
    public class Card
    {
        public string Name { get; set; } = string.Empty;
        public string MeaningUpright { get; set; } = string.Empty;
        public string MeaningReversed { get; set; } = string.Empty;



        public Card(string name, string meaningUpright, string meaningReversed)
        {
            Name = name;
            MeaningUpright = meaningUpright;
            MeaningReversed = meaningReversed;
        }

        public override string ToString()
        {
            return $"Card: {Name}\nUpright Meaning: {MeaningUpright}\nReversed Meaning: {MeaningReversed}\n";
        }
    }
}