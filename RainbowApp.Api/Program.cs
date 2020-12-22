using System;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RainbowApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(builder =>
            {
                var environmentName = (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development").ToLower();
                
                AWSOptions awsOptions = null;

                if (Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID") != null)
                {
                    // Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID"));
                    // Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY"));
                    
                    awsOptions = new AWSOptions
                    {
                        Region = RegionEndpoint.APNortheast2,
                        Credentials = new EnvironmentVariablesAWSCredentials()
                    };
                }
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
