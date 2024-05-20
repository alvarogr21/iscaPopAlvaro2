using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;
using SQLite;

namespace iscaPopAlvaro.Views;

public partial class IniciarSesionPage : Base.BasePage
{
	private IniciarSesionVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDades(Organisme); }
    }
    public IniciarSesionPage()
	{
		InitializeComponent();
		BindingContext = vm = new IniciarSesionVM();
	}

    private async void EntrarClick(object sender, EventArgs e)
    {
		string email = txtEmail.Text;
		string contrase�a = txtContrase�a.Text;
		Organisme = vm.buscarCuenta(email, contrase�a);
        if(organisme == null )
        {
            DisplayAlert("Cuenta no encontrada", "Los valores introducidos no coindicen con ning�n usuario", "OK");
        }
        else
        {
            await Shell.Current.GoToAsync($"{nameof(ControlPage)}",
                 new Dictionary<string, object>
                 {

                     { "Organisme", Organisme }
                 }
                );
        }
    }
}