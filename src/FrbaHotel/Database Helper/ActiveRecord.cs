using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;  // reflection namespace

namespace MyActiveRecord
{
    class ActiveRecord
    {

        public long id { get; set; }

        private Dictionary<String, String> getProperties()
        {
            PropertyInfo[] propertyInfos = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Dictionary<String, String> properties = new Dictionary<string, string>();
            foreach(PropertyInfo property in propertyInfos)
            {

                if (property.PropertyType == typeof(List<>))
                {
                    //Si hay un 1 a muchos no deberia guardarlo
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

        public Boolean validates()
        {
            return false;
        }

        protected void preSave()
        {

        }

        protected void afterSave()
        {

        }

        public void afterLoad()
        {

        }

        public void save()
        {
            this.preSave();
            
            if (hasId())
                this.update();
            else
                this.insert();

            this.afterSave();
        }

        public bool hasId()
        {
            return id!=0;
        }

        public void insert()
        {
            InsertQuery query = new InsertQuery(this.GetType());
            foreach (KeyValuePair<string, string> properties in getProperties())
            {
                query.addKeyValue(properties.Key, properties.Value);
            }
            this.id = query.exec();
        }

        public void update()
        {
            UpdateQuery query = new UpdateQuery(this.GetType());
            foreach (KeyValuePair<string, string> properties in getProperties())
            {
                query.addKeyValue(properties.Key, properties.Value);
            }
            query.addWhere("id", this.id.ToString());
            Console.WriteLine(query.build());
            query.exec();
        }

        public void delete()
        {
            DeleteQuery query = new DeleteQuery(this.GetType());
            query.addWhere("id", id.ToString());
            Console.WriteLine(query.build());
            query.exec();
        }







        public static List<T> find<T>()
        {
            return ActiveRecord.find<T>(false);
        }

        public static T find<T>(long id)
        {
            return ActiveRecord.find<T>(id, false);
        }

        public static List<T> find<T>(Boolean join)
        {
            return new List<T>();
        }

        public static T find<T>(long id, Boolean join)
        {
            SelectQuery<T> query = new SelectQuery<T>(typeof(T));
            ActiveRecord activeRecordHelper = new ActiveRecord();
            foreach (KeyValuePair<String, String> property in activeRecordHelper.getProperties())
            {
                //TODO hacer joins
            }

            query.addWhere("id", id.ToString());

            Console.WriteLine(query.build());
            Console.Read();

            return (T)Activator.CreateInstance(typeof(T));
        }


    }
}
