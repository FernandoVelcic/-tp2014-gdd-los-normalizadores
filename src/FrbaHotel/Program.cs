using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            /*
                        ConnectionManager.getInstance().connect("Pooling=true;Min Pool Size=5;Max Pool Size=40;Connect Timeout=1;server=NICO-L-WINDOWS\\SQLEXPRESS;database=test_active_record;Integrated Security=false;User Id=nico;Password=nico");

            Person persona = Person.find<Person>(1);
 
            ConnectionManager.getInstance().close();
            Console.ReadLine();
            //Person persona = Person.find<Person>(7);
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
