using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Spy.Library;
using Spy.Library.Services;
using Spy.WebApi.Controllers;

namespace Spy.WebApi.Tests
{
    [TestFixture]
    public class CipherWebApiTests
    {
        [TestCase("Found", true)]
        [TestCase("Not Found", false)]
        public void Should_return_status_code_200_with_successful_request_to_cipher_controller(string responseMessage, bool success)
        {
            const string message = "1,2,3";
            const string spyName = "James Bond";

            //arrange
            var mockCipherService = new Mock<ICipherService>();
            var response = new Response() { Message = responseMessage, StatusCode = 200, Success = success };

            mockCipherService.Setup(x => x.Decode(message, spyName)).Returns(response);

            var controller = new CipherController(mockCipherService.Object);

            //act
            var result = controller.Get(message, spyName) as ObjectResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 200);
            Assert.AreEqual(result.Value, responseMessage);
        }

        [TestCase("1,2,3", null)]
        [TestCase(null, "James Bond")]
        public void Should_return_status_code_400_with_null_passed_to_controller(string message, string spyName)
        {
            //arrange
            var mockCipherService = new Mock<ICipherService>();

            mockCipherService.Setup(x => x.Decode(message, spyName)).Returns(new Response());

            var controller = new CipherController(mockCipherService.Object);

            //act
            var result = controller.Get(message, null) as ObjectResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 400);
            Assert.AreEqual(result.Value, "Bad Data: message and codeName must be populated.");
        }
    }
}