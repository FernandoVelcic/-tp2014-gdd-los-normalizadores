using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public static class Navigator
    {
        public static void nextForm(this Form form1, Form form2)
        {
            form1.Hide();
            form2.Closed += (s, a) => form1.Close();
            form2.Show();
        }
    }
}
