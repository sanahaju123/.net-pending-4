using GroceryEmart.DataLayer;
using GroceryEmart.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services.Repository
{
    public class AdminGroceryRepository : IAdminGroceryRepository
    {
        /// <summary>
        /// Creating referance Variable of MongoContext and MongoCollection
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<Product> _dbproductCollection;
        private IMongoCollection<ProductOrder> _dbproductorderCollection;
        private IMongoCollection<Category> _dbcatCollection;
        /// <summary>
        /// Injecting Referance variable in AdminGroceryRepository class Constructor
        /// </summary>
        /// <param name="context"></param>
        public AdminGroceryRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbproductCollection = _mongoContext.GetCollection<Product>(typeof(Product).Name);
            _dbproductorderCollection = _mongoContext.GetCollection<ProductOrder>(typeof(ProductOrder).Name);
            _dbcatCollection = _mongoContext.GetCollection<Category>(typeof(Category).Name);
        }
        /// <summary>
        /// Add New Category in MongoDb Collection
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(typeof(Category).Name + "Object is Null");
                }
                _dbcatCollection = _mongoContext.GetCollection<Category>(typeof(Category).Name);
                await _dbcatCollection.InsertOneAsync(category);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return category;
        }
        /// <summary>
        /// Add New Product In MongoDb Collection
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(typeof(Product).Name + "Object is Null");
                }
                _dbproductCollection = _mongoContext.GetCollection<Product>(typeof(Product).Name);
                await _dbproductCollection.InsertOneAsync(product);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }
            return product;
        }
        /// <summary>
        /// Get All order from ProductOrder Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductOrder>> AllOrder()
        {
            try
            {
                var list = _mongoContext.GetCollection<ProductOrder>("ProductOrder")
                .Find(Builders<ProductOrder>.Filter.Empty, null)
                .SortByDescending(e => e.OrderId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all Product from Mongodb
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> AllProduct()
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
        /// Get all User from ApplicationUser Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetAllUser()
        {
            try
            {
                var list = _mongoContext.GetCollection<ApplicationUser>("ApplicationUser")
                .Find(Builders<ApplicationUser>.Filter.Empty, null)
                .SortByDescending(e => e.UserId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get category by CategoryId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryById(string Id)
        {
            try
            {
                var objectId = new ObjectId(Id);
                FilterDefinition<Category> filter = Builders<Category>.Filter.Eq("Id", objectId);
                _dbcatCollection = _mongoContext.GetCollection<Category>(typeof(Category).Name);
                return await _dbcatCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get ordere by Order Id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public async Task<ProductOrder> GetOrderById(string OrderId)
        {
            try
            {
                var objectId = new ObjectId(OrderId);
                FilterDefinition<ProductOrder> filter = Builders<ProductOrder>.Filter.Eq("OrderId", objectId);
                _dbproductorderCollection = _mongoContext.GetCollection<ProductOrder>(typeof(ProductOrder).Name);
                return await _dbproductorderCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get product by Id from Product Collection
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
        /// Remove category from Category Collection
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveCategory(string Id)
        {
            try
            {
                var objectId = new ObjectId(Id);
                FilterDefinition<Category> filter = Builders<Category>.Filter.Eq("Id", objectId);
                var result = await _dbcatCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Remove Product from Product Colletion
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveProduct(string ProductId)
        {
            try
            {
                var objectId = new ObjectId(ProductId);
                FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("ProductId", objectId);
                var result = await _dbproductCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Upadet category in MongoDb Category collection
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<Category> UpdateCategory(string Id, Category category)
        {
            if (category == null && Id == null)
            {
                throw new ArgumentNullException(typeof(Category).Name + "Object or may be CategoryId is Null");
            }
            var update = await _dbcatCollection.FindOneAndUpdateAsync(Builders<Category>.
                Filter.Eq("Id", category.Id), Builders<Category>.
                Update.Set("Title", category.Title).Set("CatId", category.CatId).Set("Url", category.Url)
                .Set("OpenInNewWindow", category.OpenInNewWindow));
            return update;
        }
        /// <summary>
        /// Upadet Product in MongoDb Product collection
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> UpdateProduct(string Id, Product product)
        {
            if (product == null && Id == null)
            {
                throw new ArgumentNullException(typeof(Product).Name + "Object or may be CategoryId is Null");
            }
            var update = await _dbproductCollection.FindOneAndUpdateAsync(Builders<Product>.
                Filter.Eq("ProductId", product.ProductId), Builders<Product>.
                Update.Set("ProductName", product.ProductName).Set("Description", product.Description).Set("Amount", product.Amount)
                .Set("stock", product.stock).Set("CatId", product.CatId));
            return update;
        }
    }
}
