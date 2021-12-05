using LuminaireConfigurator.Client.Services;
using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Pages
{
  public partial class ItemsProviderDemo
  {
    [Inject]
    public ILuminaireConfigurationService LuminaireConfigurationService { get; set; }
    private async ValueTask<ItemsProviderResult<LuminaireConfiguration>> LoadConfigurations(ItemsProviderRequest request)
    {
      (LuminaireConfiguration[] foreCasts, int totalForeCasts) =
        await LuminaireConfigurationService.GetRangeWithDelay(request.StartIndex, request.Count, request.CancellationToken);
      return new ItemsProviderResult<LuminaireConfiguration>(foreCasts, totalForeCasts);
    }
  }
}
