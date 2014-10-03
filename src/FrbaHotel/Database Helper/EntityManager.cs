using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FrbaHotel.Database_Helper
{
    class EntityManager
    {

        private static EntityManager Instance;

        private EntityManager() { }

        private Dictionary<String, String> getProperties(Object item)
        {
            PropertyInfo[] propertyInfos = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Dictionary<String, String> properties = new Dictionary<string, string>();
            foreach (PropertyInfo property in propertyInfos)
            {

                if (property.PropertyType == typeof(List<>))
                {
                    //Si hay un 1 a muchos no deberia guardarlo
                }
                if (property.Name == "table")
                {
                    //Ignorar
                }
                else if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(Decimal) || property.PropertyType == typeof(String))
                {
                    properties.Add(property.Name, property.GetGetMethod().Invoke(this, null).ToString());
                }
                else
                {
                    //Aca obtengo el id del objeto anidado
                    Object objetoAnidado = property.GetGetMethod().Invoke(this, null);
                    properties.Add(property.Name, objetoAnidado.GetType().GetProperty("id").GetGetMethod().Invoke(objetoAnidado, null).ToString());
                }

            }
            return properties;
        }


        public static EntityManager getInstance()
        {
            if (EntityManager.Instance == null)
            {
                EntityManager.Instance = new EntityManager();
            }
            return EntityManager.Instance;
        }


        public void save(ActiveRecord item)
        {
            item.preSave();

            if (item.id != 0)
                this.update(item);
            else
                this.insert(item);

            item.afterSave();
        }

        public int insert(ActiveRecord item)
        {
            InsertQuery query = new InsertQuery(item.GetType());
            foreach (KeyValuePair<string, string> properties in getProperties(item))
            {
                query.addKeyValue(properties.Key, properties.Value);
            }
            return query.exec();
        }


        public int update(ActiveRecord item)
        {
            UpdateQuery query = new UpdateQuery(item.GetType());
            foreach (KeyValuePair<string, string> properties in getProperties(item))
            {
                query.addKeyValue(properties.Key, properties.Value);
            }
            query.addWhere("id", item.id.ToString());
            Console.WriteLine(query.build());
            return query.exec();
        }

        public void delete(ActiveRecord item)
        {
            DeleteQuery query = new DeleteQuery(item.GetType());
            query.addWhere("id", item.ToString());
            Console.WriteLine(query.build());
            query.exec();
        }










        public static List<T> findList<T>(List<T> conditions)
        {

            SelectQuery<T> query = new SelectQuery<T>(typeof(T));

            //query.addWhere("id", value);

            Console.WriteLine(query.build());
            Console.Read();

            SqlCommand cmd = new SqlCommand(query.build(), ConnectionManager.getInstance().getConnection());

            List<T> lista = new List<T>();

            using (SqlDataReader result = cmd.ExecuteReader())
            {
                while (result.Read())
                {
                    T item = (T) Activator.CreateInstance(typeof(T));

                    PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    
                    foreach (PropertyInfo property in propertyInfos)
                    {

                        if (property.PropertyType == typeof(List<>))
                        {
                            //Aca hay un join, cague

                        }
                        else if (property.Name == "table")
                        {
                            //la ignoro
                        }
                        else if (property.PropertyType == typeof(String))
                        {
                            property.SetValue(item, result[property.Name].ToString(), null);
                        }

                    }

                    lista.Add(item);
                }
            }

            return lista;
        }

        public static List<T> findAll<T>()
        {
            return EntityManager.findList<T>(new List<T>());
        }

        public static T findBy<T>(String key, String value)
        {
            return EntityManager.findList<T>(new List<T>())[0];
        }

        public static T findById<T>(long id, Boolean join)
        {
            return EntityManager.findBy<T>("id", id.ToString());
        }




    }
}
