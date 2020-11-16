using DAL.EF;
using DAL.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = DAL.EF;

namespace DAL
{
	public class employees : ICRUD<data.employee>
	{
		private Repository<data.employee> _repository = new Repository<data.employee>(new DB_CRMEntities());

		public void Delete(employee entity)
		{
			_repository.Delete(entity);
		}

		public IEnumerable<employee> GetAll()
		{
			return _repository.GetAll();
		}

		public IEnumerable<employee> GetAll(Boolean isActive)
		{
			return _repository.AsQueryble().Where(x => x.isActive == isActive);
		}

		public IEnumerable<employee> GetByNameOrId(String search, Boolean isActive)
		{
			long searchId = -1;
			try
			{
				searchId = Int64.Parse(search);
			}
			catch { }
			return _repository.AsQueryble().Where(x => (x.employeeName.Contains(search) || x.employeeId == searchId) && x.isActive == isActive);
		}


		public employee GetOneById(long id)
		{
			return _repository.GetOneById(id);
		}

		public employee GetLastOrDefault()
		{
			return _repository.GetAll().LastOrDefault();
		}


		public employee SingIn(byte[] userName, byte[] password)
		{
			return _repository.AsQueryble().Where(x => x.users.Where(y => y.userName == userName && y.userPassword == password).Count() != 0 && x.isActive == true).FirstOrDefault();
		}

		public void Insert(employee entity)
		{
			_repository.Insert(entity);
		}

		public void Update(employee entity)
		{
			_repository.Update(entity);
		}
	}
}
