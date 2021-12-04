using LuminaireConfigurator.Client.Services;
using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Pages
{
  public partial class ConfigurationDetails
  {
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    private int id;
    [Parameter]
    public int Id { get => id; set => id = value; }
    private LuminaireConfiguration configuration;
    public LuminaireConfiguration Configuration
    {
      get => configuration;
      set => configuration = value;
    }
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
    protected async override Task OnInitializedAsync()
    {
      Configuration = await LuminaireConfigurationService.GetLuminaireConfigurationById(Id);
      if (Configuration == null)
        NavigationManager.NavigateTo("NotFound");
    }
  }
}
