using Playground.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IPokemonService, PokemonService>(client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
});

builder.Services.AddCors(option =>
{
    option.AddPolicy(name: "AllowSpecificOrigin", policy => policy.WithOrigins("https://localhost:7080").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
