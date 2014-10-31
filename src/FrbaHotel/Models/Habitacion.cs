﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyActiveRecord;
using FrbaHotel.Database_Helper;
using FrbaHotel.Models.Exceptions;
using System.Data.SqlClient;

namespace FrbaHotel.Models
{
    public class Habitacion : ActiveRecord
    {
        public override String table { get { return "habitaciones"; } }

        //public int id { get; set; } //INTEGER IDENTITY PRIMARY KEY
        
        public Hotel hotel { get; set; } //hotel_id
        public int numero { get; set; } //[numeric](18, 0)
        public int piso { get; set; } //[numeric](18, 0)
        public String frente { get; set; } //[nvarchar](50)
        public TipoHabitacion tipo { get; set; }
        public Boolean estado { get; set; } //[bit]
        public String descripcion { get; set; } //[nvarchar](255)

        public override string ToString()
        {
            return hotel.ToString() + " - " + numero.ToString() ;
        }

        public override void preInsert()
        {
            List<Habitacion> habitaciones = EntityManager.getEntityManager().findAllBy<Habitacion>("numero", numero.ToString());
            if (habitaciones.Count != 0)
            {
                throw new ValidationException("Numero de habitacion duplicado");
            }
        }

        public override void preSave()
        {
            if (descripcion.Length >= 255)
            {
                throw new ValidationException("El maximo de caracteres en la descripcion es de 255");
            }
        }


        public Boolean estaDisponible(DateTime desde, int cantidadNoches)
        {
            SelectQuery<Reserva> query = new SelectQuery<Reserva>(typeof(Reserva));

            query.addCount().addWhere("habitacion_id", id.ToString());

            query.addWhere("desde", desde.AddDays(cantidadNoches).ToLongDateString(), ">");
            query.addWhere("desde + cant_noches", desde.ToLongDateString(), "<");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query.build(); ;
            Int32 count = (Int32)cmd.ExecuteScalar();

            return count == 0;
        }


    }
}
