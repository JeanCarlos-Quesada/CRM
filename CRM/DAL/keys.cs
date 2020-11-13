using DAL.EF;
using DAL.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = DAL.EF;

namespace DAL
{
	public class keys : ICRUD<data.key>
	{
		private Repository<data.key> _repository = new Repository<data.key>(new DB_CRMEntities());

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
			return _repository.GetOneById(id);
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

