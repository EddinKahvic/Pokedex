using Fluxor;
using Playground.Models;

namespace Playground.Stores.Pokemon;

[FeatureState]
public record PokemonState
{
    public List<PokemonModel> PokemonList { get; init; }
    public bool IsLoading { get; init; }

    public PokemonState() {
        PokemonList = new List<PokemonModel>();
        IsLoading = true;
    }
}


