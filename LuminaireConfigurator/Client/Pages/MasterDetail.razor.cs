using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator.Client.Pages
{
  public partial class MasterDetail
  {
    private LuminaireConfiguration selectedConfiguration;
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
  }
}
