using AutoMapper;
using DAL.Interfaces;
using DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = DAL.EF;
using ent = DO.Objects;


namespace BS
{
	public class keys : ICRUD<ent.key>
	{
		private DAL.keys _dal = new DAL.keys();

		public void Delete(key entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<key> GetAll()
		{
			throw new NotImplementedException();
		}

		public key GetOneById(long id)
		{
			var data = _dal.GetOneById(id);
			var _ent = Mapper.Map<data.key, ent.key>(data);

			return _ent;
		}

		public void Insert(key entity)
		{
			throw new NotImplementedException();
		}

		public void Update(key entity)
		{
			throw new NotImplementedException();
		}
	}
}

