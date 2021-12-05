using LuminaireConfigurator.Client.Services;
using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Components
{
  public partial class ConfigurationList : ComponentBase
  {
    private LuminaireConfiguration selectedConfiguration;
    [Parameter]
    public LuminaireConfiguration SelectedConfiguration
    {
      get { return selectedConfiguration; }
      set
      {
        if (selectedConfiguration != value)
        {
          selectedConfiguration = value;
          SelectedConfigurationChanged.InvokeAsync(value);
        }
      }
    }
    [Parameter]
    public EventCallback<LuminaireConfiguration> SelectedConfigurationChanged { get; set; }
    private List<LuminaireConfiguration> luminaireConfigurations;
    public List<LuminaireConfiguration> LuminaireConfigurations
    {
      get => luminaireConfigurations;
      set => luminaireConfigurations = value;
    }
    [Inject]
    public ILuminaireConfigurationService LuminaireConfigurationService { get; set; }
    protected override async Task OnInitializedAsync()
    {
      LuminaireConfigurations = await LuminaireConfigurationService.GetLuminaireConfigurations();
    }
  }
}
