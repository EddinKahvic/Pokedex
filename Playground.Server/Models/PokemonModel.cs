using System.Text.Json.Serialization;

namespace Playground.Server.Models;

public class PokemonModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("sprites")]
    public PokemonSprites? Sprites { get; set; }
}

public class PokemonSprites
{
    [JsonPropertyName("front_default")]
    public string? Front_default {  get; set; }
}
