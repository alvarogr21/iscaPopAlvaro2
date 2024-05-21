using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
[QueryProperty(nameof(String), "Nom")]
[QueryProperty(nameof(String), "Uso")]
[QueryProperty(nameof(String), "Descripcio")]
[QueryProperty(nameof(EnumEstadoMaterial), "Estat")]

public partial class ListaBusqueda : Base.BasePage
{
    private ListaBusquedaVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDadesOrganisme(Organisme); }
    }

    private string nom;
    public string Nom
    {
        get { return nom; }
        set { SetProperty(ref nom, value); vm.assignDadesNom(nom); }
    }

    private string uso;
    public string Uso
    {
        get { return uso; }
        set { SetProperty(ref uso, value); vm.assignDadesUso(uso); }
    }

    private string descripcio;
    public string Descripcio
    {
        get { return descripcio; }
        set { SetProperty(ref descripcio, value); vm.assignDadesDescripcio(descripcio); }
    }

    private EnumEstadoMaterial estat;
    public EnumEstadoMaterial Estat
    {
        get { return estat; }
        set { SetProperty(ref estat, value); vm.assignDadesEstat(estat); }
    }

    public ListaBusqueda()
	{
		InitializeComponent();
        BindingContext = vm = new ListaBusquedaVM();
        vm.assignDadesOrganisme(Organisme);
        vm.assignDadesNom(Nom);
        vm.assignDadesUso(Uso);
        vm.assignDadesDescripcio(Descripcio);
        vm.assignDadesEstat(Estat);
        Loaded += OnLoad;
    }
    private void OnLoad(object? sender, EventArgs e)
    {
        vm.getMaterialesNoOrganisme();
    }

    private void MaterialSeleccionado(object sender, ItemTappedEventArgs e)
    {

    }
}