using BulkyBookWeb.Models;

namespace BulkyBookWeb.Interfaces
{
    public interface IBulky<Type,ID,Ret>
    {
        //IEnumerable<Category> Categories { get; }

        Task<List<Ret>> GetAll();
    }
}
