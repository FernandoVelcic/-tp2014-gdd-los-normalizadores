using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyActiveRecord
{
    class InsertQuery : Query
    {

        private Dictionary<string, string> values;

        public InsertQuery(Type clazz) : base(clazz)
        {
            this.values = new Dictionary<string,string>();
        }


        public void addKeyValue(String key, String value)
        {
            this.addKeyValue(key, value, true);
        }

        public void addKeyValue(String key, String value, Boolean ignoreSpaces)
        {
            if ((value != "" || value.Length > 0) || !ignoreSpaces)
                this.values.Add(key, value);
        }


        public override String build()
        {
            List<String> keys = new List<String>();
            List<String> values = new List<String>();
            foreach(KeyValuePair<String, String> value in this.values){
                if (value.Key != "id")
                {
                    keys.Add(value.Key);
                    //CHECK NULL
                    if (value.Value != "")
                        values.Add("'" + value.Value + "'");
                    else
                        values.Add("NULL");
                }
            }
            return "INSERT INTO " + getTableName(clazz.Name) + " (" + string.Join(", ", keys.ToArray()) + ") VALUES  (" + string.Join(", ", values.ToArray()) + ") ;";
        }

        public int exec()
        {
            SqlCommand command = new SqlCommand(build() + "; SELECT @@identity", ConnectionManager.getInstance().getConnection());
            Console.WriteLine(build());
            int newId = System.Convert.ToInt32(command.ExecuteScalar());
            Console.WriteLine("Inserto el ID: " + newId);
            return newId;
        }


    }
}