using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace BootstrapServerSide.Shared.Data
{
  //  [ApiController]
  //  [Route("[controller]/[action]")] //

//这里要注册DI
    public class ProductControlls
    {
        private  DataContext _context;


        public ProductControlls(DataContext context)
        {

               _context= context;


        }

        public void Dispose()
        {
            GC.Collect();
        }


        public static Dictionary<string, object> ListToDic<T>(List<T> list, int count) where T : class
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("code", "0");
            dic.Add("msg", "");
            dic.Add("count", count);
            dic.Add("data", list);
            return dic;
        }

        
       // [HttpGet]
        public  IEnumerable<Product> Get()
        {

                       
                int i = 0;
                i = Random.Shared.Next(0, 15);

                var result = (from a in _context.products
                              select a)
                             .ToArray();
                ;

                IEnumerable<Product> query
                    = result.Where(result => result.Price>0);

                return query;


         }



        
        public Task<Product[]> GetDatatAsync()
        {
            var result = (from a in _context.products
                          select a)
                         .ToArray();
            ;

            IEnumerable<Product> query
                = result.Where(result => result.Price > 0);


            return Task.FromResult(query.Select(index => new Product
            {                                

            }).ToArray());
        }


        private static readonly string[] Summaries = new[]
      {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public Task<Product[]> GetProducts()
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Product
            {
               Name = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }

    }
}
