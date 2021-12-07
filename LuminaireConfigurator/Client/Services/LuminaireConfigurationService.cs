using LuminaireConfigurator.Shared.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
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
    public async Task<LuminaireConfiguration?> GetLuminaireConfigurationById(int id)
    {
      if (HttpClient != null)
        return await HttpClient.GetFromJsonAsync<LuminaireConfiguration>(BaseUri + "/" + id);
      return null;
    }
    public async Task<List<LuminaireConfiguration>?> GetLuminaireConfigurations()
    {
      if (HttpClient != null)
        return await HttpClient.GetFromJsonAsync<List<LuminaireConfiguration>>(BaseUri);
      return null;
    }

    public async Task<(LuminaireConfiguration[]? configurations, int totalConfigurations)>
           GetRangeWithDelay(int startIndex, int count, CancellationToken cancellationToken)
    {
      await Task.Delay(1000);
      return await GetRange(startIndex, count, cancellationToken);
    }
    public async Task<(LuminaireConfiguration[]? configurations, int totalForeCasts)>
        GetRange(int startIndex, int count, CancellationToken cancellationToken)
    {
      int totalConfigurations = await HttpClient.GetFromJsonAsync<int>("LuminaireConfiguration/count");
      var numConfigurations = Math.Min(count, totalConfigurations - startIndex);
      LuminaireConfiguration[]? luminaireConfigurations = new LuminaireConfiguration[0];
      try
      {
        if (HttpClient != null)
          luminaireConfigurations = await HttpClient.GetFromJsonAsync<LuminaireConfiguration[]>
              (
              $"LuminaireConfiguration/range?startIndex={startIndex}&numConfigurations={numConfigurations}"
              , cancellationToken
              );

      }
      catch (TaskCanceledException)
      {
        Console.WriteLine("Task cancelled");
      }
      catch (OperationCanceledException)
      {
        Console.WriteLine("Operation cancelled");
      }
      Console.WriteLine($"returning from {startIndex} to {startIndex + numConfigurations}");
      return (luminaireConfigurations, totalConfigurations);
    }
    public async Task PostAsync(LuminaireConfiguration lumConf)
    {
      await HttpClient.PostAsJsonAsync(BaseUri, lumConf);
    }
  }
}
