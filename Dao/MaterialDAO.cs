using iscaPopAlvaro.BaseDades;
using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.Dao
{
    public class MaterialDAO
    {
        

        public MaterialDAO() { }

        public void insertarMaterial(Material material)
        {
            BaseDatos.GetConnection().InsertWithChildrenAsync(material);
        }

        public void modificarMaterial(Material material)
        {
            BaseDatos.GetConnection().UpdateWithChildrenAsync(material);
        }

        public void deleteMaterial(Material material)
        {
            BaseDatos.GetConnection().DeleteAsync(material);
        }

        public List<Material> getMaterialesDeOrganisme(Organisme org) 
        {
            List<Material> materials = new List<Material>();
            List<Material> materialsOfOrganisme = new List<Material>();
            materials = BaseDatos.GetConnection().GetAllWithChildrenAsync<Material>().Result;
            foreach (Material material in materials)
            {
                if(material.organisme.id == org.id)
                {
                    materialsOfOrganisme.Add(material);
                }
            }
            return materialsOfOrganisme;
        }

        public List<Material> getAllMateriales()
        {
            List<Material> listaMateriales = BaseDatos.GetConnection().GetAllWithChildrenAsync<Material>().Result;
            return listaMateriales;
        }
    }
}
