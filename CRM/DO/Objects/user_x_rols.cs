using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
	public class user_x_rols
	{
        public long id { get; set; }
        public byte rolId { get; set; }
        public long userId { get; set; }

        public virtual rol rol { get; set; }
        public virtual user user { get; set; }
    }
}
