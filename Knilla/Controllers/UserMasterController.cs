using Knilla.IRepository;
using Knilla.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Knilla.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private readonly IUserMasterRepository _userMasterRepository;
        public UserMasterController(IUserMasterRepository userMasterRepository)
        {
            _userMasterRepository = userMasterRepository;
        }
        [HttpGet]
        [Route("GetUserList")]
        public async Task<IEnumerable<UserMasterModel>> GetUsersList()
        {
            return await _userMasterRepository.GetUsersList();
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<string> AddUser(UserMasterModel user)
        {
            return await _userMasterRepository.AddUser(user);
        }
        [HttpPost]
        [Route("UpdateUser")]
        public async Task<string> UpdateUser(UserMasterModel user)
        {
            return await _userMasterRepository.UpdateUser(user);
        }
        [HttpPost]
        [Route("DeleteUser")]
        public async Task<string> DeleteUser(int id)
        {
            return await _userMasterRepository.DeleteUser(id);
        }
        

    }
}
