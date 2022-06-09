using GroceryEmart.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services.Repository
{
    public interface IAdminGroceryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<bool> RemoveCategory(string Id);
        Task<Category> UpdateCategory(string Id, Category category);
        Task<Product> AddProduct(Product product);
        Task<bool> RemoveProduct(string ProductId);
        Task<Product> UpdateProduct(string ProductId, Product product);
        Task<Category> GetCategoryById(string Id);
        Task<Product> GetProductById(string ProductId);
        Task<IEnumerable<ProductOrder>> AllOrder();
        Task<ProductOrder> GetOrderById(string OrderId);
        Task<IEnumerable<Product>> AllProduct();
        Task<IEnumerable<ApplicationUser>> GetAllUser();
    }
}
