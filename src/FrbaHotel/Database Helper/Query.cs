using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyActiveRecord
{
    abstract class Query
    {

        //TODO cosificar para poder agregar condicions con OR
        public List<String> whereConditions;

        public Type clazz;


        public Query(Type clazz)
        {
            this.whereConditions = new List<string>();
            this.clazz = clazz;
        }



        public String getTableName(String className)
        {
            //TODO agregar soporte para schemas
            return "[LOS_NORMALIZADORES].[" + className.ToLower() + "]";
        }


        public void addWhere(string key, string value)
        {
            this.addWhere(key, value, "=");
        }

        public void addWhere(string key, List<string> value)
        {
            this.addWhere(key, string.Join(", ", value.ToArray()), " IN ");
        }

        public void addWhere(string key, string value, string comparator)
        {
            this.whereConditions.Add(key + comparator + value);
        }

        public void addWhere(string condition)
        {
            this.whereConditions.Add(condition);
        }

        protected string buildWhere()
        {
            if (whereConditions.Count == 0)
            {
                return "";
            }
            return " WHERE " + string.Join(" AND ", whereConditions.ToArray());
        }


        

        public String table;

        public abstract String build();

    }
}
