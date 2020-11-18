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
	public class products : ICRUD<data.product>
	{
		private Repository<data.product> _repository = new Repository<data.product>(new DB_CRMEntities());

		public void Delete(product entity)
		{
			_repository.Delete(entity);
		}

		public IEnumerable<product> GetAll()
		{
			return _repository.GetAll();
		}

		public IEnumerable<product> GetByNameOrId(String search)
		{
			long searchId = -1;
			try
			{
				searchId = Int64.Parse(search);
			}
			catch { }

			return _repository.AsQueryble().Where(x => x.productName.Contains(search) || x.categoryId == searchId);
		}

		public product GetOneById(long id)
		{
			return _repository.GetOneById(id);
		}

		public void Insert(product entity)
		{
			_repository.Insert(entity);
		}

		public void Update(product entity)
		{
			_repository.Update(entity);
		}
	}
}

