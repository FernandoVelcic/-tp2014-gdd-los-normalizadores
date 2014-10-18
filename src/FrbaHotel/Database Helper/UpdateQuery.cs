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
            this.addKeyValue(key, value, false);
        }

        public void addKeyValue(String key, String value, Boolean ignoreSpaces)
        {
            if (key != "id" && ((value != "" || value.Length > 0) || !ignoreSpaces))
            {
                this.values.Add(key, value);
            }
        }


        public override string build()
        {
            String query = "UPDATE " + getTableName(clazz.Name) + " SET " + string.Join(", ", values.Select(x => x.Key + " = " + "'" + x.Value + "'").ToArray()) + " " + this.buildWhere() + ";";
            Query.addLog(query);
            return query;
        }

        public int exec()
        {
            SqlCommand command = new SqlCommand(build(), ConnectionManager.getInstance().getConnection());
            return command.ExecuteNonQuery();
        }


    }
}
