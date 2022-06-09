using GroceryEmart.BusinessLayer.Interfaces;
using GroceryEmart.BusinessLayer.Services;
using GroceryEmart.BusinessLayer.Services.Repository;
using GroceryEmart.Entities;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace GroceryEmart.Tests.TestCases
{
    public class ExceptionalTest
    {
        /// <summary>
        /// Creating Referance Variable and Mocking repository class
        /// </summary>
        private readonly ITestOutputHelper _output;
        private readonly IGroceryServices _groceryS;
        private readonly IUserGroceryServices _userGroceryS;
        private readonly IAdminGroceryServices _adminGroceryS;
        public readonly Mock<IGroceryRepository> groceryservice = new Mock<IGroceryRepository>();
        public readonly Mock<IUserGroceryRepository> userservice = new Mock<IUserGroceryRepository>();
        public readonly Mock<IAdminGroceryRepository> adminservice = new Mock<IAdminGroceryRepository>();
        private ApplicationUser _user;
        private Product _product;
        private Category _category;
        private static string type = "Exceptional";
        public ExceptionalTest(ITestOutputHelper output)
        {
            /// <summary>
            /// Injecting service object into Test class constructor
            /// </summary>
            _groceryS = new GroceryServices(groceryservice.Object);
            _userGroceryS = new UserGroceryServices(userservice.Object);
            _adminGroceryS = new AdminGroceryServices(adminservice.Object);
            _output = output;
            _user = new ApplicationUser()
            {
                UserId = "5f45df48ff7f1df2085ec8fd",
                Name = "Uma Kumar",
                Email = "umakumarsingh@gmail.com",
                Password = "12345",
                MobileNumber = 9865253568,
                PinCode = 820003,
                HouseNo_Building_Name = "9/11",
                Road_area = "Road_area",
                City = "Gaya",
                State = "Bihar"
            };
            _product = new Product()
            {
                ProductId = "5f45df48ff7f1df2085ec8fd",
                ProductName = "Samsung",
                Description = "Procesor i9, 2 GB, 32 GB SSD, Corning Grollia Glass",
                Amount = 24900.0,
                stock = 10,
                photo = "",
                CatId = 1
            };
            _category = new Category()
            {
                Id = "5f0ff60a7b7be11c4c3c19e1",
                CatId = 1,
                Url = "~/Home",
                OpenInNewWindow = false
            };
        }
        
        /// <summary>
        /// This Method is used for test user is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InvlidUserRegister()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            _user = null;
            //Act
            try
            {
                userservice.Setup(repo => repo.Register(_user)).ReturnsAsync(_user = null);
                var result = await _userGroceryS.Register(_user);
                if (result == null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Asert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Asert
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Test to validate product is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InvlidAddProduct()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            _product = null;
            //Act
            try
            {
                adminservice.Setup(repo => repo.AddProduct(_product)).ReturnsAsync(_product = null);
                var result = await _adminGroceryS.AddProduct(_product);
                if (result == null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Asert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Asert
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Test to validate category is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InvlidAddCategory()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            _category = null;
            //Act
            try
            {
                adminservice.Setup(repo => repo.AddCategory(_category)).ReturnsAsync(_category = null);
                var result = await _adminGroceryS.AddCategory(_category);
                if (result == null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Asert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Asert
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// test to validate category remove is valid or invalid
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InValid_RemoveCategory()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _categorydel = new Category() { };
            //Action
            try
            {
                adminservice.Setup(repos => repos.RemoveCategory(_categorydel.Id)).ReturnsAsync(true);
                var result = await _adminGroceryS.RemoveCategory(_categorydel.Id);
                if (result == true)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Asert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Asert
            //final result save in text file.
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// test to validate product is valid for remove or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InValid_RemoveProduct()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _productdel = new Product() { };
            //Action
            try
            {
                adminservice.Setup(repos => repos.RemoveProduct(_productdel.ProductId)).ReturnsAsync(true);
                var result = await _adminGroceryS.RemoveProduct(_productdel.ProductId);
                if (result == true)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Asert
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// test to validate productId and UserId shoild be > 0 is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_InValid_PlaceOrder()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var ProductId = "5f45df48ff7f1df2085ec8fd";
            var UserId = "5f45df48ff7f1df2085ec8fd";
            //Action
            try
            {
                groceryservice.Setup(repos => repos.PlaceOrder(ProductId, UserId)).ReturnsAsync(false);
                var result = await _groceryS.PlaceOrder(ProductId, UserId);
                if (result == false)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Asert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            //Asert
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}
