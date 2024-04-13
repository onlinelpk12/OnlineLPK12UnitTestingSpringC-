using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineLpk12.Controllers;
using OnlineLpk12.Data.Entities;
using OnlineLpk12.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Test
{
    [TestClass]
    public class TeacherControllerTest
    {
        private TeacherController _controller;
        private Mock<ITeacherService> _mockTeacherService;
        private Mock<IUserService> _mockUserService;
        private Mock<ILogService> _mockLogService;
        private Fixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _mockTeacherService = new Mock<ITeacherService>();
            _mockUserService = new Mock<IUserService>();
            _mockLogService = new Mock<ILogService>();
            _fixture = new Fixture();
            _controller = new TeacherController(_mockTeacherService.Object, _mockUserService.Object, _mockLogService.Object);
        }

        [TestMethod]
        public async Task GetCourses_WithValidUserId_ReturnsOkResult()
        {
            int userId = 1;
            var courses = _fixture.Create<List<Course>>();
            _mockUserService.Setup(service => service.IsUserTeacher(userId)).ReturnsAsync(true);
            _mockTeacherService.Setup(service => service.GetCourses(userId)).ReturnsAsync(new Result<List<Course>> { Content = courses });

            var result = await _controller.GetCourses(userId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<List<Course>>;
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(courses, response.Content);
        }

        [TestMethod]
        public async Task GetStudentsForCourse_WithValidUserIdAndCourseId_ReturnsOkResult()
        {
            int userId = 1;
            int courseId = 1;
            var students = _fixture.Create<List<Student>>();
            var expectedResult = new Result<List<Student>> { Content = students };
            _mockUserService.Setup(service => service.IsUserTeacher(userId)).ReturnsAsync(true);
            _mockTeacherService.Setup(service => service.GetStudentsForCourse(userId, courseId)).ReturnsAsync(expectedResult);

            var result = await _controller.GetStudentsForCourse(userId, courseId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<List<Student>>;
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(students, response.Content);
        }

        [TestMethod]
        public async Task GetSparcList_WithValidUserId_ReturnsOkResult()
        {
            int userId = 1;
            var sparcPrograms = _fixture.Create<List<SparcProgram>>();
            var expectedResult = new Result<List<SparcProgram>> { Content = sparcPrograms };
            _mockTeacherService.Setup(service => service.GetSparcList(userId)).ReturnsAsync(expectedResult);

            var result = await _controller.GetSparcList(userId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<List<SparcProgram>>;
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(sparcPrograms, response.Content);
        }

        [TestMethod]
        public async Task GetSparcProgram_WithValidParameters_ReturnsOkResult()
        {
            int userId = 1;
            int lessonId = 1;
            int learningOutcome = 1;
            var sparcProgram = _fixture.Create<SparcProgram>();
            var expectedResult = new Result<SparcProgram> { Content = sparcProgram };
            _mockTeacherService.Setup(service => service.GetSparcProgram(userId, lessonId, learningOutcome)).ReturnsAsync(expectedResult);

            var result = await _controller.GetSparcProgram(userId, lessonId, learningOutcome);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<SparcProgram>;
            Assert.IsNotNull(response);
            Assert.AreEqual(sparcProgram, response.Content);
        }

        [TestMethod]
        public async Task GetLessonProgressList_WithValidUserId_ReturnsOkResult()
        {
            int userId = 1;
            var lessonProgressList = _fixture.Create<List<LessonProgress>>();
            var expectedResult = new Result<List<LessonProgress>> { Content = lessonProgressList };
            _mockTeacherService.Setup(service => service.GetLessonProgressList(userId)).ReturnsAsync(expectedResult);

            var result = await _controller.GetLessonProgressList(userId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<List<LessonProgress>>;
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(lessonProgressList, response.Content);
        }

        [TestMethod]
        public async Task GetAssessments_WithValidUserId_ReturnsOkResult()
        {
            int userId = 1;
            var assessmentOverviewList = _fixture.Create<List<AssessmentOverview>>();
            var expectedResult = new Result<List<AssessmentOverview>> { Content = assessmentOverviewList };
            _mockTeacherService.Setup(service => service.GetAssessments(userId)).ReturnsAsync(expectedResult);

            var result = await _controller.GetAssessments(userId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<List<AssessmentOverview>>;
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(assessmentOverviewList, response.Content);
        }

        [TestMethod]
        public async Task GetAssessmentDetails_WithValidParams_ReturnsOkResult()
        {
            int userId = 1;
            int lessonId = 1;
            int learningOutcome = 1;
            var assessment = _fixture.Create<Assessment>();
            var expectedResult = new Result<Assessment> { Content = assessment, Success = true };
            _mockTeacherService.Setup(service => service.GetAssessmentDetails(userId, lessonId, learningOutcome)).ReturnsAsync(expectedResult);

            var result = await _controller.GetAssessmentDetails(userId, lessonId, learningOutcome);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<Assessment>;
            Assert.IsNotNull(response);
            Assert.AreEqual(assessment, response.Content);
        }

    }
}
