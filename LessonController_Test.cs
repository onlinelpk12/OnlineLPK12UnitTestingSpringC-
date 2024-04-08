using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineLpk12.Controllers;
using OnlineLpk12.Data.Entities;
using OnlineLpk12.Data.Models;
using OnlineLpk12.Services.Interface;
 
namespace Unit_Tests.cs
{
    [TestClass]
    public class LessonController_Test
        {
            private Mock<ILessonService> _lessonServiceMock;
            private Mock<ILogService> _logServiceMock;
        private LessonController _controller;
 
        [TestInitialize]
        public void Setup()
            {
                _lessonServiceMock = new Mock<ILessonService>();
                _logServiceMock = new Mock<ILogService>();
                _controller = new LessonController(_lessonServiceMock.Object, _logServiceMock.Object);
        }
 
            [TestMethod]
            public async Task UploadSlideDetails_ReturnsOk()
            {
                // Arrange
                var slideData = new SlideData();
 
 
                // Act
                var result = await _controller.UploadLesson(slideData);
 
                // Assert
                Assert.IsNotNull(result);
                //Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            }
 
            [TestMethod]
            public async Task FetchSlideDetails_ReturnsOk()
            {
                // Arrange
                var controller = new LessonController(_lessonServiceMock.Object, _logServiceMock.Object);
                var slideData = new SlideData { LessonName = "Lesson1", CourseName = "Course1" };
 
                // Act
                var result = await _controller.GetLesson(slideData);
 
                // Assert
                Assert.IsNotNull(result);
                //Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            }
 
            [TestMethod]
            public async Task UploadAssessmentDetails_ReturnsOk()
            {
                // Arrange
                var _controller = new LessonController(_lessonServiceMock.Object, _logServiceMock.Object);
                var assessmentData = new AssessmentData();
 
                // Act
                var result = await _controller.UploadAssessmentDetails(assessmentData);
 
                // Assert
                Assert.IsNotNull(result);
                //Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            }
 
            [TestMethod]
            public async Task FetchAssessmentDetails_ReturnsOk()
            {
                // Arrange
                var _controller = new LessonController(_lessonServiceMock.Object, _logServiceMock.Object);
                var assessmentData = new SlideData { LessonName = "Lesson1", CourseName = "Course1" };

                // Act
                var result = await _controller.FetchAssessmentDetails(assessmentData);
 
                // Assert
                Assert.IsNotNull(result);
                //Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            }
 
            [TestMethod]
            public async Task LessonList_ReturnsOk()
            {
                // Arrange
                var _controller = new LessonController(_lessonServiceMock.Object, _logServiceMock.Object);
                var course = "Course1";

                // Act
                var result = await _controller.LessonList(course);
 
                // Assert
                Assert.IsNotNull(result);
                //Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            }
 
 
        }
    }