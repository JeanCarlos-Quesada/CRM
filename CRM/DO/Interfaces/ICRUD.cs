using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface ICRUD<Entity>
	{
		void Insert(Entity entity);
		void Update(Entity entity);
		void Delete(Entity entity);
		IEnumerable<Entity> GetAll();
		Entity GetOneById(long id);
	}
}
