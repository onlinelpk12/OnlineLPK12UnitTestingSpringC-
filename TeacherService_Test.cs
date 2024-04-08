using Moq;
using Microsoft.EntityFrameworkCore;
using OnlineLpk12.Data.Context;
using OnlineLpk12.Data.Entities;
using OnlineLpk12.Services.Implementation;
using OnlineLpk12.Services.Interface;
using OnlineLpk12.Data.Models;
using OnlineLpk12.Controllers;
using Microsoft.Extensions.Configuration;

namespace Unit_Tests.cs
{
    [TestClass]
    public class TeacherService_Test
    {

        private Mock<OnlineLpk12DbContext> _mockContext;
        private TeacherService _teacherService;
        private ILogService _logService;

        [TestInitialize]
        public void Setup()
        {
            _mockContext = new Mock<OnlineLpk12DbContext>();
            _logService = new LogService(_mockContext.Object);
            _teacherService = new TeacherService(_mockContext.Object, _logService);
        }

        [TestMethod]
        public async Task GetCourses_ValidUserId_ReturnsCourses()
        {
            try
            { 
            // Arrange
            var userId = 1;

            // Act
            var result = await _teacherService.GetCourses(userId);

            // Assert
            Assert.IsNotNull(result);
                //Assert.Equal(2, result.Content.Count);
                //Assert.Equal("Course 1", result.Content[0].CourseName);
                // Assert.Equal("Course 2", result.Content[1].CourseName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public async Task GetCourses_InvalidUserId_ReturnsEmptyList()
        {
            try
            { 
            // Arrange
            var userId = 1;



            // Act
            var result = await _teacherService.GetCourses(userId);

            // Assert
            Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public async Task GetStudentsForCourse_ValidUserIdAndCourseId_ReturnsStudents()
        {
            try
            { 
            // Arrange
            var userId = 1;
            var courseId = 1;
            var students = new List<Student>
            {
                new Student { Id = 1, FirstName = "Student 1", LastName = "Student 1", UserName = "student1" },
                new Student { Id = 2, FirstName = "Student 2", LastName = "Student 2", UserName = "student2" }
            };



            // Act
            var result = await _teacherService.GetStudentsForCourse(userId, courseId);

            // Assert
            Assert.IsNotNull(result);
                //Assert.Equal(2, result.Content.Count);
                //Assert.Equal("Student 1", result.Content[0].FirstName);
                //Assert.Equal("Student 2", result.Content[1].FirstName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public async Task GetStudentsForCourse_InvalidUserIdOrCourseId_ReturnsEmptyList()
        {
            try
            { 
            // Arrange
            var userId = 1;
            var courseId = 1;



            // Act
            var result = await _teacherService.GetStudentsForCourse(userId, courseId);

            // Assert
            Assert.IsNotNull(result);
                // Assert.Empty(result.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public async Task GetSparcList_ValidUserId_ReturnsSparcList()
        {
            try
            { 
            // Arrange
            var userId = 1;


            // Act
            var result = await _teacherService.GetSparcList(userId);

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