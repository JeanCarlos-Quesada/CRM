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
	public class users : ICRUD<ent.user>
	{
		private DAL.users _dal = new DAL.users();

		public void Delete(ent.user entity)
		{
			var _ent = Mapper.Map<ent.user, data.user>(entity);
			_dal.Delete(_ent);
		}

		public IEnumerable<ent.user> GetAll()
		{
			var entity = _dal.GetAll();
			var _ent = Mapper.Map<IEnumerable<data.user>, IEnumerable<ent.user>>(entity);

			return _ent;
		}

		public ent.user GetOneById(long id)
		{
			var data = _dal.GetOneById(id);
			var _ent = Mapper.Map<data.user, ent.user>(data);

			return _ent;
		}

		public ent.user GetOneByEmployeeId(long id)
		{
			var data = _dal.GetOneByEmployeeId(id);
			var _ent = Mapper.Map<data.user, ent.user>(data);

			return _ent;
		}
		
		public ent.user GetLastOrDefault()
		{
			var data = _dal.GetLastOrDefault();
			var _ent = Mapper.Map<data.user, ent.user>(data);

			return _ent;
		}

		public void Insert(ent.user entity)
		{
			var _ent = Mapper.Map<ent.user, data.user>(entity);
			_dal.Insert(_ent);
		}

		public void Update(ent.user entity)
		{
			var _ent = Mapper.Map<ent.user, data.user>(entity);
			_dal.Update(_ent);
		}

	}
}
