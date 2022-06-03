

namespace WebApp.Models
{
    public interface IProducts:IDisposable
    {
        IEnumerable<Product> QueryProducts();
        Task<IEnumerable<Product>> GetDatatAsync();
        Task<Product[]> GetDatatAsync2();
        Task<Product[]> GetProducts();


    }
}
