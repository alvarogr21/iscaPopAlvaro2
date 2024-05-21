using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
public partial class SeleccionarCaracteristicasPage : Base.BasePage
{
    private SeleccionarCaracteristicasVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDadesOrganisme(Organisme); }
    }
    public SeleccionarCaracteristicasPage()
	{
		InitializeComponent();
        BindingContext = vm = new SeleccionarCaracteristicasVM();
        vm.assignDadesOrganisme(Organisme);
    }
    private async void BuscarClick(object sender, EventArgs e)
    {
        String nom = txtNom.Text;
        String uso = txtUso.Text;
        String descripcio = txtDescripcio.Text;
        EnumEstadoMaterial estat = (EnumEstadoMaterial)Enum.Parse(typeof(EnumEstadoMaterial), (string)pickerEstat.SelectedItem);
        await Shell.Current.GoToAsync($"{nameof(ListaBusqueda)}",
             new Dictionary<string, object>
             {
                 { "OrganismeSelected", Organisme },
                 { "Nom", nom },
                 { "Uso", uso },
                 { "Descripcio", descripcio },
                 { "Estat", estat }
             }
            );
    }
}