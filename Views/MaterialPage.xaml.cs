using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
[QueryProperty(nameof(Material), "MaterialSelected")]
public partial class MaterialPage : Base.BasePage
{
	private MaterialVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDadesOrganisme(Organisme); }
    }

    private Material material;
    public Material Material
    {
        get { return material; }
        set { SetProperty(ref material, value); vm.assignDades(material); }
    }



    public MaterialPage()
	{
		InitializeComponent();
        BindingContext = vm = new MaterialVM();
        vm.assignDadesOrganisme(Organisme);
        vm.assignDades(Material);
        Loaded += OnLoad;
        
	}

    private void OnLoad(object? sender, EventArgs e)
    {
        if (Material != null)
        {
            btnAñadir.IsEnabled = false;
            btnEliminar.IsEnabled = true;
            btnModificar.IsEnabled = true;
        }
        else
        {
            btnAñadir.IsEnabled = true;
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
        }
    }

    private async void HacerFotoClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(HacerFotoPage)}",
             new Dictionary<string, object>
             {
                 { "Material", Material }
             }
            );
    }

    private void AñadirClick(object sender, EventArgs e)
    {
        string nom = txtNom.Text;
        string uso = txtUso.Text;
        string descripcio = txtDescripcio.Text;
        int stock = Convert.ToInt32(txtStock.Text);
        EnumEstadoMaterial estat = (EnumEstadoMaterial)Enum.Parse(typeof(EnumEstadoMaterial), (string)pickerEstat.SelectedItem);
        Material mat = new Material();
        mat.nom = nom;
        mat.uso = uso;
        mat.descripcio = descripcio;
        mat.stock = stock;
        mat.estat = estat;
        mat.organisme = Organisme;
        Material = mat;
        vm.insertMaterial(Material);
        Organisme.materialsCollection.Add(mat);
        vm.assignDadesOrganisme(Organisme);
    }

    private void ModificarClick(object sender, EventArgs e)
    {
        string nom = txtNom.Text;
        string uso = txtUso.Text;
        string descripcio = txtDescripcio.Text;
        int stock = Convert.ToInt32(txtStock.Text);
        EnumEstadoMaterial estat = (EnumEstadoMaterial)Enum.Parse(typeof(EnumEstadoMaterial), (string)pickerEstat.SelectedItem);
        Material.nom = nom;
        Material.uso = uso;
        Material.descripcio = descripcio;
        Material.stock = stock;
        Material.estat = estat;
        vm.modificarMaterial();
    }

    private void EliminarClick(object sender, EventArgs e)
    {
        vm.eliminarMaterial();
    }
}