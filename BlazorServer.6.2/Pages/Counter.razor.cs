using WebApp.Models;
using BootstrapServerSide.Shared.Data;
using BlazorServer._6._2.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorServer._6._2.Pages
{

    
    public partial class Counter
    {

        public string title { get; set; } = "表格测试";

        [Inject]
        public IProducts? _products { get; set; }
        
        private IEnumerable<Product> products { get; set; }
       
        private Product[]?    products2;

        [Inject]
        public WeatherForecastService ForecastService { get; set; }

        //  private Product[]?  products;
        //
        // private IEnumerable<Product> products;

        public async Task QueryData2()
        {
            products2 =await  _products.GetProducts();
            int i = 0;
            i = products2.Length;
            
            title = i.ToString() + "条数据！";

        }
        



        public void QueryData()
        {

            
            products = _products.QueryProducts();
            products2 = new Product[products.Count()];
            int i = 0;
            foreach (var product in products)
            {
                products2[i] = product;
                i++;
            }
            i++;
            title = i.ToString() + "条数据已载入！";


        }

        public async Task GetProduct()
        {
            
            // Thread.Sleep(180 * 10);
          //  products2 = null;1
          //  products2=new Product[100];
            title = "载入中...";

            products = await _products.GetDatatAsync();
            products2 = new Product[products.Count()];
            int i = 0;
            foreach(var product in products)
            {
                products2[i] = product;
                i++;
            }
            i++;
            title =i.ToString()+ "条数据成功载入！";

        }

        protected override async Task OnInitializedAsync()
        {
           products2 = await _products.GetDatatAsync2();
            //  products = await productsService.GetDatatAsync();
            //   products = await ForecastService.GetForecastAsync(DateTime.Now);
            //     products =await _products.GetDatatAsync();

        }

    }




}
