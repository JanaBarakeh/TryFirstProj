using System.Linq.Expressions;

namespace TryFirstProj.Repositry.Base
{
    public interface IRepositry <T> where T : class
    {
        T FindById(int id);

        T SelectOne(Expression<Func<T,bool>>match);

        IEnumerable<T> FindAll(params string[] agers);
        IEnumerable <T> GetAll();

        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task <IEnumerable<T>> FindAllAsync(params string[] agers);

        void AddOne (T myItem);
        void DeleteOne (T myItem);
        void UpdateOne(T myItem);
        void AddList(IEnumerable<T> myList);
        void DeleteList(IEnumerable<T> myList);
        void UpdateList(IEnumerable<T> myList);


    }
}
