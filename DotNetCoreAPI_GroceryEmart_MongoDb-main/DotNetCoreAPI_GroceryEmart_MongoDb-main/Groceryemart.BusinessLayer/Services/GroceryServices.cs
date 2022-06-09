using GroceryEmart.BusinessLayer.Interfaces;
using GroceryEmart.BusinessLayer.Services.Repository;
using GroceryEmart.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services
{
    public class GroceryServices : IGroceryServices
    {
        /// <summary>
        /// Creating referance Variable of IGroceryRepository and injecting in GroceryServices constructor
        /// </summary>
        private readonly IGroceryRepository _groceryRepository;
        public GroceryServices(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }
        /// <summary>
        /// Get all product
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Product>> GetAllProduct()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public Task<Product> GetProductById(string ProductId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get acategory list
        /// </summary>
        /// <returns></returns>
        public IList<Category> CategoryList()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Product by name
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public Task<IEnumerable<Product>> ProductByName(string ProductName)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Product By Category
        /// </summary>
        /// <param name="CatId"></param>
        /// <returns></returns>
        public Task<IEnumerable<Product>> GetProductByCategory(int CatId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Place order
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Task<bool> PlaceOrder(string ProductId, string UserId)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
