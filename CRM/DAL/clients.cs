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
	public class clients : ICRUD<data.client>
	{
		private Repository<data.client> _repository = new Repository<data.client>(new DB_CRMEntities());

		public void Delete(client entity)
		{
			_repository.Delete(entity);
		}

		public IEnumerable<client> GetAll()
		{
			return _repository.GetAll();
		}

		public IEnumerable<client> GetAll(Boolean isActive)
		{
			return _repository.AsQueryble().Where(x => x.isActive == isActive);
		}

		public IEnumerable<client> GetByNameOrId(String search, Boolean isActive)
		{
			long searchId = -1;
			try
			{
				searchId = Int64.Parse(search);
			}
			catch { }
			return _repository.AsQueryble().Where(x => (x.clientName.Contains(search) || x.clientId == searchId) && x.isActive == isActive);
		}

		
		public client GetOneById(long id)
		{
			return _repository.GetOneById(id);
		}

		public void Insert(client entity)
		{
			_repository.Insert(entity);
		}

		public void Update(client entity)
		{
			_repository.Update(entity);
		}
	}
}
