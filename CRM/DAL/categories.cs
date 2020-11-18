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
	public class categories : ICRUD<data.category>
	{
		private Repository<data.category> _repository = new Repository<data.category>(new DB_CRMEntities());

		public void Delete(category entity)
		{
			_repository.Delete(entity);
		}

		public IEnumerable<category> GetAll()
		{
			return _repository.GetAll();
		}

		public category GetOneById(long id)
		{
			return _repository.GetOneById(id);
		}

		public void Insert(category entity)
		{
			_repository.Insert(entity);
		}

		public void Update(category entity)
		{
			_repository.Update(entity);
		}
	}
}
