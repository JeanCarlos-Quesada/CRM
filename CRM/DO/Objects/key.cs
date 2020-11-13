using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Objects
{
	public class key
	{
		public byte id { get; set; }
		public byte[] C_Key { get; set; }
		public byte[] C_IV { get; set; }
	}
}
