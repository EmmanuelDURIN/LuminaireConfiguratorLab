﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LuminaireConfigurator.ViewModel
{
  public class LuminaireConfiguration
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Optic { get; set; } //= "OM10";
    [Range(1, 1E10)]
    public double LampFlux { get; set; } = 5000;
    [Range(1, 1E6)]
    [Required]
    public int LampColor { get; set; }// = 5400;
  }
}
