using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
	public class employee
	{
        public long employeeId { get; set; }
        public string employeeName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public System.DateTime registerDate { get; set; }
        public bool isActive { get; set; }

        //public virtual ICollection<order> orders { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
