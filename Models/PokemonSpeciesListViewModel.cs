using Pokedex.Models;

namespace Pokedex.ViewModels
{
    public class PokemonSpeciesListViewModel
    {
        public List<PokemonSpeciesListItem> Species { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}
