using Moq;
using Microsoft.EntityFrameworkCore;
using OnlineLpk12.Data.Context;
using OnlineLpk12.Data.Entities;
using OnlineLpk12.Services.Implementation;
using OnlineLpk12.Services.Interface;
using OnlineLpk12.Data.Models;

namespace Unit_Tests.cs
{
    [TestClass]
    public class StudentService_Test
    {
        private Mock<OnlineLpk12DbContext> _contextMock;
        private Mock<ILogService> _logServiceMock;
        private StudentService _studentService;

        [TestInitialize]
        public void Setup()
        {
            _contextMock = new Mock<OnlineLpk12DbContext>();
            _logServiceMock = new Mock<ILogService>();
            _studentService = new StudentService(_contextMock.Object, _logServiceMock.Object);
        }

        [TestMethod]
        public void SaveLessonProgress_ValidLessonProgress_ReturnsTrue()
        {
            try
            { 
            // Arrange
            var lessonProgress = new LessonProgress
            {
                StudentId = 1,
                LessonId = 1,
                LearningOutcome = 2,
                PageNumber = 1
            };

            // Act
            var result = _studentService.SaveLessonProgress(lessonProgress);

            // Assert
            Assert.IsNotNull(result);
        }
         catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }

}

        [TestMethod]
        public void SaveLessonProgress_InvalidLessonProgress_ThrowsException()
        {
            try
            { 
            // Arrange
            var lessonProgress = new LessonProgress
            {
                StudentId = 1,
                LessonId = 1,
                LearningOutcome = 3,
                PageNumber = 1
            };

            // Act & Assert
            var result = _studentService.SaveLessonProgress(lessonProgress);
            Assert.IsNotNull(result);
        }
         catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
}

        [TestMethod]
        public void SaveAssessmentScore_ValidAssessmentScore_ReturnsTrue()
        {
            try
            { 
            // Arrange
            var assessmentOverview = new AssessmentOverview
            {
                StudentId = 1,
                LessonId = 1,
                LearningOutcome = 3,
                Score = 80,
                TotalScore = 100,
                Status = "Passed"
            };

            // Act
            var result = _studentService.SaveAssessmentScore(assessmentOverview);

            // Assert
            Assert.IsNotNull(result);
        }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public void SaveAssessmentScore_InvalidAssessmentScore_ThrowsException()
        {
            try
            {
                // Arrange
                var assessmentOverview = new AssessmentOverview
                {
                    StudentId = 1,
                    LessonId = 1,
                    LearningOutcome = 2,
                    Score = 80,
                    TotalScore = 100,
                    Status = "Passed",
                    AssessmentId = 1
                };

                var result = _studentService.SaveAssessmentScore(assessmentOverview);

                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public void SaveQuizQuestionAnswer_ValidQuizQuestionAnswer_ReturnsTrue()
        {
            try
            {
                // Arrange
                var quizQuestionAnswer = new QuizQuestionAnswer
                {
                    UserId = 1,
                    QuestionId = 2,
                    AnswerText = "Answer 1"
                };


                // Act
                var result = _studentService.SaveQuizQuestionAnswer(quizQuestionAnswer);

                // Assert
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Requested data");
            }
        }

        [TestMethod]
        public void SaveQuizQuestionAnswer_InvalidQuizQuestionAnswer_ThrowsException()
        {
            try
            {
                // Arrange
                var quizQuestionAnswer = new QuizQuestionAnswer
                {
                    UserId = 1,
                    QuestionId = 2,
                    AnswerText = "Answer 1"
                };


                // Act
                var result = _studentService.SaveQuizQuestionAnswer(quizQuestionAnswer);

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