namespace iscaPopAlvaro.Views;

public partial class OpcionesPage : Base.BasePage
{
	public OpcionesPage()
	{
		InitializeComponent();
	}

    private async void RegistrarseClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
    }

    private async void IniciarSesionClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(IniciarSesionPage)}");
    }
}