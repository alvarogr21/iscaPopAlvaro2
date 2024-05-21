using iscaPopAlvaro.Dao;
using iscaPopAlvaro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.ViewModel
{
    public class LoginVM : Base.BaseViewModel
    {
        private CentresDAO centresDAO;
        //private String email;
        private OrganismeDAO organismeDAO;

        private Organisme _organisme;
        public Organisme Organisme
        {
            get { return _organisme; }
            set { SetProperty(ref _organisme, value); }
        }

        public LoginVM() 
        {
            organismeDAO = new OrganismeDAO();
            centresDAO = new CentresDAO();
            //Organisme = organismeDAO.getOrganismeByEmail(email);

        }

        public List<Centre> getCentres()
        {
            return centresDAO.getAllCentres();
        }

        public string getNomCentre(string codigo)
        {
            return centresDAO.buscarCuenta(codigo);
        }


    }
}
