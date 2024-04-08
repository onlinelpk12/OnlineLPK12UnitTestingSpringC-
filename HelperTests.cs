using Microsoft.AspNetCore.Routing;
using OnlineLpk12.Data.Entities;
using OnlineLpk12.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers_Test
{
    [TestClass]
    public  class HelperTests
    {
        [TestMethod]
        public async Task Test_GetUserType_Student()
        {
            // Arrange
            bool isStudent = true;

            // Act
            string userType = Helper.GetUserType(isStudent);

            // Assert
            Assert.AreEqual(Helper.UserType_Student, userType);
        }

        [TestMethod]
        public void Test_GetUserType_Teacher()
        {
            // Arrange
            bool isStudent = false;

            // Act
            string userType = Helper.GetUserType(isStudent);

            // Assert
            Assert.AreEqual(Helper.UserType_Teacher, userType);
        }

        [TestMethod]
        public void Test_ComputeQuizScore()
        {
            // Arrange
            int score = 7;
            int totalScore = 10;

            // Act
            double quizScore = Helper.ComputeQuizScore(score, totalScore);

            // Assert
            Assert.AreEqual(0.7, quizScore);
        }

        [TestMethod]
        public void Test_ComputeQuizStatus_Pass()
        {
            // Arrange
            double quizScore = 0.8;

            // Act
            QuizStatus status = Helper.ComputeQuizStatus(quizScore);

            // Assert
            Assert.AreEqual(QuizStatus.Pass, status);
        }

        [TestMethod]
        public void Test_ComputeQuizStatus_Fail()
        {
            // Arrange
            double quizScore = 0.6;

            // Act
            QuizStatus status = Helper.ComputeQuizStatus(quizScore);

            // Assert
            Assert.AreEqual(QuizStatus.Fail, status);
        }

        [TestMethod]
        public void Test_GetQuizStatusId()
        {
            // Arrange
            QuizStatus status = QuizStatus.Pass;

            // Act
            int statusId = Helper.GetQuizStatusId(status);

            // Assert
            Assert.AreEqual(2, statusId);
        }

        [TestMethod]
        public void Test_GetQuizStatus()
        {
            // Arrange
            int statusId = 3;

            // Act
            QuizStatus status = Helper.GetQuizStatus(statusId);

            // Assert
            Assert.AreEqual(QuizStatus.Fail, status);
        }


        [TestMethod]
        public void Test_ValidateUserWhileRegistering_Valid()
        {
            // Arrange
            var user = new RegistrationUser
            {
                FirstName = "John",
                LastName = "Doe",
                EmailId = "john@example.com",
                UserName = "johndoe",
                Password = "password123"
            };

            // Act
            var errors = Helper.ValidateUserWhileRegistering(user);

            // Assert
            Assert.IsFalse(errors.Any());
        }


    }
}
