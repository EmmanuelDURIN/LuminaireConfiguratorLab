using LuminaireConfigurator.ViewModel;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace LuminaireConfigurator.Client.Pages
{
  public partial class ConfigurationCreation
  {
    public LuminaireConfiguration Configuration { get; set; } = new LuminaireConfiguration();
    public int[] LampColors { get; set; } = new int[] { 2200, 2700, 3000, 4000, 5700 };
    public string[] Optics { get; set; } = new string[] { "ON10", "ON11", "OL10", "OL11", "OM10", "OM11" };
    public bool IsModified { get => EditContext.IsModified(); }
    public EditContext EditContext { get; set; }
    private ValidationMessageStore messageStore;
    protected override void OnInitialized()
    {
      EditContext = new(Configuration);
      EditContext.OnValidationRequested += HandleValidationRequested;
      EditContext.OnFieldChanged += EditContextFieldChanged;
      messageStore = new(EditContext);
    }
    private void EditContextFieldChanged(object sender, FieldChangedEventArgs e)
    {
    }
    private void HandleValidationRequested(object sender, ValidationRequestedEventArgs args)
    {
      messageStore.Clear();
      // Custom validation logic
      //if (!Configuration.Options)
      //{
      //  messageStore?.Add(() => Configuration.Options, "Select at least one.");
      //}
    }
    private void HandleValidSubmit()
    {
      Console.WriteLine("HandleValidSubmit called: Processing the form");
      //Logger.LogInformation("HandleValidSubmit called: Processing the form");
    }
    public void Create()
    {
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