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
        private SqlConnection coneccion;

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
            coneccion = new SqlConnection(conectionString);
            coneccion.Open();
        }

        public SqlConnection getConnection()
        {
            return coneccion;
        }

        public void close()
        {
            coneccion.Close();
        }



    }
}
