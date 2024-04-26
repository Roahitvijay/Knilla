using Knilla.Models;

namespace Knilla.IRepository
{
    public interface IContactsRepository
    {
        public Task<IEnumerable<ContactsModel>> GetContactList();
        public Task<ContactsModel> GetContactListByID(int id);
        public Task<string> AddContact(ContactsModel contacts);
        public Task<string> UpdateContact(ContactsModel contacts);
        public Task<string> DeleteContact(int id);
        public Task<string> AddMultipeContacts(IEnumerable<ContactsModel> contacts);
    }
}
