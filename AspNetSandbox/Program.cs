// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox
{
    using System;
    using System.Data;
    using System.IO;
    using AutoMapper.Configuration;
    using CommandLine;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            [Option('c', "connection", Required = false, HelpText = "Nam")]
            public string Connection { get; set; }
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

                       if (o.Connection == null)
                       {
                           Console.WriteLine("please select a string");
                       }
                       else
                       {
                           Console.WriteLine("string selected");
                           var validity = TestConnectionString(o.Connection);
                           if (validity)
                           {
                               Console.WriteLine("great string, very good job");
                           }
                           else
                           {
                               Console.WriteLine("nope");
                           }
                       }
                   });
            if (args.Length > 0)
            {
                Console.WriteLine($"There are {args.Length} elements in args");
                Console.WriteLine($"Connection string selected:{args[1]}");
            }
            else
            {
                Console.WriteLine("no arguments");
            }

            CreateHostBuilder(args).Build().Run();
            return 0;

            static bool TestConnectionString(string connectionString)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        return conn.State == ConnectionState.Open;
                    }
                    catch
                    {
                        return false;
                    }
                }
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
