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
    public string codigoCentro;
    private LoginVM vm;

    public LoginPage()
	{
		InitializeComponent();
        BindingContext = vm = new LoginVM();
	}

    private void EnviarCodigoClick(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        int atIndex = email.IndexOf("@");
        string beforeAt = email.Substring(0, atIndex);
        List<Centre> listaCentres = vm.getCentres();
        for(int i = 0; i < listaCentres.Count; i++)
        {
            if (listaCentres[i].codigo == beforeAt)
            {
                codigoCentro = beforeAt;
                generarCodigo();
                MailAddress addresFrom = new MailAddress("pruebasProyectos123456@gmail.com", "_PrUeBaS_pRoYeCtOs_123456_");
                //MailAddress addresTo = new MailAddress(email);
                MailAddress addresTo = new MailAddress("pruebasProyectos123456@gmail.com");
                MailMessage message = new MailMessage(addresFrom, addresTo);

                message.Subject = "C�digo de verificaci�n";
                message.IsBodyHtml = true;
                message.Body = "Tu c�digo de verificaci�n es: " + codi;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("pruebasProyectos123456@gmail.com", "obrc elas rflm gler");

                try
                {
                    smtpClient.Send(message);
                    DisplayAlert("C�digo de verificaci�n enviado", "Se ha enviado un c�digo de verificaci�n a tu direcci�n de correo electr�nico.", "OK");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error al enviar el correo electr�nico", "Ha ocurrdo un error al enviar el correo electr�nico", "OK");
                }
            }
        }
    }

    private async void EntrarClick(object sender, EventArgs e)
    {
        string correo = txtEmail.Text;
        //(bool esValido, int cod) = EsCorreoElectronicoValido(correo);
        //if (esValido)
        //{
        string cod = codi;
        string codigo = codigoCentro;
            string nom = "nombrePrueba";
            Organisme org = new Organisme();
            org.nom = vm.getNomCentre(codigo);
            org.codi = cod;
            org.email = correo;
            if (txtCodi.Text == codi)
            {
                await Shell.Current.GoToAsync($"{nameof(Contrase�aPage)}",
                 new Dictionary<string, object>
                 {
                     
                     { "Organisme", org }
                 }
                );
            }
            else
            {
                DisplayAlert("C�digo de verificaci�n erroneo", "El codigo de verificaci�n introducido no es correcto", "OK");
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
        // Dividir la cadena en dos partes en funci�n del car�cter '@'
        string[] partes = correo.Split('@');
        int cod = Convert.ToInt32(partes[0]);

        if (partes.Length == 2 && partes[0].Length > 0)
        {
            string[] partesDespuesArroba = partes[1].Split('.');
            if (partesDespuesArroba.Length == 3 && partesDespuesArroba[0] == "edu" && partesDespuesArroba[1] == "gva" && partesDespuesArroba[2] == "es")
                
            {
                return (true, cod); // La cadena comienza con un formato de correo electr�nico v�lido
            }
        }
        
        return (false,0); // La cadena no comienza con un formato de correo electr�nico�v�lido
����}

}