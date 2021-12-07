using LuminaireConfigurator.Shared.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Services
{
  public class OpticService
  {
    private List<Optic> optics = new List<Optic>()
            {
              new Optic
              {
                Id=1,
                Name="OM10"
              },
              new Optic
              {
                Id=2,
                Name="OM11"
              },
              new Optic
              {
                Id=3,
                Name="ON10"
              },
              new Optic
              {
                Id=4,
                Name="ON11"
              },
              new Optic
              {
                Id=5,
                Name="OL10"
              },
              new Optic
              {
                Id=6,
                Name="OL11"
              },
            };
    public Optic? GetLuminaireConfigurationById(int id)
    {
      return optics.FirstOrDefault(lc => lc.Id == id);
    }
    public async Task<List<Optic>> GetOptics()
    {
      await Task.Delay(10);
      return optics;
    }
  }
}
