using TryFirstProj.Data;
using TryFirstProj.Models;
using TryFirstProj.Repositry.Base;

namespace TryFirstProj.Repositry
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Catogrey = new MainRepositry<Catogrey>(_context);
            Item = new MainRepositry<Item>(_context);
            Employee = new EmpRepo(_context);
        }
        private readonly AppDbContext _context;

        public IRepositry<Catogrey> Catogrey { get; private set; }

        public IRepositry<Item> Item { get; private set; }

        public IEmpRepo Employee { get; private set; }

        public int CommitChanges()
        {
          return  _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
