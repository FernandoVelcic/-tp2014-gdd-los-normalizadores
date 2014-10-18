using FrbaHotel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace MyActiveRecord
{
    class SelectQuery<T> : Query
    {

        public SelectQuery(Type clazz) : base(clazz){}

        public SelectQuery<T> addInnerJoin()
        {
            return this;
        }


        public List<String> joins = new List<string>();
        public SelectQuery<T> addLeftJoin(String tableName, String condition)
        {
            return addJoin("LEFT", tableName, condition);
        }

        public SelectQuery<T> addInnerJoin(String tableName, String condition)
        {
            return addJoin("INNER", tableName, condition);
        }

        private SelectQuery<T> addJoin(String type, String tableName, String condition)
        {
            joins.Add(" " + type + " JOIN ["+ Config.getInstance().schema +"].[" + tableName + "] ON " + condition);
            return this;
        }


        public SelectQuery<T> addGroupBy()
        {
            return this;
        }


        private List<String> selects = new List<String>();
        public SelectQuery<T> addSelect(String col)
        {
            this.selects.Add(col);
            return this;
        }

        public SelectQuery<T> addSelect(String col, String alias)
        {
            return addSelect(col + " as " + alias);
        }



        public SelectQuery<T> addCount()
        {
            return this;
        }

        public SelectQuery<T> addSum(String col)
        {
            return this;
        }


        private String buildJoin()
        {
            return string.Join(" ", joins.ToArray()) + " ";
        }

        private string buildSelect()
        {
            if (selects.Count() == 0)
            {
                return "SELECT * ";
            }
            return "SELECT " + string.Join(", ", selects.ToArray()) + " ";
        }

        private string buildFrom()
        {
            return "FROM " + this.getTableName();
        }


        public override string build()
        {
            String query = buildSelect() + buildFrom() + buildJoin() + buildWhere();
            Query.addLog(query);
            return query;
        }

        private T createObjectFromReader(SqlDataReader reader)
        {
            return (T)new Object();
        }

        public T findUnique()
        {
            SqlCommand command = new SqlCommand(build(), ConnectionManager.getInstance().getConnection());
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return this.createObjectFromReader(reader);
        }


        public List<T> findList()
        {
            List<T> items = new List<T>();
            SqlCommand command = new SqlCommand(build(), ConnectionManager.getInstance().getConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(createObjectFromReader(reader));
            }
            return items;
        }







    }
}
