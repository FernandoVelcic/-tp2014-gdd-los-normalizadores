using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyActiveRecord
{
    class DeleteQuery : Query
    {

        public DeleteQuery(Type clazz) : base(clazz) { }

        public override string build()
        {
            String query = "DELETE FROM " + getTableName(clazz.Name) + this.buildWhere();
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
