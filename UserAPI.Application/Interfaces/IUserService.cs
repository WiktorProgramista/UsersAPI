using System.Collections.Generic;
using UserAPI.Application.Models;

namespace UserAPI.Application.Interfaces
{
    
    public interface IUserService
    {
        public void Delete(int id);
        public void AddUser(User user);

        public List<User> GetAll();

        public User GetById(int id);

        public void Update(User user);
    }
}
