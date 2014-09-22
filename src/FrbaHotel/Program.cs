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
            //ConnectionManager.getInstance().connect("Pooling=true;Min Pool Size=5;Max Pool Size=40;Connect Timeout=1;server=" + Config.getInstance().server + ";database=" + Config.getInstance().database + ";Integrated Security=false;User Id=" + Config.getInstance().username + ";Password=" + Config.getInstance().password);
            //ConnectionManager.getInstance().close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
