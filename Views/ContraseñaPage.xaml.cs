using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Organisme), "Organisme")]
public partial class ContraseñaPage : Base.BasePage
{
    private ContraseñaVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDades(Organisme); }
    }
    public ContraseñaPage()
	{
		InitializeComponent();
        BindingContext = vm = new ContraseñaVM();
        vm.assignDades(Organisme);
    }

    private async void DefinirContraseñaClick(object sender, EventArgs e)
    {
        Organisme.password = txtPassword.Text;
        Organisme.momento = DateTime.Now;
        vm.insertarOrganisme();

        await Shell.Current.GoToAsync($"{nameof(IniciarSesionPage)}");
    }
}