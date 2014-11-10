using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FrbaHotel.Models;
using FrbaHotel.Models.Exceptions;
using FrbaHotel.Tools;
using FrbaHotel.Database_Helper;

namespace FrbaHotel.Models
{
    public class Consumible : ActiveRecord 
    {

        public override String table { get { return "consumibles"; } }

        public String descripcion { get; set; } //[nvarchar](255)
        public float precio { get; set; }  // [numeric](18, 2)


        public override string ToString()
        {
            return descripcion;
        }



    }
}
