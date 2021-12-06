using LuminaireConfigurator.Shared.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Services
{
  public class LuminaireConfigurationService : ILuminaireConfigurationService
  {
    public HttpClient HttpClient { get; set; }
    public const string BaseUri = nameof(LuminaireConfiguration);
    public LuminaireConfigurationService(HttpClient httpClient)
    {
      this.HttpClient = httpClient;
    }
    public async Task<LuminaireConfiguration> GetLuminaireConfigurationById(int id)
    {
      return await HttpClient.GetFromJsonAsync<LuminaireConfiguration>(BaseUri + "/" + id);
    }
    public async Task<List<LuminaireConfiguration>> GetLuminaireConfigurations()
    {
      return await HttpClient.GetFromJsonAsync<List<LuminaireConfiguration>>(BaseUri);
    }
    public async Task PostAsync(LuminaireConfiguration lumConf)
    {
      await HttpClient.PostAsJsonAsync(BaseUri, lumConf);
    }
  }
}
