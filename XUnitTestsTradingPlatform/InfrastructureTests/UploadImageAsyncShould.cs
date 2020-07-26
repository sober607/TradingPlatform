using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TradingPlatform.Infrastructure.Services.Implementations;
using Xunit;

namespace XUnitTestsTradingPlatform.InfrastructureTests
{
    public class UploadImageAsyncShould
    {
        [Fact]
        public void ReturnNotNull()
        {
            //arrange
            var mockIwebHost = new Mock<IWebHostEnvironment>();
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(t => t.OpenReadStream()).Returns(ms);
            fileMock.Setup(t => t.FileName).Returns(fileName);
            fileMock.Setup(t => t.Length).Returns(ms.Length);

            FileService sut = new FileService(mockIwebHost.Object);

            //act
            var result = sut.UploadImageAsync(fileMock.Object);

            //result
            Assert.NotNull(result);
        }


    }
}
