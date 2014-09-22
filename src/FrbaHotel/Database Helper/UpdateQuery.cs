using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyActiveRecord
{
    class UpdateQuery : Query
    {

        private Dictionary<string, string> values;

        public UpdateQuery(Type clazz) : base(clazz)
        {
            values = new Dictionary<string, string>();
        }


        public void addKeyValue(String key, String value)
        {
            if (key != "id")
            {
                this.values.Add(key, value);
            }
        }


        public override string build()
        {
            return "UPDATE " + parseName(clazz.Name) + " SET " + string.Join(", ", values.Select(x => x.Key + " = " + "'" + x.Value + "'").ToArray()) + " " + this.buildWhere() + ";";
        }

        public int exec()
        {
            SqlCommand command = new SqlCommand(build(), ConnectionManager.getInstance().getConnection());
            return command.ExecuteNonQuery();
        }


    }
}
