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
    public class ListaMaterialesVM : Base.BaseViewModel
    {
        private MaterialDAO matDAO;

        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        private Material _material;
        public Material Material { get { return _material; } set { SetProperty(ref _material, value); } }

        private ObservableCollection<Material> _listaMateriales;
        public ObservableCollection<Material> ListaMateriales
        {
            get { return _listaMateriales; }
            set { SetProperty(ref _listaMateriales, value); }
        }

        public ListaMaterialesVM()
        {
            matDAO = new MaterialDAO();
        }

        internal void assignDades(Organisme org)
        {
            this.Organisme = org;
        }
        internal void assignDadesMaterial(Material mat)
        {
            this.Material = mat;
        }

        internal void getMaterialesOfOrganisme(Organisme org)
        {
            this.ListaMateriales = new ObservableCollection<Material>(matDAO.getMaterialesDeOrganisme(Organisme));
        }
    }
}
