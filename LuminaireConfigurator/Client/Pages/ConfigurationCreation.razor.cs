using LuminaireConfigurator.Client.Services;
using LuminaireConfigurator.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuminaireConfigurator.Client.Pages
{
  public partial class ConfigurationCreation
  {
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    [Inject]
    public ILuminaireConfigurationService? LuminaireConfigurationService { get; set; }
    public ViewModel.LuminaireConfiguration Configuration { get; set; } = new ViewModel.LuminaireConfiguration();
    public int[] LampColors { get; set; } = new int[] { 2200, 2700, 3000, 4000, 5700 };
    public List<Optic> Optics { get; set; } = new List<Optic>();
    public bool IsModified { get => EditContext?.IsModified() == true; }
    public EditContext? EditContext { get; set; }
    private ValidationMessageStore? messageStore;
    protected async override Task OnInitializedAsync()
    {
      var opticService = new OpticService();
      Optics = await opticService.GetOptics();
      await base.OnInitializedAsync();
    }
    protected override void OnInitialized()
    {
      EditContext = new(Configuration);
      EditContext.OnValidationRequested += HandleValidationRequested;
      EditContext.OnFieldChanged += EditContextFieldChanged;
      messageStore = new(EditContext);
    }
    private void EditContextFieldChanged(object? sender, FieldChangedEventArgs e)
    {
    }
    private void HandleValidationRequested(object? sender, ValidationRequestedEventArgs args)
    {
      messageStore?.Clear();
      // Custom validation logic
      // example of pseudo DB/Web api call
      //bool isNameValid = true; 
      //if (isNameValid && Configuration != null)
      //{$
      //object o = new object();
      //messageStore?.Add(() => o, "Configuration name must be unique.");
      //}
    }
    private void HandleValidSubmit()
    {
      Console.WriteLine("HandleValidSubmit called: Processing the form");
      //Logger.LogInformation("HandleValidSubmit called: Processing the form");
    }
    public async Task Create()
    {
      var lumConf = new LuminaireConfiguration
      {
        CreationTime = DateTime.Now,
        LampColor = Configuration.LampColor,
        Optic = Configuration.Optic.Name,
        LampFlux = Configuration.LampFlux,
        Name = Configuration.Name
      };
      if (LuminaireConfigurationService != null)
        await LuminaireConfigurationService.PostAsync(lumConf);
      NavigationManager?.NavigateTo("masterdetail");
      Console.WriteLine("configuration created");
    }
    public void Dispose()
    {
      if (EditContext is not null)
      {
        EditContext.OnValidationRequested -= HandleValidationRequested;
      }
    }
  }
}