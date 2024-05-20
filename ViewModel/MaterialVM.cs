using iscaPopAlvaro.Dao;
using iscaPopAlvaro.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.ViewModel
{
    public class MaterialVM :Base.BaseViewModel
    {
        private MaterialDAO materialDAO;

        private Organisme _organisme;
        public Organisme Organisme { get { return _organisme; } set { SetProperty(ref _organisme, value); } }

        private Material _material;
        public Material Material { get { return _material; } set { SetProperty(ref _material, value); } }

        public MaterialVM() 
        { 
            materialDAO = new MaterialDAO();
        }
        internal void assignDadesOrganisme(Organisme org)
        {
            this.Organisme = org;
        }

        internal void assignDades(Material mat)
        {
            this.Material = mat;
        }

        internal void insertMaterial(Material material)
        {
            materialDAO.insertarMaterial(material);
        }

        public void modificarMaterial()
        {
            materialDAO.modificarMaterial(this.Material);
        }

        public void eliminarMaterial()
        {
            materialDAO.deleteMaterial(this.Material);
        }
    }
}
