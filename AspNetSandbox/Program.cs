// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox
{
    using System;
    using System.Data;
    using System.IO;
    using AspNetSandbox.Data;
    using AutoMapper.Configuration;
    using CommandLine;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Npgsql;

    public class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            [Option('c', "connection", Required = false, HelpText = "Set a connection string.")]
            public string Connection { get; set; }

            [Option('h', "help", Required = false, HelpText = "Help menu.")]
            public bool Help { get; set; }
        }

        public enum ExitCodes
        {
            NoErrors = 0,
            InvalidArgument = 1
        }

        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example!");
                       }

                       if (o.Help)
                       {
                           Console.WriteLine(" v -- Set output to verbose messages.");
                           Console.WriteLine(" c -- Set a connection string.");
                           Console.WriteLine(" h -- Help menu.");
                       }

                       if (o.Connection == null)
                       {
                           Console.WriteLine("Please select a string.");
                       }
                       else
                       {
                           var host = CreateHostBuilder(args).Build();
                           var config = host.Services.GetRequiredService<Microsoft.Extensions.Configuration.IConfiguration>();
                           var services = host.Services.GetRequiredService<IServiceCollection>();
                           services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(config.GetConnectionString($"{o.Connection}")));

                           Console.WriteLine("string selected");

                           TestConnectionString(o.Connection);
                       }
                   });
            if (args.Length > 0)
            {
                Console.WriteLine($"There are {args.Length} elements in args");
                Console.WriteLine($"Connection string selected:{args[0]}");
            }
            else
            {
                Console.WriteLine("no arguments");
            }

            CreateHostBuilder(args).Build().Run();
            return 0;

            static void TestConnectionString(string connectionString)
            {
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Success open postgreSQL connection.");
                }

                conn.Close();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}
