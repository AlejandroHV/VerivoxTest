using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Application.Configurations;
using VerivoxTest.Domain.Models.Entities.Implementation;
using VerivoxTest.Infrastructure.FileContext;

namespace VerivoxTest.UnitTests.Infrastructure.FileContext
{
    [TestFixture]
    public class FileContextTests
    {

        [SetUp]
        protected void SetUp()
        {
          
           
        }

        [Test]
        public void FileContext_FilePathNotSet_ThrowsException() 
        {


            TestDelegate testDelegate = () => { new VerivoxTest.Infrastructure.FileContext.FileContext(); };
            Assert.Throws<Exception>(testDelegate, "Invalid file path. Could not Initialize the data source");

        }

       

        [Test]
        public void FileContext_FilePathNotSet_DoesNotThrowsException()
        {

            AppSettingsBinding.MockDataFilePath = "./Assets/MockError.json";

            TestDelegate testDelegate = () => { new VerivoxTest.Infrastructure.FileContext.FileContext(); };

            Assert.Throws<Exception>(testDelegate, "Could not initialize the data source");
        }

        [Test]
        public void FileContext_FilePathSet_DoesNotThrowsException()
        {

            AppSettingsBinding.MockDataFilePath = "./Assets/MockData.json";

            TestDelegate testDelegate = () => { new VerivoxTest.Infrastructure.FileContext.FileContext(); };
            

            Assert.DoesNotThrow(testDelegate);
        }

        [Test]
        public void FileContext_FilePathSet_ProductsSetHasData()
        {

            AppSettingsBinding.MockDataFilePath = "./Assets/MockData.json";

            var sut=  new VerivoxTest.Infrastructure.FileContext.FileContext(); 

        
            Assert.That(sut.Products.Count,Is.GreaterThan(0) );
        }

    }
}
