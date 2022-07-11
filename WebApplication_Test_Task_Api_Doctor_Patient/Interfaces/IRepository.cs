
namespace WebApplication_Test_Task_Api_Doctor_Patient.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get(int page, int pageSize);
        Task<T> Get(Guid id);
        Task<bool> Create(T item);
        Task<bool> Update(T item);
        Task<T> Delete(Guid id);
    }
}
