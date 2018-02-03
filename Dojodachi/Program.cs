using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Dojodachi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
                // New Use method
                .UseIISIntegration()
                .Build();
            host.Run();
        }
    }
}
