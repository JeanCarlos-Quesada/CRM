using AutoMapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = DAL.EF;
using ent = DO.Objects;


namespace BS
{
	public class employees : ICRUD<ent.employee>
	{
		private DAL.employees _dal = new DAL.employees();

		public void Delete(ent.employee entity)
		{
			var _ent = Mapper.Map<ent.employee, data.employee>(entity);
			_dal.Delete(_ent);
		}

		public IEnumerable<ent.employee> GetAll()
		{
			var entity = _dal.GetAll();
			var _ent = Mapper.Map<IEnumerable<data.employee>, IEnumerable<ent.employee>>(entity);

			return _ent;
		}

		public IEnumerable<ent.employee> GetAll(Boolean isActive)
		{
			var entity = _dal.GetAll(isActive);
			var _ent = Mapper.Map<IEnumerable<data.employee>, IEnumerable<ent.employee>>(entity);

			return _ent;
		}

		public IEnumerable<ent.employee> GetByNameOrId(String search, Boolean isActive)
		{
			var entity = _dal.GetByNameOrId(search, isActive);
			var _ent = Mapper.Map<IEnumerable<data.employee>, IEnumerable<ent.employee>>(entity);

			return _ent;
		}

		public ent.employee GetOneById(long id)
		{
			var data = _dal.GetOneById(id);
			var _ent = Mapper.Map<data.employee, ent.employee>(data);

			return _ent;
		}

		public ent.employee GetLastOrDefault()
		{
			var data = _dal.GetLastOrDefault();
			var _ent = Mapper.Map<data.employee, ent.employee>(data);

			return _ent;
		}
		
		public void Insert(ent.employee entity)
		{
			var _ent = Mapper.Map<ent.employee, data.employee>(entity);
			_dal.Insert(_ent);
		}

		public void Update(ent.employee entity)
		{
			var _ent = Mapper.Map<ent.employee, data.employee>(entity);
			_dal.Update(_ent);
		}
	}
}

