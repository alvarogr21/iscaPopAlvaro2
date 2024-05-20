using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
public partial class PerfilPage : Base.BasePage
{
    private PerfilVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDades(Organisme); }
    }

    
    public PerfilPage()
	{
        InitializeComponent();
        BindingContext = vm = new PerfilVM();
        vm.assignDades(Organisme);
    }

    private void ModificarPerfil(object sender, EventArgs e)
    {
        string nom = txtNomPerfil.Text;
        string email = txtEmailPerfil.Text;
        string contraseña = txtPasswordPerfil.Text;
        Organisme.nom = nom;
        Organisme.email = email;
        Organisme.password = contraseña;
        vm.modificarOrganisme();
    }

    private void EliminarPerfil(object sender, EventArgs e)
    {
        vm.eliminarOrganisme();
    }

    private void CancelarCambios(object sender, EventArgs e)
    {
        this.Navigation.PopModalAsync();
    }
}