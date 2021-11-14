﻿using LuminaireConfigurator.Shared.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Services
{
  public class LuminaireConfigurationService
  {
    public Task<List<LuminaireConfiguration>> GetLuminaireConfigurations()
    {
      return Task.FromResult(
            new List<LuminaireConfiguration>()
            {
              new LuminaireConfiguration
              {
                CreationTime = new DateTime(2020,11,8),
                LampColor = 5400,
                LampFlux = 2000,
                Optic = "OM10",
                Name="Luminaires Nanterre"
              },
              new LuminaireConfiguration
              {
                CreationTime = new DateTime(2020,12,9),
                LampColor = 5700,
                LampFlux = 3000,
                Optic = "OM11",
                Name="Luminaires Courbevoie"
              },
              new LuminaireConfiguration
              {
                CreationTime = new DateTime(2021,1,4),
                LampColor = 5700,
                LampFlux = 10000,
                Optic = "OM12",
                Name="Luminaires Puteaux"
              },
            }
        );
    }
  }
}
