using BlazorServer._6._2.Data;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BootstrapServerSide.Shared.Data;
using BlazorServer._6._2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//2022.6.2 注入context
builder.Services.AddDbContext<DataContext>(options =>
  options.UseMySql(builder.Configuration
         .GetConnectionString("ProductConnection")
         , MySqlServerVersion.LatestSupportedServerVersion));


builder.Services.AddScoped<IProducts, ProductsService>();// 微软自带的DI,可以实现构造器注入
//6.2
//builder.Services.AddSingleton<Product_Service>();

builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
