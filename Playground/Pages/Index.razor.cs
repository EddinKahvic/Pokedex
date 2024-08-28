using Playground.Stores.Pokemon;

namespace Playground.Pages;

public partial class Index
{
    protected override Task OnInitializedAsync()
    {
        Dispatcher.Dispatch(new FetchPokemonAction());
        return base.OnInitializedAsync();
    }
}
