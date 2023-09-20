using Microsoft.AspNetCore.Mvc;
using UsersManagementAPI.Fake;
using UsersManagementAPI.Models;

namespace UsersManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(100);
        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        [HttpPost]
        public User Post(User user)
        {
            _users.Add(user);
            return user;
        }
        [HttpPut]
        public User Put(User user)
        {
            var editUs = _users.FirstOrDefault(x => x.Id == user.Id);
            editUs.FirstName = user.FirstName;
            editUs.LastName = user.LastName;
            editUs.Address = user.Address;
            return user;
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var del = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(del);
        }
    }
}