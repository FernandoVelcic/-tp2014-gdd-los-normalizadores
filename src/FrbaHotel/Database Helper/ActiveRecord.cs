using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FrbaHotel.Database_Helper;  // reflection namespace

namespace MyActiveRecord
{
    public abstract class ActiveRecord
    {
        [System.ComponentModel.Browsable(false)] 
        public long id { get; set; }
        [System.ComponentModel.Browsable(false)] 
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
            EntityManager.getEntityManager().save(this);
        }

        public void insert()
        {
            id = EntityManager.getEntityManager().insert(this);
        }

        public void delete()
        {
            EntityManager.getEntityManager().delete(this);
        }

        public void logicalDelete()
        {
            EntityManager.getEntityManager().logicalDelete(this);
        }

        public void fill(Object values)
        {

        }




    }
}
