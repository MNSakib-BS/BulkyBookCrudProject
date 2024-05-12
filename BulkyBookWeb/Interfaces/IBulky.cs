using BulkyBookWeb.Models;

namespace BulkyBookWeb.Interfaces
{
    public interface IBulky<Type,ID,Ret>
    {

        Task<List<Ret>> GetAll();
        Task<Ret> Create(Type type);
        // Task<Ret> Get(Type type);
        Task<Ret> Get(int id);
        Task<Ret> Update(Ret type);
        Task <Ret> Delete(ID id);
    }
}
