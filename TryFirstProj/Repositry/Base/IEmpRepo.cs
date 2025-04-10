using TryFirstProj.Models;

namespace TryFirstProj.Repositry.Base
{
    public interface IEmpRepo : IRepositry<Employee>
    {
        void setPayRoll(Employee employee);

        decimal getSalary(Employee employee);
    }
}
