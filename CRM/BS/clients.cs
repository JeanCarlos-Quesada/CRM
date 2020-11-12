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
	public class clients : ICRUD<ent.clients>
	{
		private DAL.clients _dal = new DAL.clients();

		public void Delete(ent.clients entity)
		{
			var _ent = Mapper.Map<ent.clients, data.client>(entity);
			_dal.Delete(_ent);
		}

		public IEnumerable<ent.clients> GetAll()
		{
			var entity = _dal.GetAll();
			var _ent = Mapper.Map<IEnumerable<data.client>, IEnumerable<ent.clients>>(entity);

			return _ent;
		}

		public IEnumerable<ent.clients> GetAll(Boolean isActive)
		{
			var entity = _dal.GetAll(isActive);
			var _ent = Mapper.Map<IEnumerable<data.client>, IEnumerable<ent.clients>>(entity);

			return _ent;
		}
		
		public ent.clients GetOneById(long id)
		{
			var data = _dal.GetOneById(id);
			var _ent = Mapper.Map<data.client, ent.clients>(data);

			return _ent;
		}

		public IEnumerable<ent.clients> GetByNameOrId(String search, Boolean isActive)
		{
			var entity = _dal.GetByNameOrId(search, isActive);
			var _ent = Mapper.Map<IEnumerable<data.client>, IEnumerable<ent.clients>>(entity);

			return _ent;
		}

		public void Insert(ent.clients entity)
		{
			var _ent = Mapper.Map<ent.clients, data.client>(entity);
			_dal.Insert(_ent);
		}

		public void Update(ent.clients entity)
		{
			var _ent = Mapper.Map<ent.clients, data.client>(entity);
			_dal.Update(_ent);
		}
	}
}
