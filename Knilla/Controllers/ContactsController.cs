using Knilla.IRepository;
using Knilla.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Knilla.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }
        [HttpGet]
        [Route("GetContacts")]
        public async Task<IEnumerable<ContactsModel>> GetContactList()
        {
            return await _contactsRepository.GetContactList();
        }
        [HttpGet]
        [Route("GetContactByID")]
        public async Task<ContactsModel> GetContactListByID(int id)
        {
            return await _contactsRepository.GetContactListByID(id);
        }
        [HttpPost]
        [Route("AddContact")]
        public async Task<string> AddContact(ContactsModel contacts)
        {
            return await _contactsRepository.AddContact(contacts);
        }
        [HttpPost]
        [Route("UpdateContact")]
        public async Task<string> UpdateContact(ContactsModel contacts)
        {
            return await _contactsRepository.UpdateContact(contacts);
        }
        [HttpDelete]
        [Route("DeleteContact")]
        public async Task<string> DeleteContact(int id)
        {
            return await _contactsRepository.DeleteContact(id);
        }
        [HttpPost]
        [Route("AddBulkContacts")]
        public async Task<string> AddMultipeContacts(IEnumerable<ContactsModel> contacts)
        {
            return await _contactsRepository.AddMultipeContacts(contacts);
        }
    }
}
