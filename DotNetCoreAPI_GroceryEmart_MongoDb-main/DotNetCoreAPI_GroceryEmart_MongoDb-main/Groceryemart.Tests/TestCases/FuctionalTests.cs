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
    public class FuctionalTests
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
        private ProductOrder _productOrder;
        private static string type = "Functional";
        public FuctionalTests(ITestOutputHelper output)
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
            _productOrder = new ProductOrder()
            {
                OrderId = "5f0ff60a7b7be11c4c3c19e1",
                ProductId = "5f45df48ff7f1df2085ec8fd",
                UserId = "5f45df48ff7f1df2085ec8fd"
            };
        }
        
        /// <summary>
        /// Test to validate user is valid for register
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidUserRegister()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                userservice.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
                var result = await _userGroceryS.Register(_user);
                if (result != null)
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
        /// Test for get a valid user id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetUserById()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                userservice.Setup(repo => repo.GetUserById(_user.UserId)).ReturnsAsync(_user);
                var result = await _userGroceryS.GetUserById(_user.UserId);
                if (result != null)
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
        /// Test to validate user update is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateUser()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _userUpdate = new ApplicationUser()
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
            //Act
            try
            {
                userservice.Setup(repo => repo.UpdateUser(_userUpdate.UserId, _userUpdate)).ReturnsAsync(_userUpdate);
                var result = await _userGroceryS.UpdateUser(_userUpdate.UserId, _userUpdate);
                if (result == _userUpdate)
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
        /// Test to validate all product is listing or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetAllProduct()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                groceryservice.Setup(repos => repos.GetAllProduct());
                var result = await _groceryS.GetAllProduct();
                //Assertion
                if (result != null)
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
        /// Test to validate get product by id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetProductById()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                groceryservice.Setup(repo => repo.GetProductById(_product.ProductId)).ReturnsAsync(_product);
                var result = await _groceryS.GetProductById(_product.ProductId);
                if (result != null)
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
            //final result displaying in text file
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
        /// test to validate get category by category id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetCategoryById()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                adminservice.Setup(repo => repo.GetCategoryById(_category.Id)).ReturnsAsync(_category);
                var result = await _adminGroceryS.GetCategoryById(_category.Id);
                if (result != null)
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
        /// test to validate get product by category
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetProductByCategory()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                groceryservice.Setup(repo => repo.GetProductByCategory(_product.CatId));
                var result = await _groceryS.GetProductByCategory(_product.CatId);
                if (result != null)
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
        /// test to validate get product by product name.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetProductByName()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                groceryservice.Setup(repo => repo.ProductByName(_product.ProductName));
                var result = await _groceryS.ProductByName(_product.ProductName);
                if (result != null)
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
        /// test to validate get category list
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetCategorylist()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                groceryservice.Setup(repo => repo.CategoryList());
                var result = _groceryS.CategoryList();
                if (result != null)
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
        /// Test to validate valid category is added or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidAddCategory()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                adminservice.Setup(repo => repo.AddCategory(_category)).ReturnsAsync(_category);
                var result = await _adminGroceryS.AddCategory(_category);
                if (result != null)
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
        /// Test to validate valid product is added or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_AddValidProduct()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                adminservice.Setup(repo => repo.AddProduct(_product)).ReturnsAsync(_product);
                var result = await _adminGroceryS.AddProduct(_product);
                if (result != null)
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
        /// Test to validate valid categroy is updated or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateCategory()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _categoryUpdate = new Category()
            {
                Id = "5f0ff60a7b7be11c4c3c19e1",
                CatId = 1,
                Url = "~/Home",
                OpenInNewWindow = false
            };
            //Act
            try
            {
                adminservice.Setup(repo => repo.UpdateCategory(_categoryUpdate.Id, _categoryUpdate)).ReturnsAsync(_categoryUpdate);
                var result = await _adminGroceryS.UpdateCategory(_categoryUpdate.Id, _categoryUpdate);
                if (result == _categoryUpdate)
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
        /// Test to validate update valid product 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateProduct()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateproduct = new Product()
            {
                ProductId = "5f45df48ff7f1df2085ec8fd",
                ProductName = "Samsung",
                Description = "Procesor i9, 2 GB, 32 GB SSD, Corning Grollia Glass",
                Amount = 24900.0,
                stock = 10,
                photo = "",
                CatId = 1
            };
            //Act
            try
            {
                adminservice.Setup(repo => repo.UpdateProduct(_updateproduct.ProductId, _updateproduct)).ReturnsAsync(_updateproduct);
                var result = await _adminGroceryS.UpdateProduct(_updateproduct.ProductId, _updateproduct);
                if (result == _updateproduct)
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
            ///Asert
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
        /// Test to validate valid category is removed or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_RemoveCategory()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                adminservice.Setup(repos => repos.RemoveCategory(_category.Id)).ReturnsAsync(true);
                var resultDelete = await _adminGroceryS.RemoveCategory(_category.Id);
                //Assertion
                if (resultDelete == true)
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
            ///Asert
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
        /// Test to validate Valid product is removed or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_RemoveProduct()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                adminservice.Setup(repos => repos.RemoveProduct(_product.ProductId)).ReturnsAsync(true);
                var resultDelete = await _adminGroceryS.RemoveProduct(_product.ProductId);
                //Assertion
                if (resultDelete == true)
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
            ///Asert
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
        /// Test to validate get all product
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetAllOrder()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                adminservice.Setup(repos => repos.AllOrder());
                var result = await _adminGroceryS.AllOrder();
                //Assertion
                if (result != null)
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
            ///Asert
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
        /// Test to validate get placed order bu order Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetOrderById()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                adminservice.Setup(repo => repo.GetOrderById(_productOrder.OrderId));
                var result = await _adminGroceryS.GetOrderById(_productOrder.OrderId);
                if (result != null)
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
        /// Test to validate get all product
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_AllProduct()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                adminservice.Setup(repo => repo.AllProduct());
                var result = await _adminGroceryS.AllProduct();
                if (result != null)
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
        /// Test to validate get all user
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetAllUser()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                adminservice.Setup(repo => repo.GetAllUser());
                var result = await _adminGroceryS.GetAllUser();
                if (result != null)
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
