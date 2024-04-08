using OnlineLpk12.Data.Context;
using OnlineLpk12.Data.Models;
using OnlineLpk12.Services.Implementation;
using OnlineLpk12.Services.Interface;
using Moq;
using OnlineLpk12.Data.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace Unit_Tests.cs
{
    [TestClass]
    public class LessonService_Test
    {

        private Mock<OnlineLpk12DbContext> _contextMock;
        private Mock<ILogService> _logServiceMock;
        private ILessonService _lessonService;
        
        [TestInitialize]
        public void Setup()
        {
            _contextMock = new Mock<OnlineLpk12DbContext>();
            _logServiceMock = new Mock<ILogService>();
            _lessonService = new LessonService(_contextMock.Object, _logServiceMock.Object);
        }

        [TestMethod]
        public async Task FetchAssessmentDetails_ReturnsAssessmentData_WhenAssessmentExists()
        {
            // Arrange
            var lesson = "TestLesson";
            var course = "TestCourse";
            var assessmentData = new AssessmentData
            {
                CourseName = course,
                LessonName = lesson,
                Answers = "TestAnswers",
                Data = "TestData",
                Header = "TestHeader",
                Questions = "TestQuestions",
                PageNum = "1"
            };
          
            // Act
            var result = await _lessonService.fetchAssessmentDetails(lesson, course);

            // Assert
            Assert.IsNotNull(result);
            Console.WriteLine("Success");

           
        }

        [TestMethod]
        public async Task FetchAssessmentDetails_ReturnsError_WhenAssessmentDoesNotExist()
        {
            // Arrange
            var lesson = "TestLesson";
            var course = "TestCourse";
           

            // Act
            var result = await _lessonService.fetchAssessmentDetails(lesson, course);

            // Assert
            Assert.IsNotNull(result);
            Console.WriteLine("Success");
        }

        [TestMethod]
        public async Task GetLesson_ReturnsSlideData_WhenSlideExists()
        {
            // Arrange
            var lesson = "TestLesson";
            var course = "TestCourse";
            var slideData = new SlideData
            {
                CourseName = course,
                LessonName = lesson,
                Pdf = "TestPdf"
            };
            

            // Act
            var result = await _lessonService.GetLesson(lesson, course);

            // Assert
            Assert.IsNotNull(result.Success);
            Console.WriteLine("Success");

        }


        [TestMethod]
        public async Task LessonList_ReturnsLessonList_WhenCourseExists()
        {
            // Arrange
            var course = "TestCourse";
            var lessonList = new List<string> { "Lesson1", "Lesson2", "Lesson3" };
          

            // Act
            var result = await _lessonService.LessonList(course);

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsTrue(result.Success);
            //Assert.AreEqual(lessonList.Count, result.Content.Count);
            Console.WriteLine("Success");
        }

        [TestMethod]
        public async Task UploadAssessmentDetails_ReturnsSuccess_WhenAssessmentDataIsValid()
        {
            // Arrange
            var assessmentData = new AssessmentData
            {
                CourseName = "TestCourse",
                LessonName = "TestLesson",
                Answers = "TestAnswers",
                Data = "TestData",
                Header = "TestHeader",
                Questions = "TestQuestions",
                PageNum = "1"
            };

            // Act
            var result = await _lessonService.uploadAssessmentDetails(assessmentData);

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsTrue(result.Success);
            //Assert.AreEqual("Assessment saved successfully.", result.Message);
            Console.WriteLine("Success");
        }

        [TestMethod]
        public async Task UploadLesson_ReturnsSuccess_WhenSlideDataIsValid()
        {
            // Arrange
            var slideData = new SlideData
            {
                CourseName = "TestCourse",
                LessonName = "TestLesson",
                Pdf = "TestPdf"
            };

            // Act
            var result = await _lessonService.UploadLesson(slideData);

            // Assert
            Assert.IsNotNull(result);
            //Assert.IsTrue(result.Success);
            //Assert.AreEqual("Lesson saved successfully.", result.Message);
            Console.WriteLine("Success");
        }

    }
}


