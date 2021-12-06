using LuminaireConfigurator.Shared.Model;
using System.Collections.Generic;

namespace LuminaireConfigurator.Shared.Delivery
{
  public interface IDeliveryCenterHub
    {
        void ConfigurationDelivered(LuminaireConfiguration configuration);
        List<LuminaireConfiguration> GetDeliveries();
    }
}