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

        public SelectQuery<T> addLeftJoin()
        {
            return this;
        }

        public SelectQuery<T> addGroupBy()
        {
            return this;
        }

        public SelectQuery<T> addSelect()
        {
            return this;
        }

        public SelectQuery<T> addCount()
        {
            return this;
        }

        public SelectQuery<T> addSum(String col)
        {
            return this;
        }



        private string buildSelect()
        {
            return "SELECT * ";
        }

        private string buildFrom()
        {
            return "FROM " + this.getTableName(clazz.Name);
        }


        public override string build()
        {
            String query = this.buildSelect() + this.buildFrom() + this.buildWhere();
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
