using Fluxor;
using Playground.Models;
using System.Net.Http.Json;

namespace Playground.Stores.Pokemon;

public class PokemonEffect(HttpClient http)
{
    [EffectMethod(typeof(FetchPokemonAction))]
    public async Task HandleFetchPokemonAction(IDispatcher dispatcher)
    {
        var response = await http.GetAsync($"https://localhost:7027/Pokemon/");

        if (response.IsSuccessStatusCode)
        {
            List<PokemonModel> pokemonList = await response.Content.ReadFromJsonAsync<List<PokemonModel>>() ?? [];

            dispatcher.Dispatch(new FetchPokemonResultAction(pokemonList));
        }
    }
}