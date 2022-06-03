using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using CJ.Common;
using System.Data;
using Dapper;
using MySqlConnector;

namespace BlazorServer._6._2.Services
{
    //[ApiController] DataContext context

    public class ProductsService : IProducts
    {
        private DataContext _context;
        protected readonly string conn;

        public ProductsService(DataContext context)
        {

            _context = context;
            conn = JsonConfigurationHelper.GetConstring("ProductConnection", true);//appsettings.json  by sun 2020.4.13


        }
        public ProductsService(string conn)
        {
            this.conn = conn;
        }

         
        public void Dispose()
        {
            GC.Collect();
        }

        /*
         * 
        
        public Task<Product[]> GetPizzasAsync()
        {

            // Call your data access technology here


        }
        */

        public IEnumerable<Product> QueryProducts()
        {
            IEnumerable<Product> result;
            IDbConnection connection = new MySqlConnection(conn);
            var sql = "SELECT  ProductId*11 as ProductId, Name as Name,Price+0.33  as Price FROM  Products";
            var query = connection.Query<Product>(sql);
            result = query.ToList();

            return result;
        }


        public Task<Product[]> GetDatatAsync2()

        {

            IEnumerable<Product>? products = null;

            products = _context.products
           .OrderBy(x => x.ProductId)
           .ToList();

            int count = products.Count();

            return Task.FromResult(products.ToArray());

        }


        public async Task<IEnumerable<Product>> GetDatatAsync()
        {
            try
            {
                return await _context.products
               .OrderBy(x => x.ProductId)
               .ToListAsync();
            }
            catch (Exception e)
            {

                Console.Write(e.Message);

                return Enumerable.Empty<Product>();

            }

            /*
        .Include(x => x.Name)

       */

        }



        private static readonly string[] Summaries = new[]
      {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public Task<Product[]> GetProducts()
        {

            IEnumerable<Product> query=_context.products
                                    .Where(result => result.Price > 10);
            
            return Task.FromResult(query.Select(index => new Product
            {

                ProductId=index.ProductId,
                Name = "_"+index.Name,
                Price=index.Price+155,

            }).ToArray());

        }


    }
}

