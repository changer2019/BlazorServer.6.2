/*
 * *
 * 安装Pomelo.EntityFrameworkCore.MySql
 * 替换MySql.Data.EntityFrameworkCore
 * 就可以CodeFirst(Add-Migration InitialCreate，Update-Database)。
 */
//using AutoMapper.Extensions.Microsoft.DependencyInjection;
//using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models {
    public class Product {

        
        /*
        public int? Id { get; set; } 

        public string fId { get; set; }

        public bool? fDeleted { get; set; }

        public DateTime? fCreateDate { get; set; }

        */

        public long ProductId { get; set; }
        
        [Comment("用户名"), MaxLength(50)]
        public string Name { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "价格不能低于1")]
        [Column(TypeName = "decimal(8, 2)")]

        public decimal? Price { get; set; }

        public long? CategoryId { get; set; }

        //导航属性
      //  public Category  Profile { get; set; }

        public long? SupplierId  { get; set; }

       // [Required(ErrorMessage = "供应商不能为空")]
      //  public Supplier Supplier { get; set; }

        //员工
       // public Guid? fEmployeeId { get; set; }



    }
}
