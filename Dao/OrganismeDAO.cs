using iscaPopAlvaro.BaseDades;
using iscaPopAlvaro.Model;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.Dao
{
    public class OrganismeDAO
    {
        public OrganismeDAO() { }

        /*public Organisme getOrganismeByEmail(string email)
        {
            return BaseDatos.GetConnection().GetAllWithChildrenAsync<Organisme>(o => o.Email.Equals(email)).Result.FirstOrDefault();
        }*/

        public void modificarOrganisme(Organisme organisme)
        {
            BaseDatos.GetConnection().UpdateWithChildrenAsync(organisme);
        }

        public void eliminarOrganisme(Organisme organisme)
        {
            BaseDatos.GetConnection().DeleteAsync(organisme);
        }

        public void insertarOrganisme(Organisme organisme)
        {
            BaseDatos.GetConnection().InsertWithChildrenAsync(organisme);
        }

        public Organisme buscarCuenta(string email, string contraseña)
        {
            Organisme org = BaseDatos.GetConnection().GetAllWithChildrenAsync<Organisme>(o => o.email.Equals(email) && o.password.Equals(contraseña)).Result.FirstOrDefault();
            return org;
        }
    }
}