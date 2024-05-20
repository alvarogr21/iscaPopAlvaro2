using iscaPopAlvaro.Config;
using iscaPopAlvaro.Model;
using Microsoft.Maui.Controls.Shapes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.BaseDades
{
    public class BaseDatos
    {
        private static SQLiteAsyncConnection connection;


        static BaseDatos()
        {
            //CreaTablasAsync();
        }

        public static SQLiteAsyncConnection GetConnection()
        {
            if (connection is not null)
            {
                return connection;
            }
            else
            {
                connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
                return connection;
            }
        }
        /*
        public static void CreaTablasAsync()
        {
            GetConnection().DropTableAsync<Foto>().Wait();
            GetConnection().DropTableAsync<Material>().Wait();
            GetConnection().DropTableAsync<Organisme>().Wait();
            GetConnection().DropTableAsync<Solicitud>().Wait();

            GetConnection().CreateTableAsync<Foto>().Wait();
            GetConnection().CreateTableAsync<Material>().Wait();
            GetConnection().CreateTableAsync<Organisme>().Wait();
            GetConnection().CreateTableAsync<Solicitud>().Wait();

        }
        */
    }
}
