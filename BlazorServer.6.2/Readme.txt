2022.6.3端午节

4种方式的server side patch Data from database
    public interface IProducts:IDisposable
    {
        IEnumerable<Product> QueryProducts();
        Task<IEnumerable<Product>> GetDatatAsync();
        Task<Product[]> GetDatatAsync2();
        Task<Product[]> GetProducts();


    }