using System;
using System.Windows.Forms;

namespace Clave5_Grupo6
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

            Application.Run(new frmCliente());        /*Aqui cambiamos el orden en que se van a ejecutar los formularios
                                                       * ya que como tenemos varios queremos que se llene primero el de clientes 
                                                       * porque ahí está la primera relación entre el dui de la tabla cliente y las demas 
                                                       * tablas*/


        }
    }
}
