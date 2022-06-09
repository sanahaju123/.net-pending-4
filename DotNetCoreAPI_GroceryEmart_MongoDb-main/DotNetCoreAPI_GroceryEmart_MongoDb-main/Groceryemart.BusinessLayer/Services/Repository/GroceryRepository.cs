using GroceryEmart.DataLayer;
using GroceryEmart.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services.Repository
{
    public class GroceryRepository : IGroceryRepository
    {
        /// <summary>
        /// Creating referance Variable of MongoContext and MongoCollection
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<ApplicationUser> _dbCollection;
        private IMongoCollection<Product> _dbproductCollection;
        private IMongoCollection<Category> _dbcatCollection;
        private IMongoCollection<ProductOrder> _dbproductorderCollection;
        UserGroceryRepository usergroceryRepository;
        public GroceryRepository(IMongoDBContext context)
        {
            /// <summary>
            /// Injecting Referance variable in GroceryRepository class Constructor
            /// </summary>
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
            _dbproductCollection = _mongoContext.GetCollection<Product>(typeof(Product).Name);
            _dbcatCollection = _mongoContext.GetCollection<Category>(typeof(Category).Name);
            _dbproductorderCollection = _mongoContext.GetCollection<ProductOrder>(typeof(ProductOrder).Name);
        }
        /// <summary>
        /// Get All Poduct from Product Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            try
            {
                var list = _mongoContext.GetCollection<Product>("Product")
                .Find(Builders<Product>.Filter.Empty, null)
                .SortByDescending(e => e.ProductName);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Product from Product collection by Product Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(string ProductId)
        {
            try
            {
                var objectId = new ObjectId(ProductId);
                FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("ProductId", objectId);
                _dbproductCollection = _mongoContext.GetCollection<Product>(typeof(Product).Name);
                return await _dbproductCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get List of Category from Category collection
        /// </summary>
        /// <returns></returns>
        public IList<Category> CategoryList()
        {
            try
            {
                var list = _mongoContext.GetCollection<Category>("Category")
                .Find(Builders<Category>.Filter.Empty, null)
                .SortByDescending(e => e.Title);
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Place Order and verify registred user
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<bool> PlaceOrder(string ProductId, string UserId)
        {
            try
            {
                var res = false;
                var objectId = new ObjectId(ProductId);
                FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("ProductId", objectId);
                _dbproductCollection = _mongoContext.GetCollection<Product>(typeof(Product).Name);
                var product = await _dbproductCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
                if (product != null)
                {
                    var order = new ProductOrder()
                    {
                        ProductId = product.ProductId,
                        UserId = UserId
                    };
                    _dbproductorderCollection = _mongoContext.GetCollection<ProductOrder>(typeof(ProductOrder).Name);
                    await _dbproductorderCollection.InsertOneAsync(order);
                }
                res = true;
                return res;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get product by name from Product collection
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> ProductByName(string ProductName)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<Product>();
                var productName = filterBuilder.Eq(s => s.ProductName, ProductName.ToString());
                _dbproductCollection = _mongoContext.GetCollection<Product>(typeof(Product).Name);
                var result = await _dbproductCollection.FindAsync(productName).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get product by categoryId from Product Collection
        /// </summary>
        /// <param name="CatId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductByCategory(int CatId)
        {
            try
            {
                //var objectId = new ObjectId(CatId);
                FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("CatId", CatId);
                _dbproductCollection = _mongoContext.GetCollection<Product>(typeof(Product).Name);
                return await _dbproductCollection.FindAsync(filter).Result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
