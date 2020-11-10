using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public interface IRepository<Entity> where Entity : class
	{
		IQueryable<Entity> AsQueryble();

		IEnumerable<Entity> GetAll();

		Entity GetOneById(long id);

		void Insert(Entity entity);
		void Update(Entity entity);
		void Delete(Entity entity);

		void Commit();
	}
}
