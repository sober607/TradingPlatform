using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using TradingPlatform.Infrastructure.Services.Implementations;

namespace XUnitTestsTradingPlatform.InfrastructureTests
{
    public class GenerateItemFileNameShould
    {
        [Fact]
        public void ReturnFileName()
        {
            //Arrange
            var mock = new Mock<IWebHostEnvironment>();
            var testFileName = "Somefile.exe";
            var expectedRegexPattern =
@"[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}";
            FileService fileservice = new FileService(mock.Object);

            //act
            var generatedFileName =
fileservice.GenerateItemFileName(testFileName);

            //assert
            Assert.Matches(expectedRegexPattern, generatedFileName);
        }
    }
}
