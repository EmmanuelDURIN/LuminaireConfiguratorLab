using LuminaireConfigurator.Client.Services;
using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Pages
{
  public partial class ItemsProviderDemo
  {
    [Inject]
    public ILuminaireConfigurationService? LuminaireConfigurationService { get; set; }
    private async ValueTask<ItemsProviderResult<LuminaireConfiguration>> LoadConfigurations(ItemsProviderRequest request)
    {
      if (LuminaireConfigurationService == null)
        throw new NullReferenceException(nameof(LuminaireConfigurationService));
      (LuminaireConfiguration[]? luminaireConfigurations, int totalConfigurations) =
      await LuminaireConfigurationService.GetRangeWithDelay(request.StartIndex, request.Count, request.CancellationToken);
      return new ItemsProviderResult<LuminaireConfiguration>(luminaireConfigurations ?? new LuminaireConfiguration[0], totalConfigurations);
    }
  }
}
