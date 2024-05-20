using iscaPopAlvaro.Dao;
using iscaPopAlvaro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.ViewModel
{
    public class IniciarSesionVM : Base.BaseViewModel
    {
        private OrganismeDAO organismeDAO;
        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        public IniciarSesionVM()
        {
            organismeDAO = new OrganismeDAO();
        }
        internal void assignDades(Organisme org)
        {
            this.Organisme = org;
        }

        internal Organisme buscarCuenta(string email, string contraseña)
        {
            return organismeDAO.buscarCuenta(email, contraseña);
        }
    }
}
