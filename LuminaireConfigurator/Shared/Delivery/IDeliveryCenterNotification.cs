using LuminaireConfigurator.Shared.Model;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Shared.Delivery
{
  public interface IDeliveryCenterNotification
  {
    Task OnConfigurationDelivered(LuminaireConfiguration configuration);
  }
}
