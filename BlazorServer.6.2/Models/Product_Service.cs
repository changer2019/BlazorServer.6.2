using System;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BootstrapServerSide.Shared.Data;
using Microsoft.AspNetCore.Components;

namespace WebApp.Models
{
    public class Product_Service
    {


         [Inject]
         public IProducts?  _products { get; set; }
         private List<Product>? Items { get; set; }
        //  public ProductsService? _products { get; set; }
        //  public ProductsService _products;
        private Product[]? products;
        

     //   //ProductControlls.Get();

        private static readonly string[] Summaries = new[]
      {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        /*
        public Product_Service(ProductsService products)
        {
            _products = products;
        }
        */
        private readonly List<Product> _data = new()

        {  
            
           new (){Name="test1",ProductId=1,Price=10},
           new (){Name="test2",ProductId=2,Price=20},

        };


        /*
        public async Task<Product[]> _GetProducts()

        {

            Items = await _products.GetDatatAsync();
            //  else       IEnumerable<Product>? products = r;

            return Task.FromResult(Items.ToArray());

        }
        */

            public Task<Product[]> GetProducts()

        {
            
            IEnumerable<Product>? products=null;           
            //6.3 陈工方法
           // products = _products.QueryProducts();

            //if (r == null)

             //ok
            products= _data.AsQueryable();
          //  else       IEnumerable<Product>? products = r;

            return Task.FromResult(products.ToArray());

            /*
            var builder = WebApplication.CreateBuilder();
            string mySqlConnection = builder.Configuration.GetSection("ConnectionStrings")["ProductConnection"];
            
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
             builder.Services.AddDbContext<DataContext>
                (options => options.UseMySql(mySqlConnection, MySqlServerVersion.LatestSupportedServerVersion));
            //optionsBuilder.UseMySql();
            using (var cntx = new DataContext(optionsBuilder.Options))
            {
            }
            
            */






        }


    }


}
