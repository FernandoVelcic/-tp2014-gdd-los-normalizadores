using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;

//No es un modelo en si, se usa para presentar la grilla en Registrar Consumible
namespace FrbaHotel.Models
{
    public class ConsumibleUnidades
    {
        
        public int codigo { get; set; }  //[numeric](18, 0)
        public String descripcion { get; set; } //[nvarchar](255)
        public float precio { get; set; }  // [numeric](18, 2)
        public int unidades { get; set; }
        public float monto { get; set; }


    }
}