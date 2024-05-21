using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Organisme), "Organisme")]
public partial class ControlPage : Base.BasePage
{
    private ControlVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; } set { SetProperty(ref organisme, value); vm.assignDades(Organisme); }
    }
    public ControlPage()
	{
		InitializeComponent();
        BindingContext = vm = new ControlVM();
        vm.assignDades(Organisme);

    }

    private async void PerfilClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(PerfilPage)}",
             new Dictionary<string, object>
             {
                 { "OrganismeSelected", Organisme }
             }
            );
    }

    private async void PublicarMaterialClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ListaMaterialesPage)}",
             new Dictionary<string, object>
             {
                 { "OrganismeSelected", Organisme }
             }
            );
    }

    private async void BuscarClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(SeleccionarCaracteristicasPage)}",
             new Dictionary<string, object>
             {
                 { "OrganismeSelected", Organisme }
             }
            );
    }
}