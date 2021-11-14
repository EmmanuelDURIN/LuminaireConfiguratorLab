using LuminaireConfigurator.Client.Services;
using LuminaireConfigurator.Shared.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Pages
{
  public partial class ConfigurationList
  {
    private List<LuminaireConfiguration> luminaireConfigurations;
    public List<LuminaireConfiguration> LuminaireConfigurations {
      get => luminaireConfigurations; 
      set => luminaireConfigurations = value; 
    }
    protected override async Task OnInitializedAsync()
    {
      LuminaireConfigurationService luminaireConfigurationService = new LuminaireConfigurationService();
      LuminaireConfigurations = await luminaireConfigurationService.GetLuminaireConfigurations();
    }
  }
}
