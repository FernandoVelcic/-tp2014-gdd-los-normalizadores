using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FrbaHotel.Database_Helper;  // reflection namespace

namespace MyActiveRecord
{
    abstract class ActiveRecord
    {

        public long id { get; set; }

        public abstract String table { get; }


        public Boolean validates()
        {
            return false;
        }

        public void preSave()
        {

        }

        public void afterSave()
        {

        }

        public void afterLoad()
        {

        }

        public void save()
        {
            EntityManager.getInstance().save(this);
        }

        public void insert()
        {
            EntityManager.getInstance().insert(this);
        }

        public void delete()
        {
            EntityManager.getInstance().delete(this);
        }

        public void logicalDelete()
        {
            EntityManager.getInstance().logicalDelete(this);
        }

        public void fill(Object values)
        {

        }




    }
}
