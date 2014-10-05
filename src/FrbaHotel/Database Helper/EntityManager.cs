using MyActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

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
                else if (property.Name == "table")
                {
                    //Ignorar
                }
                else if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(Decimal) || property.PropertyType == typeof(String))
                {
                    properties.Add(property.Name, property.GetGetMethod().Invoke(item, null).ToString());
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
            query.addWhere("id", item.id.ToString());
            Console.WriteLine(query.build());
            query.exec();
        }








        public static List<T> findList<T>(List<FetchCondition> conditions)
        {
            SelectQuery<T> query = new SelectQuery<T>(typeof(T));

            query.addWhere(conditions);

            
            Console.WriteLine(query.build());
            Console.Read();

            SqlCommand cmd = new SqlCommand(query.build(), ConnectionManager.getInstance().getConnection());

            List<T> lista = new List<T>();

            using (SqlDataReader result = cmd.ExecuteReader())
            {
                while (result.Read())
                {
                    lista.Add(FillerHelper.buildObject<T>(result));
                }
            }

            return lista;
        }

        public static List<T> findAll<T>()
        {
            return EntityManager.findList<T>(new List<FetchCondition>());
        }

        public static T findBy<T>(String key, String value)
        {
            FetchCondition condition = new FetchCondition();
            condition.setEquals(key, value);
            List<FetchCondition> condiciones = new List<FetchCondition>();
            return EntityManager.findList<T>(condiciones)[0];
        }

        public static T findById<T>(long id)
        {
            return EntityManager.findBy<T>("id", id.ToString());
        }




    }
}
