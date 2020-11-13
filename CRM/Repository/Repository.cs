using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
	public class Repository<Entity> : IRepository<Entity> where Entity : class
	{
		private readonly DbContext dbContext;

		public Repository(DbContext context)
		{
			dbContext = context;
		}

		public IQueryable<Entity> AsQueryble()
		{
			return dbContext.Set<Entity>().AsQueryable();
		}

		public void Commit()
		{
			try
			{
				dbContext.SaveChanges();
			}
			catch(Exception ex)
			{
				dbContext.Database.CurrentTransaction.Rollback();
			}
		}

		public IEnumerable<Entity> GetAll()
		{
			return dbContext.Set<Entity>();
		}

		public Entity GetOneById(long id)
		{
			return dbContext.Set<Entity>().Find(id);
		}

		public void Insert(Entity entity)
		{
			try
			{
				dbContext.Set<Entity>().Add(entity);
				Commit();
			}
			catch(Exception ex)
			{
				dbContext.Database.CurrentTransaction.Rollback();
			}
		}

		public void Update(Entity entity)
		{
			if (dbContext.Entry<Entity>(entity).State == EntityState.Detached)
			{
				dbContext.Set<Entity>().Attach(entity);
			}
			dbContext.Entry<Entity>(entity).State = EntityState.Modified;
			Commit();
		}

		public void Delete(Entity entity)
		{
			try
			{
				dbContext.Entry<Entity>(entity).State = EntityState.Deleted;
				Commit();
			}
			catch (Exception ex)
			{
				dbContext.Entry<Entity>(entity).State = EntityState.Unchanged;
			}
		}
	}
}
