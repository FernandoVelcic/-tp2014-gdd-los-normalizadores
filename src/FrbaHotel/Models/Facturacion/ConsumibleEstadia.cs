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
    public class ConsumibleEstadia : ActiveRecord
    {
        public override String table { get { return "consumibles_estadias"; } }

        public Consumible consumible { get; set; } //INTEGER
        public Estadia estadia { get; set; }  // INTEGER
        public int unidades { get; set; } //INTEGER

    }
}