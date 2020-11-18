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
	public class categories : ICRUD<ent.category>
	{
		private DAL.categories _dal = new DAL.categories();

		public void Delete(ent.category entity)
		{
			var _ent = Mapper.Map<ent.category, data.category>(entity);
			_dal.Delete(_ent);
		}

		public IEnumerable<ent.category> GetAll()
		{
			var entity = _dal.GetAll();
			var _ent = Mapper.Map<IEnumerable<data.category>, IEnumerable<ent.category>>(entity);

			return _ent;
		}

		public ent.category GetOneById(long id)
		{
			var data = _dal.GetOneById(id);
			var _ent = Mapper.Map<data.category, ent.category>(data);

			return _ent;
		}

		public void Insert(ent.category entity)
		{
			var _ent = Mapper.Map<ent.category, data.category>(entity);
			_dal.Insert(_ent);
		}

		public void Update(ent.category entity)
		{
			var _ent = Mapper.Map<ent.category, data.category>(entity);
			_dal.Update(_ent);
		}
	}
}
