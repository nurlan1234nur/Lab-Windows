using System;
using System.Collections.Generic;
using System.Linq;
using Library.Service;
using Library.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class AuthTests
    {
        private AuthService _authService;

        [TestInitialize]
        public void Setup()
        {
            _authService = new AuthService();
        }

        [TestMethod]
        public void CheckUsernamePassword_WithValidCredentials_ShouldReturnTrue()
        {
            // Arrange
            string username = "manager";
            string password = "1234";

            // Act
            var result = _authService.checkUsernamePassword(username, password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckUsernamePassword_WithInvalidCredentials_ShouldReturnFalse()
        {
            // Arrange
            string username = "invalid";
            string password = "invalid";

            // Act
            var result = _authService.checkUsernamePassword(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetUserRoleByUsername_WithValidUsername_ShouldReturnRole()
        {
            // Arrange
            string username = "manager";

            // Act
            var role = _authService.getUserRoleByUsername(username);

            // Assert
            Assert.IsNotNull(role);
            Assert.IsTrue(role == "Manager" || role == "Cashier");
        }

        [TestMethod]
        public void GetUserRoleByUsername_WithInvalidUsername_ShouldReturnNull()
        {
            // Arrange
            string username = "invalid";

            // Act
            var role = _authService.getUserRoleByUsername(username);

            // Assert
            Assert.IsNull(role);
        }
    }
} 