using VerivoxTest.Application.Configurations;
using InfraFileContext = VerivoxTest.Infrastructure.FileContext;

namespace VerivoxTest.UnitTests.Tests.InfrastructureLayer.FileContext
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


            TestDelegate testDelegate = () => { new InfraFileContext.FileContext(); };
            Assert.Throws<Exception>(testDelegate, "Invalid file path. Could not Initialize the data source");

        }



        [Test]
        public void FileContext_FilePathNotSet_DoesNotThrowsException()
        {

            AppSettingsBinding.MockDataFilePath = "./Assets/MockError.json";

            TestDelegate testDelegate = () => { new InfraFileContext.FileContext(); };

            Assert.Throws<Exception>(testDelegate, "Could not initialize the data source");
        }

        [Test]
        public void FileContext_FilePathSet_DoesNotThrowsException()
        {

            AppSettingsBinding.MockDataFilePath = "./Assets/MockData.json";

            TestDelegate testDelegate = () => { new InfraFileContext.FileContext(); };


            Assert.DoesNotThrow(testDelegate);
        }

        [Test]
        public void FileContext_CorrectMockFileSent_ProductsSetHasData()
        {

            AppSettingsBinding.MockDataFilePath = "./Assets/MockData.json";

            var sut = new InfraFileContext.FileContext();


            Assert.That(sut.Products.Count, Is.GreaterThan(0));
        }

    }
}
