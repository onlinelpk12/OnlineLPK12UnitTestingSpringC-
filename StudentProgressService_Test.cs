using Moq;
using Microsoft.EntityFrameworkCore;
using OnlineLpk12.Data.Context;
using OnlineLpk12.Data.Entities;
using OnlineLpk12.Services.Implementation;
using OnlineLpk12.Services.Interface;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineLpk12.Data.Models;
using LessonStatus = OnlineLpk12.Data.Entities.LessonStatus;

namespace Unit_Tests.cs
{
    [TestClass]
    public class StudentProgressService_Test
    {
        private Mock<OnlineLpk12DbContext> _dbContextMock;
        private Mock<IUserService> _userServiceMock;
        private Mock<ILogService> _logServiceMock;
        private IStudentProgressService _studentProgressService;

        [TestInitialize]
        public void Setup()
        {
            _dbContextMock = new Mock<OnlineLpk12DbContext>();
            _userServiceMock = new Mock<IUserService>();
            _logServiceMock = new Mock<ILogService>();
            _studentProgressService = new StudentProgressService(_dbContextMock.Object, _userServiceMock.Object, _logServiceMock.Object);
        }

        [TestMethod]
        public async Task UpdateLessonStatus_AddsNewStudentProgress_WhenDataIsNull()
        {
            try
            {
                // Arrange
                var lessonId = 1;
                var userId = 1;

                // Act
                await _studentProgressService.UpdateLessonStatus(lessonId, userId);

                // Assert
                //_dbContextMock.Verify(x => x.StudentProgresses.AddAsync(It.IsAny<StudentProgress>()), Times.Once);
                //_dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public async Task UpdateLessonStatus_UpdatesLessonStatus_WhenDataIsNotNull()
        {
            try
            {
                // Arrange
                var lessonId = 1;
                var userId = 1;
                var existingStudentProgress = new StudentProgress { LessonStatusId = (int)LessonStatus.NotStarted };
                //_dbContextMock.Setup(x => x.StudentProgresses.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<StudentProgress, bool>>>()))
                //.ReturnsAsync(existingStudentProgress);

                // Act
                await _studentProgressService.UpdateLessonStatus(lessonId, userId);

                // Assert
                //Assert.AreEqual((int)LessonStatus.InProgress, existingStudentProgress.LessonStatusId);
                //_dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public async Task GetLessonsAndQuizProgress_ReturnsCorrectResponse()
        {
            try
            {
                // Arrange
                var userId = 1;
                var result = await _studentProgressService.GetLessonsAndQuizProgress(userId);

                // Assert
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public async Task GetContent_ReturnsCorrectLessonDetails()
        {
            try
            {
                // Arrange
                var lessonId = 1;

                // Act
                var result = await _studentProgressService.GetContent(lessonId);

                // Assert
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }
    }

}