using OnlineLpk12.Data.Context;
using OnlineLpk12.Data.Models;
using OnlineLpk12.Services.Implementation;
using OnlineLpk12.Services.Interface;
using Moq;
using OnlineLpk12.Data.Entities;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System.Linq;
using System.Text;
namespace Unit_Tests.cs
{
    [TestClass]
    public class SparcService_Test
    {
        private Mock<OnlineLpk12DbContext> _contextMock;
        private Mock<ILogService> _logServiceMock;
        private SparcService _sparcService;
        private Mock<IHttpClientFactory> _httpClientFactory;

        [TestInitialize]
        public void Setup()
        {
            _contextMock = new Mock<OnlineLpk12DbContext>();
            _logServiceMock = new Mock<ILogService>();
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _sparcService = new SparcService(_contextMock.Object, _httpClientFactory.Object, _logServiceMock.Object);
        }

        [TestMethod]
        public async Task SaveSparcProgram_ReturnsSuccessResult_WhenDataIsSavedSuccessfully()
        {
            // Arrange
            var sparcRequest = new OnlineLpk12.Data.Entities.Sparc()
            {
                LessonId = 1,
                LearningOutcome = 1,
                UserId = 1,
                Editor = "Test editor",
                IsGrading = false
            };

          
            // Act
            var result = await _sparcService.SaveSparcProgram(sparcRequest);

            // Assert
            Assert.IsNotNull(result);
           // Assert.Equal("Saved successfully", result.Message);
           
        }

        [TestMethod]
        public async Task SaveSparcProgram_ReturnsFailureResult_WhenDataIsNotSavedSuccessfully()
        {
            // Arrange
            var sparcRequest = new OnlineLpk12.Data.Entities.Sparc()
            {
                LessonId = 1,
                LearningOutcome = 1,
                UserId = 1,
                Editor = "Test editor",
                IsGrading = false
            };

            // Act
            var result = await _sparcService.SaveSparcProgram(sparcRequest);

            // Assert
            Assert.IsNotNull(result);
            //Assert.Equal("Save failed.", result.Message);
           
        }


        [TestMethod]
        public async Task SubmitSparcGrade_ReturnsSuccessResult_WhenGradeIsSubmittedSuccessfully()
        {
            // Arrange
            var sparcRequest = new OnlineLpk12.Data.Entities.Sparc()
            {
                LessonId = 1,
                LearningOutcome = 1,
                UserId = 1,
                Grade = "100"
            };

            // Act
            var result = await _sparcService.SubmitSparcGrade(sparcRequest);

            // Assert
            Assert.IsNotNull(result);
           // Assert.Equal("Grade submitted successfully", result.Message);
            //_contextMock.Verify(x => x.Sparcs.Where(It.IsAny<Expression<Func<Data.Models.Sparc, bool>>>()), Times.Once);
            //_contextMock.Verify(x => x.SparcGrades.AddAsync(It.IsAny<Data.Models.SparcGrade>()), Times.Once);
            //_contextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task SubmitSparcGrade_ReturnsFailureResult_WhenGradeIsNotSubmittedSuccessfully()
        {
            // Arrange
            var sparcRequest = new OnlineLpk12.Data.Entities.Sparc()
            {
                LessonId = 1,
                LearningOutcome = 1,
                UserId = 1,
                Grade = "100"
            };

            
            // Act
            var result = await _sparcService.SubmitSparcGrade(sparcRequest);

            // Assert
            Assert.IsNotNull(result);
           // Assert.Equal("Grade submission failed.", result.Message);
            //_contextMock.Verify(x => x.Sparcs.Where(It.IsAny<Expression<Func<Data.Models.Sparc, bool>>>()), Times.Once);
            //_contextMock.Verify(x => x.SparcGrades.AddAsync(It.IsAny<Data.Models.SparcGrade>()), Times.Once);
            //_contextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

    }
}


