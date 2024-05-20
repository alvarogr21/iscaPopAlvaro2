using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
public partial class ListaMaterialesPage : Base.BasePage
{
	private ListaMaterialesVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDades(Organisme); }
    }

    private Material material;
    public Material Material
    {
        get { return material; }
        set { SetProperty(ref material, value); vm.assignDadesMaterial(Material); }
    }
    public ListaMaterialesPage()
	{
        InitializeComponent();
        BindingContext = vm = new ListaMaterialesVM();
        vm.assignDades(Organisme);
        vm.assignDadesMaterial(Material);
        Loaded += OnLoad;
        
    }

    private void OnLoad(object? sender, EventArgs e)
    {
        vm.getMaterialesOfOrganisme(Organisme);
    }

    private async void MaterialSeleccionado(object sender, ItemTappedEventArgs e)
    {
        Material mat = e.Item as Material;
        await Shell.Current.GoToAsync($"{nameof(MaterialPage)}",
             new Dictionary<string, object>
             {
                 { "OrganismeSelected", Organisme },
                 { "MaterialSelected", mat }
             }
            );
    }

    private async void AñadirClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(MaterialPage)}",
             new Dictionary<string, object>
             {
                 { "OrganismeSelected", Organisme },
                 { "MaterialSelected", null }
             }
            );
    }
}