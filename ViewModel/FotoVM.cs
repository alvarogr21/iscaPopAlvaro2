using iscaPopAlvaro.Dao;
using iscaPopAlvaro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.ViewModel
{
    public class FotoVM : Base.BaseViewModel
    {
        private FotoDAO fotoDAO;
        private Material _material;
        public Material Material { get { return _material; } set { SetProperty(ref _material, value); } }

        private Foto _foto;
        public Foto Foto { get { return _foto; } set { SetProperty(ref _foto, value); } }

        internal void assignDadesMaterial(Material material)
        {
            this.Material = material;
        }

        public FotoVM()
        {
            fotoDAO = new FotoDAO();
        }

        internal void insertarFoto(Foto foto)
        {
            fotoDAO.insertarFoto(foto);
        }

        internal void assignDades(Foto foto)
        {
            this.Foto = foto;
        }
    }
}
