using iscaPopAlvaro.Dao;
using iscaPopAlvaro.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.ViewModel
{
    public class PerfilVM : Base.BaseViewModel
    {

        private OrganismeDAO orgDAO;

        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }


        public PerfilVM()
        {
            orgDAO = new OrganismeDAO();
        }

        internal void assignDades(Organisme org)
        {
            this.Organisme = org;
        }

        public void modificarOrganisme()
        {
            orgDAO.modificarOrganisme(this.Organisme);
        }

        public void eliminarOrganisme()
        {
            orgDAO.eliminarOrganisme(this.Organisme);
        }

        
    }
}
