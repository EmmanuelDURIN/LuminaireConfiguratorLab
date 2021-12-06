using LuminaireConfigurator.Client.Services;
using LuminaireConfigurator.Shared.Delivery;
using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Pages
{
  public partial class DeliveryCenter
  {
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private List<LuminaireConfiguration> luminaireConfigurations = new();
    public List<LuminaireConfiguration> LuminaireConfigurations
    {
      get { return luminaireConfigurations; }
      set
      {
        if (luminaireConfigurations != value)
        {
          luminaireConfigurations = value;
          LuminaireConfigurationsChanged.InvokeAsync(value);
        }
      }
    }
    [Parameter]
    public EventCallback<List<LuminaireConfiguration>> LuminaireConfigurationsChanged { get; set; }

    private LuminaireConfiguration selectedConfiguration;
    public LuminaireConfiguration SelectedConfiguration
    {
      get { return selectedConfiguration; }
      set
      {
        //System.Console.WriteLine("Selected Configuration1");
        if (selectedConfiguration != value)
        {
          selectedConfiguration = value;
          //System.Console.WriteLine("Selected Configuration2");
          SelectedConfigurationChanged.InvokeAsync(value);
        }
      }
    }
    [Parameter]
    public EventCallback<LuminaireConfiguration> SelectedConfigurationChanged { get; set; }

    protected async Task Deliver()
    {
      if (SelectedConfiguration != null)
      {
        luminaireConfigurations.Remove(SelectedConfiguration);
        await hubConnection.SendAsync("ConfigurationDelivered", SelectedConfiguration);
        System.Console.WriteLine("delivered");
      }
    }
    protected override async Task OnInitializedAsync()
    {
      await ConnectToHub();
      luminaireConfigurations = await hubConnection.InvokeAsync<List<LuminaireConfiguration>>("GetDeliveries");
      await base.OnInitializedAsync();
    }
    private HubConnection? hubConnection = null;
    private async Task ConnectToHub()
    {
      hubConnection = new HubConnectionBuilder()
          .WithUrl(NavigationManager.ToAbsoluteUri("/deliverycenterhub"))
          .Build();
      hubConnection.On<LuminaireConfiguration>(nameof(IDeliveryCenterNotification.OnConfigurationDelivered),
        (lumConf) =>
        {
          System.Console.WriteLine("Client got delivery removed");
          LuminaireConfigurations.Remove(lumConf);
          StateHasChanged();
        });
      await hubConnection.StartAsync();
    }
  }
}
