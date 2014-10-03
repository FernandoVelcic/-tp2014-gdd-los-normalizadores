using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Database_Helper
{
    class FetchCondition
    {

        String key, value, comparator;

        public void setEquals(string key, string value)
        {
            this.key = "'" + key + "'";
            this.value = "'" + value + "'";
            this.comparator = "=";
        }

        public void setEquals(string key, int value)
        {
            this.key = "'" + key + "'";
            this.value = value.ToString();
            this.comparator = "=";
        }

        public void setEqualsWithFunction(string key, string value)
        {
            this.key = "'" + key + "'";
            this.value = value;
            this.comparator = "=";
        }


        public void setLike(string key, string value)
        {
            this.key = key;
            this.value = "%" + value + "%";
            this.comparator = "LIKE";
        }

        public string build()
        {
            return this.key + " " + this.comparator + " " + this.value;
        }



    }
}
