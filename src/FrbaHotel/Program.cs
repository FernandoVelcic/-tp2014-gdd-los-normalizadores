using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using MyActiveRecord;

namespace FrbaHotel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ConnectionManager.getInstance().connect("Pooling=true;Min Pool Size=5;Max Pool Size=40;Connect Timeout=1;server=" + Config.getInstance().server + ";database=" + Config.getInstance().database + ";Integrated Security=false;User Id=" + Config.getInstance().username + ";Password=" + Config.getInstance().password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede conectar al servidor\r\n" + ex.Message);
                //return;
            }
            
            /*Hoteles hoteles = new Hoteles();
            hoteles.calle = "asdasd";
            hoteles.cant_estrella = 5;
            hoteles.ciudad = "asdasda";
            hoteles.nro_Calle = 20;
            hoteles.recarga_estrella = 20;
            hoteles.insert();*/
            //Hoteles hotel = Hoteles.find<Hoteles>(2);
            //MessageBox.Show("asdad" + hotel.calle);
            //ConnectionManager.getInstance().close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
