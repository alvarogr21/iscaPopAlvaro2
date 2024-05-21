namespace iscaPopAlvaro
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.OpcionesPage), typeof(Views.OpcionesPage));
            Routing.RegisterRoute(nameof(Views.IniciarSesionPage), typeof(Views.IniciarSesionPage));
            Routing.RegisterRoute(nameof(Views.LoginPage), typeof(Views.LoginPage));
            Routing.RegisterRoute(nameof(Views.ContraseñaPage), typeof(Views.ContraseñaPage));
            Routing.RegisterRoute(nameof(Views.ControlPage), typeof(Views.ControlPage));
            Routing.RegisterRoute(nameof(Views.PerfilPage), typeof(Views.PerfilPage));
            Routing.RegisterRoute(nameof(Views.MaterialPage), typeof(Views.MaterialPage));
            Routing.RegisterRoute(nameof(Views.HacerFotoPage), typeof(Views.HacerFotoPage));
            Routing.RegisterRoute(nameof(Views.ListaMaterialesPage), typeof(Views.ListaMaterialesPage));
            Routing.RegisterRoute(nameof(Views.SeleccionarCaracteristicasPage), typeof(Views.SeleccionarCaracteristicasPage));
            Routing.RegisterRoute(nameof(Views.ListaBusqueda), typeof(Views.ListaBusqueda));

        }
    }
}
