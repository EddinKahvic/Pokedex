using Playground.Server.DTOs;
using Playground.Server.Models;
using System.Text.Json;

namespace Playground.Server.Services;

public interface IPokemonService
{
    Task<List<PokemonDTO>> GetPokemonAsync();
}

public class PokemonService : IPokemonService
{
    private readonly HttpClient _httpClient;

    public PokemonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PokemonDTO>> GetPokemonAsync()
    {
        List<PokemonDTO> pokemonList = new List<PokemonDTO>();
        // Only the original 151 pokemon are to be displayed, otherwise return
        for (var i = 1; i < 152; i++)
        {
            var response = await _httpClient.GetAsync(i.ToString());

            if (response.IsSuccessStatusCode)
            {
                var pokemon = JsonSerializer.Deserialize<PokemonModel>(await response.Content.ReadAsStreamAsync());
                pokemonList.Add(new PokemonDTO { Id = pokemon!.Id, Name = pokemon.Name, Sprite = pokemon?.Sprites?.Front_default }); 
            }
        } 
        return pokemonList;
    }
}