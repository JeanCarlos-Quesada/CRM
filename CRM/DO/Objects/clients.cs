using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
	public class clients
	{
        public long clientId { get; set; }
        public string clientName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public System.DateTime registerDate { get; set; }
        public bool isActive { get; set; }

        //public virtual ICollection<order> orders { get; set; }
    }
}
