using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSU21
{
    public class CarRegister
    {
        public int CarID { get; set; }
        public Car Car { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
