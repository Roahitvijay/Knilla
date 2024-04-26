using Knilla.Models;

namespace Knilla.IRepository
{
    public interface IUserMasterRepository
    {
        public Task<IEnumerable<UserMasterModel>> GetUsersList();
        public Task<UserMasterModel> GetUserListByID(int id);
        public Task<string> AddUser(UserMasterModel user);
        public Task<string> UpdateUser(UserMasterModel user);
        public Task<string> DeleteUser(int id);
    }
}
