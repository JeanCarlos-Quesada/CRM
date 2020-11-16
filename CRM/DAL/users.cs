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
	public class users : ICRUD<data.user>
	{
		private Repository<data.user> _repository = new Repository<data.user>(new DB_CRMEntities());

		public void Delete(user entity)
		{
			_repository.Delete(entity);
		}

		public IEnumerable<user> GetAll()
		{
			return _repository.GetAll();
		}

		public user GetOneById(long id)
		{
			return _repository.GetOneById(id);
		}

		public user GetOneByEmployeeId(long employeeId)
		{
			return _repository.AsQueryble().Where(x => x.employeeId == employeeId).FirstOrDefault();
		}

		public Boolean PasswordExist(byte[] password, long employeeId)
		{
			return _repository.AsQueryble().Where(x => x.userPassword == password && x.employeeId == employeeId).Count() != 0;
		}

		public Boolean UserNameExist(byte[] userName)
		{
			return _repository.AsQueryble().Where(x => x.userName == userName).Count() != 0;
		}

		public user GetLastOrDefault()
		{
			return _repository.GetAll().LastOrDefault();
		}

		public void Insert(user entity)
		{
			_repository.Insert(entity);
		}

		public void Update(user entity)
		{
			_repository.Update(entity);
		}
	}
}
