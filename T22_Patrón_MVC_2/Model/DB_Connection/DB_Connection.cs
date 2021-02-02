using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T22_Patrón_MVC_2.Model.DB_Connection
{
    class DB_Connection
    {
        /*
        *  Clase para cerrar y abrir conexion con  el servidor y la base de datos.
        * 
        * 
        */
        public static SqlConnection DB_Connexion_Open(string BD)
        {
            // establece conexion con la base de datos pasada por parametro.
            SqlConnection conexion = new SqlConnection("Data Source=192.168.1.205;Initial Catalog=" + BD + ";Persist Security Info=True;User ID=victor;Password=victor");
            try
            {
                conexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return conexion;
        }
    }
}
