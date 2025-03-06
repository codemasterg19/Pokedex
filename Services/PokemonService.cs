using Pokedex.Models;
using Newtonsoft.Json;

namespace Pokedex.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtiene una lista de especies (limitada a 100)
        public async Task<List<PokemonSpeciesListItem>> GetPokemonSpeciesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon-species?limit=400");
            var speciesListResponse = JsonConvert.DeserializeObject<PokemonSpeciesListResponse>(response);
            return speciesListResponse?.Results ?? new List<PokemonSpeciesListItem>();
        }

        // Obtiene los detalles de una especie por nombre
        public async Task<PokemonSpecies> GetPokemonSpeciesAsync(string name)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon-species/{name}");
            var species = JsonConvert.DeserializeObject<PokemonSpecies>(response);
            return species;
        }
    }
}