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
    public class SolicitudDAO
    {
        public SolicitudDAO()
        {
            
        }

        public void insertarSolicitud(Solicitud solicitud)
        {
            BaseDatos.GetConnection().InsertWithChildrenAsync(solicitud);
        }
    }
}
