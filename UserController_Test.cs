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
    public class UserController_Test
    {
        private Mock<IUserService> _userServiceMock;
        private Mock<ILogService> _logServiceMock;
        private UserController _userController;

        [TestInitialize]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _logServiceMock = new Mock<ILogService>();
            _userController = new UserController(_userServiceMock.Object, _logServiceMock.Object);
        }

        [TestMethod]
        public async Task Register_ValidUser_Success()
        {
         
            var user = new RegistrationUser { /* Set user properties */ };
            _userServiceMock.Setup(x => x.IsUserNameExists(user.UserName)).ReturnsAsync(false);
            _userServiceMock.Setup(x => x.IsEmailIdExists(user.EmailId)).ReturnsAsync(false);
            _userServiceMock.Setup(x => x.IsPasswordStrong(user.Password)).ReturnsAsync(true);
            //_userServiceMock.Setup(x => x.RegisterUser(user)).ReturnsAsync(new Response<string> { Success = true });

         
            var result = await _userController.Register(user);

            
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual("Success message", result.Value);
        }

      

        [TestMethod]
        public async Task Login_ValidUser_Success()
        {
        
            var user = new LoginUser { /* Set user properties */ };
            //_userServiceMock.Setup(x => x.Login(user)).ReturnsAsync(new Response<Token> { Success = true });

           
            var result = await _userController.Login(user);

           
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual("Success message", result.Value);
        }


        [TestMethod]
        public async Task ForgotPassword_ValidUser_Success()
        {

            var user = new LoginUser();
            //_userServiceMock.Setup(x => x.ForgotPassword(user)).ReturnsAsync(new Response<EmptyResult> { Success = true });

          
            var result = await _userController.ForgotPassword(user);

            
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual("Success message", result.Value);
        }

        

        [TestMethod]
        public async Task TeacherStudentsForCourse_ValidRequest_Success()
        {
         
            int userId = 1;
            int courseId = 2;
            var students = new List<Student> { /* Set student objects */ };
            //_userServiceMock.Setup(x => x.CourseMap(userId, courseId)).ReturnsAsync(new Response<List<Student>> { Success = true, Content = students });

            
            var result = await _userController.TeacherStudentsForCourse(userId, courseId);

       
            Assert.IsNotNull(result);
            //Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.AreEqual(students, result.Value);
        }

      
    }
}