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
	public class users_x_rols : ICRUD<data.users_X_rols>
	{
		private Repository<data.users_X_rols> _repository = new Repository<data.users_X_rols>(new DB_CRMEntities());

		public void Delete(users_X_rols entity)
		{
			_repository.Delete(entity);
		}

		public IEnumerable<users_X_rols> GetAll()
		{
			return _repository.GetAll();
		}

		public IEnumerable<users_X_rols> GetAllByUserId(long id)
		{
			return _repository.AsQueryble().Where(x => x.userId == id);
		}

		public users_X_rols GetOneById(long id)
		{
			return _repository.GetOneById(id);
		}

		public void Insert(users_X_rols entity)
		{
			_repository.Insert(entity);
		}

		public void Update(users_X_rols entity)
		{
			_repository.Update(entity);
		}
	}

}
