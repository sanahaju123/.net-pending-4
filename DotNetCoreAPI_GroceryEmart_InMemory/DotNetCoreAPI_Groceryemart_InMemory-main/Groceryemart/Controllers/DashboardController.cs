using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryEmart.BusinessLayer.Interfaces;
using GroceryEmart.BusinessLayer.ViewModels;
using GroceryEmart.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryEmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IAdminGroceryServices
        /// </summary>
        private readonly IAdminGroceryServices _adminGS;
        /// <summary>
        /// Injecting referance variable into DashboardController constructor
        /// </summary>
        /// <param name="adminGroceryServices"></param>
        public DashboardController(IAdminGroceryServices adminGroceryServices)
        {
            _adminGS = adminGroceryServices;
        }
        /// <summary>
        /// Get All order plced by user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ProductOrder>> AllOrder()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get product Order By Id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("OrderById/{OrderId}")]
        public async Task<IActionResult> OrderById(int OrderId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new category in sql table
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddNewCategory([FromBody] CategoryViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new Product in sql table
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updatecategory in sql table
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updatecategory/{Id}")]
        public async Task<IActionResult> Updatecategory(int Id, [FromBody] Category category)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Product in sql table
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateProduct/{string ProductId}")]
        public async Task<IActionResult> UpdateProduct(int ProductId, [FromBody] Product product)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove Category form sql categeory table by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removecategory/{Id}")]
        public async Task<IActionResult> RemoveCategory(int Id)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove Product from sql databse from product table
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removeproduct/{ProductId}")]
        public async Task<IActionResult> RemoveProduct(int ProductId)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
