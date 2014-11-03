using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    public class ConsumibleEstadia : ActiveRecord
    {

        public override String table { get { return "consumibles_estadias"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY

        public Consumible consumible; //int
        public Regimen regimen;  //[nvarchar](255)
        public int unidades; //INTEGER



    }
}
