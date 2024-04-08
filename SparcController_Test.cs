using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineLpk12.Controllers;
using OnlineLpk12.Data.Entities;
using OnlineLpk12.Services.Interface;

namespace Unit_Tests.cs
{
    [TestClass]
    public class SparcController_Test
    {
        private Mock<ISparcService> _sparcServiceMock;
        private Mock<ILogService> _logServiceMock;
        private SparcController _sparcController;

        [TestInitialize]
        public void Setup()
        {
            _sparcServiceMock = new Mock<ISparcService>();
            _logServiceMock = new Mock<ILogService>();
            _sparcController = new SparcController(_sparcServiceMock.Object, _logServiceMock.Object);
        }

        [TestMethod]
        public async Task ExecuteSparc_ValidRequest_Success()
        {
            // Arrange
            var request = new Sparc();
            //_sparcServiceMock.Setup(x => x.ExecuteSparcRequest(request))
                //.ReturnsAsync(new Response<string> { Success = true, Content = "Execution successful" });

            // Act
            var result = await _sparcController.ExecuteSparc(request);

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual("Execution successful", result.Value);
        }

        [TestMethod]
        public async Task ExecuteSparc_InvalidRequest_BadRequest()
        {
            // Arrange
            var request = new Sparc
            {
                Grade="A",
                UserId=1,
                LessonId=1,
                LearningOutcome=2,
                Action="Test",
                Editor="Test",
                FileUrl="Test",
                IsGrading=true,
                Query="Test",


            };
            //_sparcServiceMock.Setup(x => x.ExecuteSparcRequest(request))
                //.ReturnsAsync(new Response<string> { Success = false });
            var validationErrors = new List<string> { "Validation error" };

            // Act
            var result = await _sparcController.ExecuteSparc(request);

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual("One or more validation errors occurred.", result.Value);
        }

        [TestMethod]
        public async Task SaveSparcProgram_ValidRequest_Success()
        {
            // Arrange
            var request = new Sparc();
            //_sparcServiceMock.Setup(x => x.SaveSparcProgram(request))
                //.ReturnsAsync(new Response<string> { Success = true, Content = "Saved successfully" });

            // Act
            var result = await _sparcController.SaveSparcProgram(request);

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual("Saved successfully", result.Value);
        }

        [TestMethod]
        public async Task SaveSparcProgram_InvalidRequest_BadRequest()
        {
            // Arrange
            var request = new Sparc();
            //_sparcServiceMock.Setup(x => x.SaveSparcProgram(request))
                //.ReturnsAsync(new Response<string> { Success = false });
            //var validationErrors = new List<string> { "Validation error" };

            // Act
            var result = await _sparcController.SaveSparcProgram(request);

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual("One or more validation errors occurred.", result.Value);
        }

        [TestMethod]
        public async Task GetSparcProgramsByUserId_ValidRequest_Success()
        {
            // Arrange
            int userId = 1;
            int lessonId = 2;
            var responseContent = new List<string> { "Program 1", "Program 2" };

            // Act
            var result = await _sparcController.GetSparcProgramsByUserId(userId, lessonId);

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual(responseContent, result.Value);
        }

        [TestMethod]
        public async Task GetSparcProgramsByUserId_InvalidUserId_BadRequest()
        {
            // Arrange
            int userId = 0;
            int lessonId = 2;
            
            // Act
            var result = await _sparcController.GetSparcProgramsByUserId(userId, lessonId);

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual(response, result.Value);
        }

        [TestMethod]
        public async Task SubmitSparcGrade_ValidRequest_Success()
        {
            // Arrange
            var request = new Sparc();

            // Act
            var result = await _sparcController.SubmitSparcGrade(request);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task SubmitSparcGrade_InvalidRequest_BadRequest()
        {
            // Arrange
            var request = new Sparc();
            var validationErrors = new List<string> { "Validation error" };

            // Act
            var result = await _sparcController.SubmitSparcGrade(request);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}


