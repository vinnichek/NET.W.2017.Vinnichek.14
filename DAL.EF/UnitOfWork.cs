using DAL.Interface;
using ORM;
using System.Data.Entity;

namespace DAL.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context?.SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
