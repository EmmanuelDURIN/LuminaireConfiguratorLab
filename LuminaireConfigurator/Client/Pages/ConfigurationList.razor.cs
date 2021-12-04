using LuminaireConfigurator.Client.Services;
using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Pages
{
  public partial class ConfigurationList
  {
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
