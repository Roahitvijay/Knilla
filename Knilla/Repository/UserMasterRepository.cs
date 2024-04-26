using Knilla.Data;
using Knilla.IRepository;
using Knilla.Models;
using Microsoft.EntityFrameworkCore;

namespace Knilla.Repository
{
    public class UserMasterRepository:IUserMasterRepository
    {
        private readonly DataContext _context;
        public UserMasterRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserMasterModel>> GetUsersList()
        {
            return await _context.UserMasterTBL.ToListAsync();
        }
        public async Task<UserMasterModel> GetUserListByID(int id)
        {
            var user = await _context.UserMasterTBL.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<string> AddUser(UserMasterModel user)
        {

            if (user != null)
            {
                await _context.UserMasterTBL.AddAsync(user);
                await _context.SaveChangesAsync();
                return "Inserted Successfully";
            }
            return "No User Found";
        }
        public async Task<string> UpdateUser(UserMasterModel user)
        {
            if (user.Id != null || user.Id != 0)
            {
                var id = await _context.UserMasterTBL.FindAsync(user.Id);
                if (!await UserExists(user.Id))
                {
                    return "user Not Exists";
                }
                else
                {
                    _context.Entry(user).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return "Updated Successfully";
                }
            }
            else
            {
                return "No Value Found";
            }
        }
        public async Task<string> DeleteUser(int id)
        {
            if (id != null)
            {
                var userid = await _context.UserMasterTBL.FindAsync(id);
                if (!await UserExists(id))
                {
                    return "Contact Not Exists";
                }
                else
                {
                    _context.UserMasterTBL.Remove(userid);
                    await _context.SaveChangesAsync();
                    return "User Deleted Successfully";
                }
            }
            return "No User Found";
        }
        private async Task<bool> UserExists(int id)
        {
            return await _context.UserMasterTBL.AnyAsync(e => e.Id == id);
        }
        
    }
}
