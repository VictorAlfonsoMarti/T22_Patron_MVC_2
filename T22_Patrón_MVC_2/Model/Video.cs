using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T22_Patrón_MVC_2.Model
{
    class Video
    {
        public void Post(string DB, string tabla, string title, string director, string cli_id)
        {
            // método para crear tuplas

            // ATRIBUTOS
            string _title;
            string _director;
            string _cli_id;

            // CONSTRUCTORES
            // si no hay nada, asignamos a null
            if (title == "") { _title = null; } else { _title = title; }
            if (director == "") { _director = null; } else { _director = director; }
            if (cli_id == "") { _cli_id = null; } else { _cli_id = cli_id; }


            // conectamos a la base de datos
            SqlConnection conexion = DB_Connection.DB_Connection.DB_Connexion_Open(DB);

            // codigoSQL
            string cadena = "INSERT INTO " + tabla + " VALUES ('" + _title + "', '" + _director + "', " + _cli_id + ")";

            try
            {
                // creamos el objeto con el codigo sql y la conexion
                SqlCommand comando = new SqlCommand(cadena, conexion);

                // ejecutamos el codigo sql en el objeto comando
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro insertado con éxito");
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
            finally
            {
                // cerramos la conexión con la base de datos creada
                conexion.Close();
            }
        }
        public DataTable Get(string DB, string tabla)
        {
            // método para leer todas las tuplas 

            //ATRIBUTOS
            DataTable lista = new DataTable();

            // conectamos a la base de datos
            SqlConnection conexion = DB_Connection.DB_Connection.DB_Connexion_Open(DB);

            // codigoSQL
            string cadena = "SELECT * FROM " + tabla;

            try
            {
                // ejecutamos el codigo sql con la conexion
                SqlDataAdapter codigo = new SqlDataAdapter(cadena, conexion);

                // llenamos la tabla con la devolucion
                codigo.Fill(lista);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
            finally
            {
                // cerramos la conexión con la base de datos creada
                conexion.Close();
            }

            // retornamos la lista
            return lista;

        }
        public DataTable Get_Id(string DB, string tabla, int id)
        {
            // método para leer todas las tuplas por id 

            // ATRIBUTOS
            DataTable lista = new DataTable();

            // conectamos a la base de datos
            SqlConnection conexion = DB_Connection.DB_Connection.DB_Connexion_Open(DB);
            // codigoSQL
            string cadena = "SELECT * FROM " + tabla + " WHERE id = " + id;

            try
            {
                // ejecutamos el codigo sql con la conexion
                SqlDataAdapter codigo = new SqlDataAdapter(cadena, conexion);

                // llenamos la tabla con la devolucion
                codigo.Fill(lista);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
            finally
            {
                // cerramos la conexión con la base de datos creada
                conexion.Close();
            }

            // retornamos la lista
            return lista;

        }
        public void Put(string DB, string tabla, string title, string director, string cli_id, int id)
        {
            // método para actualizar tuplas por id

            // ATRIBUTOS
            string _title;
            string _director;
            string _cli_id;

            // CONSTRUCTORES
            // si no hay nada, asignamos a null
            if (title == "") { _title = null; } else { _title = title; }
            if (director == "") { _director = null; } else { _director = director; }
            if (cli_id == "") { _cli_id = null; } else { _cli_id = cli_id; }


            // conectamos a la base de datos
            SqlConnection conexion = DB_Connection.DB_Connection.DB_Connexion_Open(DB);

            // codigoSQL
            string cadena = "UPDATE " + tabla + " SET title = '" + _title + "', director = '" + _director + "', cli_id = " + _cli_id + " WHERE id = " + id;

            try
            {
                // creamos el objeto con el codigo sql y la conexion
                SqlCommand comando = new SqlCommand(cadena, conexion);

                // ejecutamos el codigo sql en el objeto comando
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado con éxito");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // cerramos la conexión con la base de datos creada
                conexion.Close();
            }
        }
        public void Delete(string DB, string tabla, int id)
        {
            // método para eliminar tuplas por id

            // conectamos a la base de datos
            SqlConnection conexion = DB_Connection.DB_Connection.DB_Connexion_Open(DB);

            // codigoSQL
            string cadena = "DELETE FROM " + tabla + " WHERE id = " + id;

            try
            {
                // creamos el objeto con el codigo sql y la conexion
                SqlCommand comando = new SqlCommand(cadena, conexion);

                // ejecutamos el codigo sql en el objeto comando
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado con éxito");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // cerramos la conexión con la base de datos creada
                conexion.Close();
            }
        }
    }
}
