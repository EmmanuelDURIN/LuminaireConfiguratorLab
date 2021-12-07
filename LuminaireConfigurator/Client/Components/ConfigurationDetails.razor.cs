using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Components
{
  public partial class ConfigurationDetails : ComponentBase
  {
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    private int id;
    [Parameter]
    public int Id { get => id; set => id = value; }
    private LuminaireConfiguration? configuration;
    [Parameter]
    public LuminaireConfiguration? Configuration
    {
      get => configuration;
      set
      {
        if (configuration != value)
        {
          configuration = value;
          ConfigurationChanged.InvokeAsync();
        }
      }
    }
    [Parameter]
    public EventCallback<LuminaireConfiguration> ConfigurationChanged { get; set; }
    public ConfigurationDetails()
    {
    }
    public override async Task SetParametersAsync(ParameterView parameters)
    {
      await base.SetParametersAsync(parameters);
    }
    protected override Task OnParametersSetAsync()
    {
      return base.OnParametersSetAsync();
    }
  }
}
