using MyActiveRecord;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Database_Helper
{
    class FillerHelper
    {


        public static T buildObject<T>(SqlDataReader result)
        {
            T item = (T) Activator.CreateInstance(typeof(T));

            PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in propertyInfos)
            {

                if (property.PropertyType.IsSubclassOf(typeof(ActiveRecord)))
                {
                    
                }
                else if (property.Name == "table")
                {
                    //la ignoro
                }
                else if (property.PropertyType == typeof(int))
                {
                    property.SetValue(item, Int32.Parse(result[property.Name].ToString()), null);
                }
                else if (property.PropertyType == typeof(float))
                {
                    property.SetValue(item, Single.Parse(result[property.Name].ToString()), null);
                }
                else if (property.PropertyType == typeof(long))
                {
                    property.SetValue(item, Convert.ToInt64(result[property.Name].ToString()), null);
                }
                else if (property.PropertyType == typeof(Boolean))
                {
                    property.SetValue(item, Boolean.Parse(result[property.Name].ToString()), null);
                }
                else if (property.PropertyType == typeof(String))
                {
                    property.SetValue(item, result[property.Name].ToString(), null);
                }
                /*
                else 
                {
                    //Aca hay un join, cague, 
                    //TODO crear proxy
                    Type genericListType = typeof(List<>).MakeGenericType(property.GetType());
                    property.SetValue(item, (genericListType) Activator.CreateInstance(genericListType), null);

                }
                */


            }

            return item;

        }



    }
}
