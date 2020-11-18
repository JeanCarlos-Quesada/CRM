using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
	public class category
    {
        public int id { get; set; }
        public string categoryName { get; set; }

        public virtual ICollection<product> products { get; set; }
    }
}
