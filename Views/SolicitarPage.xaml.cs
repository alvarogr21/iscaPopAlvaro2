using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;
using System.Net.Mail;
using System.Net;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
[QueryProperty(nameof(Material), "MaterialSelected")]
public partial class SolicitarPage : Base.BasePage
{
	private SolicitarVM vm;

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
        set { SetProperty(ref material, value); vm.assignDadesMaterial(material); }
    }

    private Solicitud solicitud;
    public Solicitud Solicitud
    {
        get { return solicitud; }
        set { SetProperty(ref solicitud, value); vm.assignDades(solicitud); }
    }

    public SolicitarPage()
	{
        InitializeComponent();
        BindingContext = vm = new SolicitarVM();
        vm.assignDadesOrganisme(Organisme);
        vm.assignDades(Solicitud);
        vm.assignDadesMaterial(Material);
    }

    private void SolicitarClick(object sender, EventArgs e)
    {
        int cantidad = Convert.ToInt32(txtCantidad.Text);
        DateTime momento = DateTime.Now;
        Solicitud sol = new Solicitud();
        sol.cantidad = cantidad;
        sol.momento = momento;
        sol.organisme = Organisme;
        sol.material = Material;
        Solicitud = sol;
        vm.insertSolicitud(Solicitud);
        Material.stock = Material.stock - Convert.ToInt32(txtCantidad.Text);
        vm.modificarMaterial();
        enviarCorreoElectronico();
    }

    private void enviarCorreoElectronico()
    {
        string email = Material.organisme.email;
        string emailPedido = Organisme.email;
                MailAddress addresFrom = new MailAddress("pruebasProyectos123456@gmail.com", "_PrUeBaS_pRoYeCtOs_123456_");
                MailAddress addresTo = new MailAddress(email);
                MailMessage message = new MailMessage(addresFrom, addresTo);

                message.Subject = "Solicitud de material";
                message.IsBodyHtml = true;
                message.Body = "El organismo con cuenta de correo: "+emailPedido+" ha solicitado "+Solicitud.cantidad+" unidades sobre el material" +
            material.nom;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("pruebasProyectos123456@gmail.com", "obrc elas rflm gler");

                try
                {
                    smtpClient.Send(message);
                    DisplayAlert("Solicitud realizada", "La solicitud se ha realizado correctamente", "OK");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error en la solicitud", "Ha ocurrdo un error al solicitar el material", "OK");
                }
            
        
    }
}