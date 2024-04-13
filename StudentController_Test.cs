using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineLpk12.Controllers;
using OnlineLpk12.Data.Entities;
using OnlineLpk12.Data.Models;
using OnlineLpk12.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Test
{
    [TestClass]
    public class StudentControllerTest
    {
        private StudentController _controller;
        private Mock<IStudentService> _mockStudentService;
        private Mock<ILogService> _mockLogService;
        private Fixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _mockStudentService = new Mock<IStudentService>();
            _mockLogService = new Mock<ILogService>();
            _fixture = new Fixture();
            _controller = new StudentController(_mockStudentService.Object, _mockLogService.Object);
        }

        [TestMethod]
        public async Task SaveLessonProgress_WithValidData_ReturnsOkResult()
        {
            int userId = 1;
            var lessonProgress = _fixture.Create<LessonProgress>();
            var successResponse = new SuccessResponse { IsSuccess = true };
            _mockStudentService.Setup(service => service.SaveLessonProgress(lessonProgress)).Returns(true);

            var result = await _controller.SaveLessonProgress(userId, lessonProgress);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<SuccessResponse>;
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Content.IsSuccess);
        }

        [TestMethod]
        public async Task SaveQuizQuestionAnswer_WithValidData_ReturnsOkResult()
        {
            int userId = 1;
            var quizQuestionAnswer = _fixture.Create<QuizQuestionAnswer>();
            quizQuestionAnswer.UserId = userId;
            var successResponse = new SuccessResponse { IsSuccess = true };
            _mockStudentService.Setup(service => service.SaveQuizQuestionAnswer(quizQuestionAnswer)).Returns(true);

            var result = await _controller.SaveQuizQuestionAnswer(userId, quizQuestionAnswer);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<SuccessResponse>;
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Content.IsSuccess);
        }

        [TestMethod]
        public async Task SaveAssessmentStatus_WithValidData_ReturnsOkResult()
        {
            int userId = 1;
            var assessmentOverview = _fixture.Create<AssessmentOverview>();
            assessmentOverview.StudentId = userId;
            var successResponse = new SuccessResponse { IsSuccess = true };
            _mockStudentService.Setup(service => service.SaveAssessmentScore(assessmentOverview)).Returns(true);

            var result = await _controller.SaveAssessmentStatus(userId, assessmentOverview);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as Response<SuccessResponse>;
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Content.IsSuccess);
        }


    }
}
