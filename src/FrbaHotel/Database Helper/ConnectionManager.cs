using FrbaHotel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyActiveRecord
{
    class ConnectionManager
    {

        private static ConnectionManager instance;
        private SqlConnection conexion;

        private ConnectionManager()
        {
            
        }

        public static ConnectionManager getInstance()
        {
            if (instance == null)
            {
                instance = new ConnectionManager();
            }
            return instance;
        }

        public void connect(String conectionString)
        {
            conexion = new SqlConnection(conectionString);
            conexion.Open();

            new SqlCommand("USE [" + Config.getInstance().database + "] ", conexion).ExecuteNonQuery();
            new SqlCommand("SET DATEFORMAT " + Config.getInstance().getDateFormat(), conexion).ExecuteNonQuery();

        }

        public SqlConnection getConnection()
        {
            return conexion;
        }

        public void close()
        {
            conexion.Close();
        }



    }
}
