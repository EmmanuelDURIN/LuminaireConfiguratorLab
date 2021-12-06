using LuminaireConfigurator.Shared.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Services
{
  public interface ILuminaireConfigurationService
  {
    Task<LuminaireConfiguration> GetLuminaireConfigurationById(int id);
    Task<List<LuminaireConfiguration>> GetLuminaireConfigurations();
    Task PostAsync(LuminaireConfiguration lumConf);
  }
}