using TryFirstProj.Data;
using TryFirstProj.Models;
using TryFirstProj.Repositry.Base;

namespace TryFirstProj.Repositry
{
    public class EmpRepo : MainRepositry<Employee>, IEmpRepo
    {
        public EmpRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;
        public void setPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
        public decimal getSalary(Employee employee)
        {
            throw new NotImplementedException();
        }
    }

}
