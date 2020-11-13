using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
	public class user
	{

        public long userId { get; set; }
        public long employeeId { get; set; }
        public byte[] userName { get; set; }
        public byte[] userPassword { get; set; }

        public virtual employee employee { get; set; }
        public virtual ICollection<user_x_rols> user_x_rols { get; set; }
    }
}
