using Newtonsoft.Json;
namespace Pokedex.Models
{
    public class PokemonSpeciesListResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonSpeciesListItem> Results { get; set; }
    }

    public class PokemonSpeciesListItem
    {
        public string Name { get; set; }
        public string Url { get; set; }

        // Propiedad calculada para obtener el Id desde la URL
        [JsonIgnore]
        public int Id
        {
            get
            {
                // Ejemplo de Url: "https://pokeapi.co/api/v2/pokemon-species/1/"
                var segments = Url.TrimEnd('/').Split('/');
                if (int.TryParse(segments.Last(), out int id))
                    return id;
                return 0;
            }
        }

        // Propiedad calculada para obtener la URL de la imagen
        [JsonIgnore]
        public string ImageUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
    }
}