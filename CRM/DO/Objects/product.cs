using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
	public class product
	{

        public long productId { get; set; }
        public string productName { get; set; }
        public int inventory { get; set; }
        public decimal price { get; set; }
        public int categoryId { get; set; }

        public virtual category category { get; set; }
        //public virtual ICollection<order> orders { get; set; }
    }
}
