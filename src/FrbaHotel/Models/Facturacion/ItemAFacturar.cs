﻿using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Models
{
    public class ItemAFacturar
    {

       //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY

        public Consumible consumible { get; set; } //int
        public Estadia estadia { get; set; }  //int
        public float monto { get; set; } //int
        public int unidades { get; set; }  //INTEGER



    }
}
