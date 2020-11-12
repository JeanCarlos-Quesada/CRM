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
	public class clients : ICRUD<ent.client>
	{
		private DAL.clients _dal = new DAL.clients();

		public void Delete(ent.client entity)
		{
			var _ent = Mapper.Map<ent.client, data.client>(entity);
			_dal.Delete(_ent);
		}

		public IEnumerable<ent.client> GetAll()
		{
			var entity = _dal.GetAll();
			var _ent = Mapper.Map<IEnumerable<data.client>, IEnumerable<ent.client>>(entity);

			return _ent;
		}

		public IEnumerable<ent.client> GetAll(Boolean isActive)
		{
			var entity = _dal.GetAll(isActive);
			var _ent = Mapper.Map<IEnumerable<data.client>, IEnumerable<ent.client>>(entity);

			return _ent;
		}

		public IEnumerable<ent.client> GetByNameOrId(String search, Boolean isActive)
		{
			var entity = _dal.GetByNameOrId(search, isActive);
			var _ent = Mapper.Map<IEnumerable<data.client>, IEnumerable<ent.client>>(entity);

			return _ent;
		}

		public ent.client GetOneById(long id)
		{
			var data = _dal.GetOneById(id);
			var _ent = Mapper.Map<data.client, ent.client>(data);

			return _ent;
		}

		public void Insert(ent.client entity)
		{
			var _ent = Mapper.Map<ent.client, data.client>(entity);
			_dal.Insert(_ent);
		}

		public void Update(ent.client entity)
		{
			var _ent = Mapper.Map<ent.client, data.client>(entity);
			_dal.Update(_ent);
		}
	}
}
