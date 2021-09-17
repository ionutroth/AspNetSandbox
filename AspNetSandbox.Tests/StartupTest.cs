using Xunit;

namespace AspNetSandbox.Tests
{
    public class StartupTest
    {
        [Fact]
        public void CheckConversionToEFConnectionString()
        {
            // Assume
            string databaseURL = "postgres://httftxiiqnwaqu:a6b2fbfb56e6327fa51005fdf36660ec4d7642bd431537540c0183f627e6e4eb@ec2-54-170-163-224.eu-west-1.compute.amazonaws.com:5432/d545glcl8dohbn";

            // Act
            string convertedConnectionString = Startup.ConvertConnectionString(databaseURL);

            // Assert
            Assert.Equal("Database = d545glcl8dohbn; Host = ec2 - 54 - 170 - 163 - 224.eu - west - 1.compute.amazonaws.com; Port = 5432; User Id = httftxiiqnwaqu; Password = a6b2fbfb56e6327fa51005fdf36660ec4d7642bd431537540c0183f627e6e4eb; SSL Mode = Require; Trust Server Certificate = true", convertedConnectionString);
        }
    }
}
