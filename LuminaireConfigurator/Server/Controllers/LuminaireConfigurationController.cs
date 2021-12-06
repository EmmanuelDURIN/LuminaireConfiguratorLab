﻿using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuminaireConfigurator.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class LuminaireConfigurationController : ControllerBase
  {
    private static List<LuminaireConfiguration> luminaireConfigurations = new List<LuminaireConfiguration>()
            {
              new LuminaireConfiguration
              {
                Id=1,
                CreationTime = new DateTime(2020,11,8),
                LampColor = 5400,
                LampFlux = 2000,
                Optic = "OM10",
                Name="Luminaires Nanterre"
              },
              new LuminaireConfiguration
              {
                Id=2,
                CreationTime = new DateTime(2020,12,9),
                LampColor = 5700,
                LampFlux = 3000,
                Optic = "OM11",
                Name="Luminaires Courbevoie"
              },
              new LuminaireConfiguration
              {
                Id=3,
                CreationTime = new DateTime(2021,1,4),
                LampColor = 5700,
                LampFlux = 10000,
                Optic = "OM12",
                Name="Luminaires Puteaux"
              },
            };
    private readonly ILogger<LuminaireConfigurationController> _logger;

    public LuminaireConfigurationController(ILogger<LuminaireConfigurationController> logger)
    {
      _logger = logger;
    }
    [HttpGet]
    public IEnumerable<LuminaireConfiguration> Get()
    {
      return luminaireConfigurations;
    }
    [HttpGet("{id}")]
    public ActionResult<LuminaireConfiguration> GetById(int id)
    {
      LuminaireConfiguration lumConf = luminaireConfigurations.FirstOrDefault(l => l.Id == id);
      if (lumConf == null)
        return NotFound("No Luminaire with id=" + id);
      return Ok(lumConf);
    }
    [HttpPost]
    public ActionResult<LuminaireConfiguration> Post(LuminaireConfiguration luminaireConfiguration)
    {
      int id = luminaireConfigurations.Max(l => l.Id);
      luminaireConfiguration.Id = id + 1;
      luminaireConfigurations.Add(luminaireConfiguration);
      return Created(nameof(LuminaireConfiguration)+ "/"+id, luminaireConfiguration);
    }
  }
}