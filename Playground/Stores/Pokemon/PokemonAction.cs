using Playground.Models;

namespace Playground.Stores.Pokemon;

public record FetchPokemonAction();

public record FetchPokemonResultAction(List<PokemonModel> PokemonList);


