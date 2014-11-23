using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

using MyActiveRecord;
using FrbaHotel.Database_Helper;

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
            //Setear formato por default para las fechas
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;

            //Crear conexion con el motor MSSQL
            try
            {
                ConnectionManager.getInstance().connect("Pooling=true;Min Pool Size=5;Max Pool Size=40;Connect Timeout=1;server=" + Config.getInstance().server + ";database=" + Config.getInstance().database + ";Integrated Security=false;User Id=" + Config.getInstance().username + ";Password=" + Config.getInstance().password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede conectar al servidor, verifique los datos en el persistent.xml\r\n" + ex.Message);
                return;
            }

            //Aplicacion UI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());

        }
    }
}
