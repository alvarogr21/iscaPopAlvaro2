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
    public class ListaBusquedaVM : Base.BaseViewModel
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

        private string _nom;

        public string Nom { get { return _nom; } set { SetProperty(ref _nom, value); } }

        private string _uso;

        public string Uso { get { return _uso; } set { SetProperty(ref _uso, value); } }

        private string _descripcio;

        public string Descripcio { get { return _descripcio; } set { SetProperty(ref _descripcio, value); } }

        private EnumEstadoMaterial _estat;

        public EnumEstadoMaterial Estat { get { return _estat; } set { SetProperty(ref _estat, value); } }

        public ListaBusquedaVM()
        {
            matDAO = new MaterialDAO();
        }

        internal void assignDadesOrganisme(Organisme org)
        {
            this.Organisme = org;
        }
        internal void assignDadesMaterial(Material mat)
        {
            this.Material = mat;
        }

        internal void getMaterialesOfOrganisme()
        {
            this.ListaMateriales = new ObservableCollection<Material>(matDAO.getMaterialesDeOrganisme(Organisme));
        }

        internal void assignDadesNom(string nom)
        {
            this.Nom = nom;
        }

        internal void assignDadesUso(string uso)
        {
            this.Uso = uso;
        }

        internal void assignDadesDescripcio(string descripcio)
        {
            this.Descripcio = descripcio;
        }

        internal void assignDadesEstat(EnumEstadoMaterial estat)
        {
            this.Estat = estat;
        }

        internal void getMaterialesNoOrganisme()
        {
            this.ListaMateriales = new ObservableCollection<Material>(matDAO.getMaterialesNoOrganisme(Nom, Descripcio, Uso, Estat, Organisme));
        }

    }
}
