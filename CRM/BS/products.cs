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
	public class products : ICRUD<ent.product>
	{
		private DAL.products _dal = new DAL.products();

		public void Delete(ent.product entity)
		{
			var _ent = Mapper.Map<ent.product, data.product>(entity);
			_dal.Delete(_ent);
		}

		public IEnumerable<ent.product> GetAll()
		{
			var entity = _dal.GetAll();
			var _ent = Mapper.Map<IEnumerable<data.product>, IEnumerable<ent.product>>(entity);

			return _ent;
		}

		public IEnumerable<ent.product> GetByNameOrId(String search)
		{
			var entity = _dal.GetByNameOrId(search);
			var _ent = Mapper.Map<IEnumerable<data.product>, IEnumerable<ent.product>>(entity);

			return _ent;
		}

		public ent.product GetOneById(long id)
		{
			var data = _dal.GetOneById(id);
			var _ent = Mapper.Map<data.product, ent.product>(data);

			return _ent;
		}
		
		public void Insert(ent.product entity)
		{
			var _ent = Mapper.Map<ent.product, data.product>(entity);
			_dal.Insert(_ent);
		}

		public void Update(ent.product entity)
		{
			var _ent = Mapper.Map<ent.product, data.product>(entity);
			_dal.Update(_ent);
		}
	}
}

