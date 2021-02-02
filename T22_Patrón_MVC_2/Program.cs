using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using T22_Patrón_MVC_2.Controller;
using T22_Patrón_MVC_2.View;

namespace T22_Patrón_MVC_2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DB_Manager dB_Manager = new DB_Manager();
            Controller.Controller controller = new Controller.Controller();


            controller.dB_Manager_Controller(dB_Manager);
        }
    }
}
