using LuminaireConfigurator.Server.Controllers;
using LuminaireConfigurator.Shared.Delivery;
using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace LuminaireConfigurator.Server.Hubs
{
  public class DeliveryCenterHub : Hub<IDeliveryCenterNotification>, IDeliveryCenterHub
  {
    public List<LuminaireConfiguration> GetDeliveries()
    {
      return LuminaireConfigurationController.LuminaireConfigurations;
    }
    public void ConfigurationDelivered(LuminaireConfiguration configuration)
    {
      LuminaireConfigurationController.LuminaireConfigurations.Remove(configuration);
      System.Console.WriteLine("Call made on server");
      // code to call OnConfigurationDelivered on client side
      // through SignalR
      Clients.AllExcept(this.Context.ConnectionId).OnConfigurationDelivered(configuration);
    }
  }
}
