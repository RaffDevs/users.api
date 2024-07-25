using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Users.Api;

 var builder = Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
 
builder.Build().Run();

