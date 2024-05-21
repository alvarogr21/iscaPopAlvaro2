using iscaPopAlvaro.Dao;
using iscaPopAlvaro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.ViewModel
{
    public class SeleccionarCaracteristicasVM : Base.BaseViewModel
    {
        private MaterialDAO materialDAO;

        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        public SeleccionarCaracteristicasVM()
        {
            materialDAO = new MaterialDAO();
        }

        internal void assignDadesOrganisme(Organisme org)
        {
            this.Organisme = org;
        }
    }
}
