using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Shared.Model
{
  public class LuminaireConfiguration
  {
    public string Name{ get; set; }
    public DateTime CreationTime { get; set; }
    public string Optic { get; set; }
    public double LampFlux { get; set; }
    public int LampColor { get; set; }
  }
}
