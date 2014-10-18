﻿using FrbaHotel.Database_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using FrbaHotel;

namespace MyActiveRecord
{
    abstract class Query
    {

        public static List<String> log;

        public static void addLog(String query)
        {
            if (Query.log == null)
            {
                log = new List<String>();
            }

            log.Add(query);
        }

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
            Object instancia = Activator.CreateInstance(clazz);
            return "[" + Config.getInstance().schema + "].[" + instancia.GetType().GetProperty("table").GetGetMethod().Invoke(instancia, null) +"]";
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

        
        public void addWhere(List<FetchCondition> conditions)
        {
            foreach (FetchCondition condition in conditions)
            {
                this.addWhere(condition.build());
            }
        }


        protected string buildWhere()
        {
            if (whereConditions.Count == 0)
            {
                return "";
            }
            return " WHERE " + string.Join(" AND ", whereConditions.ToArray());
        }


        public abstract String build();

    }
}
