using GroceryEmart.BusinessLayer.Interfaces;
using GroceryEmart.BusinessLayer.Services.Repository;
using GroceryEmart.Entities;
using System;
using System.Threading.Tasks;

namespace GroceryEmart.BusinessLayer.Services
{
    public class UserGroceryServices : IUserGroceryServices
    {
        /// <summary>
        /// Creating referance Variable of IUserGroceryRepository and injecting in UserGroceryServices constructor
        /// </summary>
        private readonly IUserGroceryRepository _userGroceryRepository;
        public UserGroceryServices(IUserGroceryRepository userGroceryRepository)
        {
            _userGroceryRepository = userGroceryRepository;
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Task<ApplicationUser> GetUserById(string UserId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Loging user to check is registred or not
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<ApplicationUser> Login(string Email, string password)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Log out 
        /// </summary>
        /// <returns></returns>
        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Registred new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<ApplicationUser> Register(ApplicationUser user)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<ApplicationUser> UpdateUser(string UserId, ApplicationUser user)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
