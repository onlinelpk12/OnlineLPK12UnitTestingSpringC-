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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api_Test
{
    [TestClass]
    public class StudentProgressControllerTest
    {
        private StudentProgressController _controller;
        private Mock<IStudentProgressService> _mockStudentProgressService;
        private Mock<IUserService> _mockUserService;
        private Mock<ILogService> _mockLogService;
        private Fixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _mockStudentProgressService = new Mock<IStudentProgressService>();
            _mockUserService = new Mock<IUserService>();
            _mockLogService = new Mock<ILogService>();
            _fixture = new Fixture();
            _controller = new StudentProgressController(_mockStudentProgressService.Object,_mockLogService.Object);
        }

        [TestMethod]
        public async Task GetLessons_WithValidUserId_ReturnsOkResult()
        {
            int userId = 1;
            var lessonAndQuizProgressResponse = _fixture.Create<LessonAndQuizProgressResponse>();
            var response = new Response<LessonAndQuizProgressResponse> { Content = lessonAndQuizProgressResponse };
            _mockStudentProgressService.Setup(service => service.GetLessonsAndQuizProgress(userId)).ReturnsAsync(lessonAndQuizProgressResponse);

            var result = await _controller.GetLessons(userId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseData = okResult.Value as Response<LessonAndQuizProgressResponse>;
            Assert.IsNotNull(responseData);
            Assert.AreEqual(lessonAndQuizProgressResponse, responseData.Content);
        }

        [TestMethod]
        public async Task GetContentByLesson_WithValidLessonId_ReturnsOkResult()
        {
            int lessonId = 1;
            var lessonDetails = _fixture.Create<LessonDetails>();
            var response = new Response<LessonDetails> { Content = lessonDetails };
            _mockStudentProgressService.Setup(service => service.GetContent(lessonId)).ReturnsAsync(lessonDetails);

            var result = await _controller.GetContentByLesson(lessonId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseData = okResult.Value as Response<LessonDetails>;
            Assert.IsNotNull(responseData);
            Assert.AreEqual(lessonDetails, responseData.Content);
        }

        [TestMethod]
        public async Task UpdateLessonStatus_WithValidLessonAndUser_ReturnsOkResult()
        {
            var lessonStatusRequest = _fixture.Create<LessonStatusRequest>();
            var userResult = new Result<OnlineLpk12.Data.Entities.User>
            {
                Success = true,
                Content = new OnlineLpk12.Data.Entities.User { UserId = lessonStatusRequest.UserId, UserType = "STUDENT" }
            };
            var lessonResult = new Result<EmptyResult> { Success = true };
            _mockStudentProgressService.Setup(service => service.IsValidUser(lessonStatusRequest.UserId)).ReturnsAsync(userResult);
            _mockStudentProgressService.Setup(service => service.IsValidLesson(lessonStatusRequest.LessonId)).ReturnsAsync(lessonResult);

            var result = await _controller.UpdateLessonStatus(lessonStatusRequest);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseData = okResult.Value as Response<string>;
            Assert.IsNotNull(responseData);
            Assert.AreEqual($"Updated Lesson progress for lesson {lessonStatusRequest.LessonId}, student {lessonStatusRequest.UserId}", responseData.Content);
        }

        [TestMethod]
        public async Task GetQuiz_WithValidLessonIdAndUser_ReturnsOkResult()
        {
            int lessonId = 1;
            int? userId = 1;
            var quiz = _fixture.Create<Quiz>();
            var userResult = new Result<OnlineLpk12.Data.Entities.User>
            {
                Success = true,
                Content = new OnlineLpk12.Data.Entities.User { UserId = userId.Value, UserType = "STUDENT" }
            };
            _mockStudentProgressService.Setup(service => service.IsValidUser(userId.Value)).ReturnsAsync(userResult);
            _mockStudentProgressService.Setup(service => service.GetQuizIdByLessonId(lessonId)).ReturnsAsync(quiz.QuizId);
            _mockStudentProgressService.Setup(service => service.GetQuizForStudent(quiz.QuizId, userId)).ReturnsAsync(new Result<Quiz> { Success = true, Content = quiz });

            var result = await _controller.GetQuiz(lessonId, userId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseData = okResult.Value as Response<Quiz>;
            Assert.IsNotNull(responseData);
            Assert.AreEqual(quiz, responseData.Content);
        }

        [TestMethod]
        public async Task SubmitQuiz_WithValidData_ReturnsOkResult()
        {
            var quiz = _fixture.Create<SubmitQuiz>();
            var validationResult = new List<string>();
            _mockStudentProgressService.Setup(service => service.IsValidUser(quiz.UserId)).ReturnsAsync(new Result<OnlineLpk12.Data.Entities.User> { Success = true, Content = new OnlineLpk12.Data.Entities.User { UserId = quiz.UserId, UserType = "STUDENT" } });
            _mockStudentProgressService.Setup(service => service.ValidateSubmittedQuiz(quiz)).ReturnsAsync(string.Empty);
            _mockStudentProgressService.Setup(service => service.SubmitQuiz(quiz)).ReturnsAsync(quiz);

            var result = await _controller.SubmitQuiz(quiz);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseData = okResult.Value as Response<SubmitQuiz>;
            Assert.IsNotNull(responseData);
            Assert.AreEqual(quiz, responseData.Content);
        }

        [TestMethod]
        public async Task GetAllStudentsDetails_WithValidTeacher_ReturnsOkResult()
        {
            var userId = 123; 
            var students = _fixture.CreateMany<StudentDetails>().ToList();
            _mockStudentProgressService.Setup(service => service.IsUserTeacher(userId)).ReturnsAsync(true);
            _mockStudentProgressService.Setup(service => service.GetAllStudentDetails()).ReturnsAsync(students);

            var result = await _controller.GetAllStudentsDetails(userId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var responseData = okResult.Value as Response<List<StudentDetails>>;
            Assert.IsNotNull(responseData);
            CollectionAssert.AreEqual(students, responseData.Content);
        }
    }
}
