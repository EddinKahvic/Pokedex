using Fluxor;

namespace Playground.Stores.Pokemon;

public static class PokemonReducer
{
    [ReducerMethod]
    public static PokemonState ReduceFetchPokemonResultAction(PokemonState state, FetchPokemonResultAction action)
    {
        return state with { PokemonList = action.PokemonList, IsLoading = false };
    }
}
