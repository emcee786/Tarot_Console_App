using System.Text.Json.Serialization;
// Maps JSON keys to C# Class properties, similar to Pydantic

namespace TarotReader
{
    public class TarotApiResponse
    {
        [JsonPropertyName("cards")]
        public List<TarotCardDto> Cards { get; set; } = new();
    }

    public class TarotCardDto
    // dto data transfer object
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("meaning_up")]
        public string MeaningUpright { get; set; } = string.Empty;

        [JsonPropertyName("meaning_rev")]
        public string MeaningReversed { get; set; } = string.Empty;
    }
}
