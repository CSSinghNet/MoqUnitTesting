using DemoAPITest.Controllers;
using DemoAPITest.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoAPITest.Models;
using System.Web.Http.Results;
using Newtonsoft.Json;
using System.IO;

namespace User.Test
{
    public class UserControllerTest
    {
        private readonly Mock<IDataRepository> mockDtaRepository = new Mock<IDataRepository>();
        private readonly UserController _userController;

        public UserControllerTest()
        {
            _userController = new UserController(mockDtaRepository.Object);
        }

        [Fact]
        public void Test_GetUser()
        {
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.getUsersList()).Returns(GetUser());

            // Act
            var response = _userController.Get();

            // Asert
            Assert.Equal(3, response.Count);

        }

        [Fact]
        public void Test_DeleteUser()
        {
            var user = new DemoAPITest.Models.User();
            user.Id = 1;
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.Delete(user.Id)).Returns(true);

            // Act
            var response = _userController.Delete(user.Id);

            //Assert
            Assert.True(response);

        }

        [Fact]
        public void Test_GetUserById()
        {
            // Arrange
            var user = new DemoAPITest.Models.User();
            user.Id = 1;
            user.UserName = "Mukesh";
            user.Role = "SystemAdmin";

            // Act
            var responseObj = mockDtaRepository.Setup(x => x.GetById(user.Id)).Returns(user);
            var result = _userController.Get(user.Id);
            var isNull = Assert.IsType<OkNegotiatedContentResult<DemoAPITest.Models.User>>(result);
            // Assert
            Assert.NotNull(isNull);
        }

        [Fact]
        public void Test_AddUser()
        {
            var newUser = new DemoAPITest.Models.User();
            newUser.Id = 4;
            newUser.UserName = "Shankar";
            newUser.Role = "UserAdmin";
            // Act
            var response = mockDtaRepository.Setup(x => x.AddUser(newUser)).Returns(AddUser());
            var result = _userController.Post(newUser);

            // Assert
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Test_UpdateUser()
        {
            // Arrange
            var model = JsonConvert.DeserializeObject<DemoAPITest.Models.User>(File.ReadAllText("Data/UpdateUser.json"));

            // Act
            var resultObj = mockDtaRepository.Setup(x => x.Update(model)).Returns(model);
            var response = _userController.Put(model);
            // Assert
            Assert.Equal(model, response);
        }


        private static IList<DemoAPITest.Models.User> GetUser()
        {
            IList<DemoAPITest.Models.User> users = new List<DemoAPITest.Models.User>()
            {
                new DemoAPITest.Models.User() {Id=1,UserName="Mukesh",Role="SystemAdmin"},
                new DemoAPITest.Models.User() {Id=2,UserName="Ram",Role="Admin"},
                new DemoAPITest.Models.User() {Id=3,UserName="Ramesh",Role="Manager"},

            };
            return users;
        }

        private static DemoAPITest.Models.User AddUser()
        {
            var newUser = new DemoAPITest.Models.User();
            newUser.Id = 4;
            newUser.UserName = "Shankar";
            newUser.Role = "UserAdmin";
            return newUser;
        }

    }
}
