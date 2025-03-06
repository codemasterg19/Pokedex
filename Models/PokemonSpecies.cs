using Newtonsoft.Json;


namespace Pokedex.Models
{
    public class PokemonSpecies
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("base_happiness")]
        public int BaseHappiness { get; set; }

        [JsonProperty("capture_rate")]
        public int CaptureRate { get; set; }

        [JsonProperty("is_legendary")]
        public bool IsLegendary { get; set; }

        public NamedAPIResource Color { get; set; }
        public NamedAPIResource Habitat { get; set; }
        public NamedAPIResource Shape { get; set; }

        [JsonProperty("flavor_text_entries")]
        public List<FlavorTextEntry> FlavorTextEntries { get; set; }


        [JsonIgnore]
        public string ImageUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";

 
        [JsonIgnore]
        public string SpanishFlavorText
        {
            get
            {
                var entry = FlavorTextEntries?.FirstOrDefault(f => f.Language.Name == "es");
                return entry?.FlavorText.Replace("\n", " ").Replace("\f", " ") ?? "Sin descripción disponible.";
            }
        }
    }

    public class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }
        public NamedAPIResource Language { get; set; }
    }


    public class NamedAPIResource
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
