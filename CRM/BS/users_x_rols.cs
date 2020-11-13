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
	public class users_x_rols : ICRUD<ent.user_x_rols>
	{
		private DAL.users_x_rols _dal = new DAL.users_x_rols();

		public void Delete(ent.user_x_rols entity)
		{
			var _ent = Mapper.Map<ent.user_x_rols, data.users_X_rols>(entity);
			_dal.Delete(_ent);
		}

		public IEnumerable<ent.user_x_rols> GetAll()
		{
			var entity = _dal.GetAll();
			var _ent = Mapper.Map<IEnumerable<data.users_X_rols>, IEnumerable<ent.user_x_rols>>(entity);

			return _ent;
		}

		public IEnumerable<ent.user_x_rols> GetAllByUserId(long id)
		{
			var entity = _dal.GetAllByUserId(id);
			var _ent = Mapper.Map<IEnumerable<data.users_X_rols>, IEnumerable<ent.user_x_rols>>(entity);

			return _ent;
		}
		
		public ent.user_x_rols GetOneById(long id)
		{
			var data = _dal.GetOneById(id);
			var _ent = Mapper.Map<data.users_X_rols, ent.user_x_rols>(data);

			return _ent;
		}

		public void Insert(ent.user_x_rols entity)
		{
			var _ent = Mapper.Map<ent.user_x_rols, data.users_X_rols>(entity);
			_dal.Insert(_ent);
		}

		public void Update(ent.user_x_rols entity)
		{
			var _ent = Mapper.Map<ent.user_x_rols, data.users_X_rols>(entity);
			_dal.Update(_ent);
		}
	}
}

