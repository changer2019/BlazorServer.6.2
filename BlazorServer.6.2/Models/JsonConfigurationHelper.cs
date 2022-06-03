using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CJ.Common
{
    public static class JsonConfigurationHelper
    {
        public static IConfigurationRoot Configuration { get; set; }

       // public static IHostingEnvironment Env { get; set; }

        public static T GetAppSettings<T>(string key) where T : class, new()
        {
            var baseDir = AppContext.BaseDirectory;
            var indexSrc = baseDir.IndexOf("src");
            var subToSrc = baseDir.Substring(0, indexSrc);
            var currentClassDir = subToSrc + "src" + Path.DirectorySeparatorChar + "EFCore.SignIn";

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(currentClassDir)
                .Add(new JsonConfigurationSource { Path = "appsettings.json", Optional = false, ReloadOnChange = true })
                .Build();
        
            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appconfig;
        }

        /// <summary>
        /// 按key获取appsettings.json连接数据库字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConstring(string key, bool isDebug)
        {
            var bd = AppContext.BaseDirectory;
            if (isDebug)
            {
                var indexSrc = bd.IndexOf("bin");
                var subToSrc = bd.Substring(0, indexSrc);
                bd = subToSrc;
            }
            var build = new ConfigurationBuilder()
                            .SetBasePath(bd)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = build.Build();
            return Configuration.GetConnectionString(key);
        }

    }
}
