using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyActiveRecord
{
    class Person: ActiveRecord
    {

        public String nombre { get; set; }
        public String apellido { get; set; }
        public EdadCosificada edad { get; set; }

    }
}
