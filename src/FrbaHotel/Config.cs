using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    public class Config
    {
        private static Config instance;

        public static Config getInstance()
        {
            if (instance == null)
            {
                instance = new Config();
            }

            return instance;
        }

        public String server { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String database { get; set; }
        public String schema { get; set; }

        private Config()
        {
            server = "WIN-J1WNSO7Z940\\SQLSERVER2008";
            username = "gd";
            password = "gd2014";
            database = "GD2C2014";
            schema = "LOS_NORMALIZADORES";
        }

        //[DllImport("kernel32")]
        //private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
    }
}
