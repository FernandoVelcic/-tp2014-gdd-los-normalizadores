using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Models;

namespace FrbaHotel.Views.ABM_de_Hotel
{
    public partial class AltaModificacionHotel : Form
    {
        private Hotel hotel;

        public AltaModificacionHotel() : this(new Hotel())
        {

        }

        public AltaModificacionHotel(Hotel hotel)
        {
            InitializeComponent();
            this.hotel = hotel;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
