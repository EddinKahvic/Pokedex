using Microsoft.AspNetCore.Mvc;
using Playground.Server.DTOs;
using Playground.Server.Services;

namespace Playground.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public async Task<ActionResult<PokemonDTO>> GetPokemon()
    {
        var pokemon = await _pokemonService.GetPokemonAsync();

        if (pokemon is null)
        {
            return NotFound();
        }
        return Ok(pokemon);
    }
}
