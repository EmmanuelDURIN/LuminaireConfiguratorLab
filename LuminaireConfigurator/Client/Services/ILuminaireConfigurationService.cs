using LuminaireConfigurator.Shared.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Services
{
  public interface ILuminaireConfigurationService
  {
    Task<LuminaireConfiguration> GetLuminaireConfigurationById(int id);
    Task<List<LuminaireConfiguration>> GetLuminaireConfigurations();
    Task<(LuminaireConfiguration[] configurations, int totalConfigurations)>
           GetRangeWithDelay(int startIndex, int count, CancellationToken cancellationToken);
    Task<(LuminaireConfiguration[] configurations, int totalForeCasts)>
      GetRange(int startIndex, int count, CancellationToken cancellationToken);
  }
}