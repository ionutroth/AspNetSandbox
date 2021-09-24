// <copyright file="FileOperationWithBooks.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Tests
{
    using System;
    using System.IO;
    using System.Text;
    using Xunit;

    public class FileOperationWithBooks
    {
        [Fact]
        public void EnumerateFilesTest()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("../../../JsonFiles");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        [Fact]
        public void CreateFilesTest()
        {
            File.WriteAllText("newSettings.json", @"
                {
                  ""ConnectionStrings"": {
                                ""DefaultConnection"": ""Database=d545glcl8dohbn; Host=ec2-54-170-163-224.eu-west-1.compute.amazonaws.com; Port=5432; User Id=httftxiiqnwaqu; Password=a6b2fbfb56e6327fa51005fdf36660ec4d7642bd431537540c0183f627e6e4eb; SSL Mode=Require;Trust Server Certificate=true"",
                    ""NewDefaultConnection"": ""Database=Sandbox; Host=localhost; Port=5432; User Id=postgres; Trust Server Certificate=true; Password=roio22011998"",
                    ""SqlConnection"": ""Server=(localdb)\\mssqllocaldb;Database=aspnet-AspNetSandbox-BEA85DE8-72E5-4681-88CF-5254256EA676;Trusted_Connection=True;MultipleActiveResultSets=true"",
                    ""PostgresqlLocalConnection"": ""Server=127.0.0.1;Port=5432;Database=AspNetDatabase;User Id=postgres;Password=roio22011998;"",
                    ""Heroku"": ""postgres://httftxiiqnwaqu:a6b2fbfb56e6327fa51005fdf36660ec4d7642bd431537540c0183f627e6e4eb@ec2-54-170-163-224.eu-west-1.compute.amazonaws.com:5432/d545glcl8dohbn""
                  },
                  ""Logging"": {
                                ""LogLevel"": {
                                    ""Default"": ""Information"",
                      ""Microsoft"": ""Warning"",
                      ""Microsoft.Hosting.Lifetime"": ""Information""
                                }
                            },
                  ""AllowedHosts"": ""*""
                }");
        }

        [Fact]
        public void ReadFilesTest()
        {
            using (var fs = File.OpenRead("../../../JsonFiles/newSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    var returnedstring = temp.GetString(b);
                    Console.WriteLine(returnedstring);
                }
            }
        }
    }
}
