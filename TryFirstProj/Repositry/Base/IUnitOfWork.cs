using TryFirstProj.Models;
namespace TryFirstProj.Repositry.Base
{
    public interface IUnitOfWork : IDisposable
    {
       IRepositry<Catogrey> Catogrey { get; }
       IRepositry<Item> Item { get; }

        // specific repo
        IEmpRepo Employee { get; }

        int CommitChanges();
    }

}
