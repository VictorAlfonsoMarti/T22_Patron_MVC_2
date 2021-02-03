using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T22_Patrón_MVC_2.Model;
using System.Windows.Forms;
using T22_Patrón_MVC_2.View;
using T22_Patrón_MVC_2.Model.DB_Connection;
using System.Data.SqlClient;

namespace T22_Patrón_MVC_2.Controller
{
    class Controller
    {
        public void dB_Manager_Controller(DB_Manager dB_Manager)
        {
            // Controlador principal, aplica los eventos en los botones y ejecuta la ventana.


            //EVENTOS
            dB_Manager.buttonListarTablas.Click += (sender, EventArgs) => { textBoxBD_TextChanged(sender, EventArgs, dB_Manager, dB_Manager.textBoxBD.Text); };
            dB_Manager.boton_verTabla.Click += (sender, EventArgs) => { verTabla_Click(sender, EventArgs, dB_Manager.textBoxBD.Text, Convert.ToString(dB_Manager.listBoxTabla.SelectedItem), dB_Manager); };
            dB_Manager.boton_verRegistros.Click += (sender, EventArgs) => { verRegistros_Click(sender, EventArgs, dB_Manager.textBoxBD.Text, Convert.ToString(dB_Manager.listBoxTabla.SelectedItem), dB_Manager); };
            dB_Manager.boton_actualizar.Click += (sender, EventArgs) => { insertar_Click(sender, EventArgs, dB_Manager.textBoxBD.Text, Convert.ToString(dB_Manager.listBoxTabla.SelectedItem), dB_Manager); };
            dB_Manager.boton_eliminar.Click += (sender, EventArgs) => { eliminar_Click(sender, EventArgs, dB_Manager.textBoxBD.Text, Convert.ToString(dB_Manager.listBoxTabla.SelectedItem), dB_Manager); };
            dB_Manager.boton_editar.Click += (sender, EventArgs) => { editarRegistro_Click(sender, EventArgs, dB_Manager.textBoxBD.Text, Convert.ToString(dB_Manager.listBoxTabla.SelectedItem), dB_Manager); };

            // ejecutamos y abrimos la ventana del programa
            Application.Run(dB_Manager);
        }


        public void verTabla_Click(object sender, EventArgs e, string DB, string tabla, DB_Manager dB_Manager)
        {
            // botón para ver toda la tabla

            // ATRIBUTOS
            Cliente conexion = new Cliente(); // conexion al Clienteo
            DataTable datos = conexion.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
            dB_Manager.tabla_clientes.DataSource = datos;
        }

        private void verRegistros_Click(object sender, EventArgs e, string DB, string tabla, DB_Manager dB_Manager)
        {
            // botón para ver registros especificos           
            switch (tabla)
            {
                case "cliente":
                    RegistroCliente registro = new RegistroCliente();
                    // asignamos la vista de mostrar y ejecutamos la ventana 
                    registro.panel_mostrar.Visible = true;
                    // asignamos evento al boton enviar
                    registro.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click(senderB, EventArgs, registro, "ver", DB, tabla, dB_Manager); };
                    registro.Show();
                    break;
                case "videos":
                    RegistroVideo video = new RegistroVideo();
                    // asignamos la vista de mostrar y ejecutamos la ventana 
                    video.panel_mostrar.Visible = true;
                    // asignamos evento al boton enviar
                    video.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click_Video(senderB, EventArgs, video, "ver", DB, tabla, dB_Manager); };
                    video.Show();
                    break;
            }

            // actualizamos la tabla
            verTabla_Click(sender, e, DB, tabla, dB_Manager);
        }

        private void editarRegistro_Click(object sender, EventArgs e, string DB, string tabla, DB_Manager dB_Manager)
        {
            // botón para actualizar registros

            switch (tabla)
            {
                case "cliente":
                    RegistroCliente registro = new RegistroCliente();
                    // asignamos la vista de mostrar y ejecutamos la ventana 
                    registro.panelEditarID.Visible = true;
                    // asignamos evento al boton enviar
                    registro.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click(senderB, EventArgs, registro, "editar", DB, tabla, dB_Manager); };
                    registro.Show();
                    break;
                case "videos":
                    RegistroVideo video = new RegistroVideo();
                    // asignamos la vista de mostrar y ejecutamos la ventana 
                    video.panelEditarID.Visible = true;
                    // asignamos evento al boton enviar
                    video.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click_Video(senderB, EventArgs, video, "editar", DB, tabla, dB_Manager); };
                    video.Show();
                    break;
            }

            // actualizamos la tabla
            verTabla_Click(sender, e, DB, tabla, dB_Manager);
        }

        private void insertar_Click(object sender, EventArgs e, string DB, string tabla, DB_Manager dB_Manager)
        {
            // botón para actualizar registros

            switch (tabla)
            {
                case "cliente":
                    RegistroCliente registro = new RegistroCliente();
                    // asignamos la vista de mostrar y ejecutamos la ventana 
                    registro.panel_anadir.Visible = true;
                    // asignamos evento al boton enviar
                    registro.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click(senderB, EventArgs, registro, "insertar", DB, tabla, dB_Manager); };
                    registro.Show();
                    break;
                case "videos":
                    RegistroVideo video = new RegistroVideo();
                    // asignamos la vista de mostrar y ejecutamos la ventana 
                    video.panel_anadir.Visible = true;
                    // asignamos evento al boton enviar
                    video.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click_Video(senderB, EventArgs, video, "insertar", DB, tabla, dB_Manager); };
                    video.Show();
                    break;
            }

            // actualizamos la tabla
            verTabla_Click(sender, e, DB, tabla, dB_Manager);
        }

        private void eliminar_Click(object sender, EventArgs e, string DB, string tabla, DB_Manager dB_Manager)
        {
            // botón para eliminar registros

            switch (tabla)
            {
                case "cliente":
                    RegistroCliente registro = new RegistroCliente();
                    // asignamos la vista de mostrar y ejecutamos la ventana 
                    registro.panel_eliminar.Visible = true;
                    // asignamos evento al boton enviar
                    registro.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click(senderB, EventArgs, registro, "eliminar", DB, tabla, dB_Manager); };
                    registro.Show();
                    break;
                case "videos":
                    RegistroVideo video = new RegistroVideo();
                    // asignamos la vista de mostrar y ejecutamos la ventana 
                    video.panel_eliminar.Visible = true;
                    // asignamos evento al boton enviar
                    video.boton_enviar.Click += (senderB, EventArgs) => { enviar_Click_Video(senderB, EventArgs, video, "eliminar", DB, tabla, dB_Manager); };
                    video.Show();
                    break;
            }

            // actualizamos la tabla
            verTabla_Click(sender, e, DB, tabla, dB_Manager);

        }

        private void enviar_Click(object sender, EventArgs e, RegistroCliente registro, string accion, string DB, string tabla, DB_Manager dB_Manager)
        {
            // botón para llamar a diferentes métodos dependiendo del evento que quieran hacer

            // ATRIBUTOS
            Cliente Cliente = new Cliente();
            DataTable datos;

            switch (accion)
            {
                case "ver":
                    datos = Cliente.Get_Id(DB, tabla, Convert.ToInt32(registro.textBoxMostrarID.Text)); // guardamos los datos de la BD en un objeto DataTable
                    dB_Manager.tabla_clientes.DataSource = datos; // actualizamos la tabla
                    break;
                case "insertar":
                    Cliente.Post(DB, tabla, registro.textBoxNombre.Text, registro.textBoxApellido.Text, registro.textBoxDireccion.Text, registro.textBoxDNI.Text);
                    datos = Cliente.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
                    dB_Manager.tabla_clientes.DataSource = datos;// actualizamos la tabla
                    break;
                case "editar":
                    Cliente.Put(DB, tabla, registro.textBoxEditarNombre.Text, registro.textBoxEditarApellido.Text, registro.textBoxEditarDireccion.Text, registro.textBoxEditarDNI.Text, Convert.ToInt32(registro.textBoxEditarID.Text));
                    datos = Cliente.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
                    dB_Manager.tabla_clientes.DataSource = datos;// actualizamos la tabla
                    break;
                case "eliminar":
                    Cliente.Delete(DB, tabla, Convert.ToInt32(registro.textBox_EliminarID.Text));
                    datos = Cliente.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
                    dB_Manager.tabla_clientes.DataSource = datos;// actualizamos la tabla
                    break;
            }
        }

        private void enviar_Click_Video(object sender, EventArgs e, RegistroVideo registro, string accion, string DB, string tabla, DB_Manager dB_Manager)
        {
            // botón para llamar a diferentes métodos dependiendo del evento que quieran hacer

            // ATRIBUTOS
            Video video = new Video();
            DataTable datos;

            switch (accion)
            {
                case "ver":
                    datos = video.Get_Id(DB, tabla, Convert.ToInt32(registro.textBoxMostrarID.Text)); // guardamos los datos de la BD en un objeto DataTable
                    dB_Manager.tabla_clientes.DataSource = datos; // actualizamos la tabla
                    break;
                case "insertar":
                    video.Post(DB, tabla, registro.textBoxTitle.Text, registro.textBoxDirector.Text, registro.textBoxClientID.Text);
                    datos = video.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
                    dB_Manager.tabla_clientes.DataSource = datos;// actualizamos la tabla
                    break;
                case "editar":
                    video.Put(DB, tabla, registro.textBoxEditarTitle.Text, registro.textBoxEditarDirector.Text, registro.textBoxEditarClientID.Text, Convert.ToInt32(registro.textBoxEditarID.Text));
                    datos = video.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
                    dB_Manager.tabla_clientes.DataSource = datos;// actualizamos la tabla
                    break;
                case "eliminar":
                    video.Delete(DB, tabla, Convert.ToInt32(registro.textBox_EliminarID.Text));
                    datos = video.Get(DB, tabla); // guardamos los datos de la BD en un objeto DataTable
                    dB_Manager.tabla_clientes.DataSource = datos;// actualizamos la tabla
                    break;
            }
        }

        private void textBoxBD_TextChanged(object sender, EventArgs ev, DB_Manager dB_Manager, string dB_Name)
        {
            // llena el cuadro de tablas con las tablas de una bd

            SqlConnection conexion = DB_Connection.DB_Connexion_Open(dB_Name);

            try
            {
                // recogemos los nombres de las tablas en un objeto
                DataTable dt = conexion.GetSchema("Tables");

                // eliminamos el contenido de la lista
                dB_Manager.listBoxTabla.Items.Clear();

                // por cada nombre en el objeto
                foreach (DataRow row in dt.Rows)
                {
                    // printamos
                    dB_Manager.listBoxTabla.Items.Add((string)row[2]);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
