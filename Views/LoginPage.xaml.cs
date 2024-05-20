using iscaPopAlvaro.BaseDades;
using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace iscaPopAlvaro.Views;

public partial class LoginPage : Base.BasePage
{
    public string codi;
    private LoginVM vm;

    public LoginPage()
	{
		InitializeComponent();
        BindingContext = vm = new LoginVM();
	}

    private void EnviarCodigoClick(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        generarCodigo();
        MailAddress addresFrom = new MailAddress("pruebasProyectos123456@gmail.com", "_PrUeBaS_pRoYeCtOs_123456_");
        MailAddress addresTo = new MailAddress(email);
        MailMessage message = new MailMessage(addresFrom, addresTo);
        
        message.Subject = "Código de verificación";
        message.IsBodyHtml = true;
        message.Body = "Tu código de verificación es: " + codi;

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("pruebasProyectos123456@gmail.com", "obrc elas rflm gler");


        /*
    // Configurar el cliente SMTP para enviar el correo electrónico
    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
    smtpClient.Port = 587;
    smtpClient.Credentials = new NetworkCredential("pruebasProyectos123456@gmail.com", "_PrUeBaS_pRoYeCtOs_123456_");
    smtpClient.EnableSsl = true;

    // Configurar el mensaje de correo electrónico
    MailMessage mailMessage = new MailMessage();
    mailMessage.From = new MailAddress("pruebasProyectos123456@gmail.com");
    mailMessage.To.Add(email);
    mailMessage.Subject = "Código de verificación";
    mailMessage.Body = "Tu código de verificación es: " + codi;
        */
        // Enviar el correo electrónico
        try
        { 
            smtpClient.Send(message);
            DisplayAlert("Código de verificación enviado", "Se ha enviado un código de verificación a tu dirección de correo electrónico.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error al enviar el correo electrónico", "Ha ocurrdo un error al enviar el correo electrónico", "OK");
        }
    }

    private async void EntrarClick(object sender, EventArgs e)
    {
        string correo = txtEmail.Text;
        //(bool esValido, int cod) = EsCorreoElectronicoValido(correo);
        //if (esValido)
        //{
        string cod = codi;
            string nom = "nombrePrueba";
            Organisme org = new Organisme();
            org.nom = nom;
            org.codi = cod;
            org.email = correo;
            if (txtCodi.Text == codi)
            {
                await Shell.Current.GoToAsync($"{nameof(ContraseñaPage)}",
                 new Dictionary<string, object>
                 {
                     
                     { "Organisme", org }
                 }
                );
            }
            else
            {
                DisplayAlert("Código de verificación erroneo", "El codigo de verificación introducido no es correcto", "OK");
            }
        //}
        //else
        //{
        //    DisplayAlert("Correo no valido", "El correo introducido no es valido.", "OK");
        //}

        
    }

    private void generarCodigo()
    {
        string codigo="";
        int num = 0;
        Random random = new Random();
        for(int i = 0; i < 4; i++)
        {
            num = random.Next(10);
            int numLetra = random.Next(26);
            string letra="";
            switch(numLetra) 
            { 
                case 0:
                    letra = "A";
                    break;
                case 1:
                    letra = "B";
                    break;
                case 2:
                    letra = "C";
                    break;
                case 3:
                    letra = "D";
                    break;
                case 4:
                    letra = "E";
                    break;
                case 5:
                    letra = "F";
                    break;
                case 6:
                    letra = "G";
                    break;
                case 7:
                    letra = "H";
                    break;
                case 8:
                    letra = "I";
                    break;
                case 9:
                    letra = "J";
                    break;
                case 10:
                    letra = "K";
                    break;
                case 11:
                    letra = "L";
                    break;
                case 12:
                    letra = "M";
                    break;
                case 13:
                    letra = "N";
                    break;
                case 14:
                    letra = "O";
                    break;
                case 15:
                    letra = "P";
                    break;
                case 16:
                    letra = "Q";
                    break;
                case 17:
                    letra = "R";
                    break;
                case 18:
                    letra = "S";
                    break;
                case 19:
                    letra = "T";
                    break;
                case 20:
                    letra = "U";
                    break;
                case 21:
                    letra = "V";
                    break;
                case 22:
                    letra = "W";
                    break;
                case 23:
                    letra = "X";
                    break;
                case 24:
                    letra = "Y";
                    break;
                case 25:
                    letra = "Z";
                    break;
            }
            int minOMay = random.Next(2);
            switch (minOMay)
            {
                case 0:
                    letra = letra.ToLower(); break;
                case 1:
                    letra = letra.ToUpper(); break;
            }
            codigo += letra;
            codigo += num.ToString();
        }
        codi = codigo;
    }
    private static (bool, int) EsCorreoElectronicoValido(string correo)
    {
        // Dividir la cadena en dos partes en función del carácter '@'
        string[] partes = correo.Split('@');
        int cod = Convert.ToInt32(partes[0]);

        if (partes.Length == 2 && partes[0].Length > 0)
        {
            string[] partesDespuesArroba = partes[1].Split('.');
            if (partesDespuesArroba.Length == 3 && partesDespuesArroba[0] == "edu" && partesDespuesArroba[1] == "gva" && partesDespuesArroba[2] == "es")
                
            {
                return (true, cod); // La cadena comienza con un formato de correo electrónico válido
            }
        }
        
        return (false,0); // La cadena no comienza con un formato de correo electrónico válido
    }

}