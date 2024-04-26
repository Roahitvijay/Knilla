using Knilla.Data;
using Knilla.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Inspections;
using Knilla.IRepository;

namespace Knilla.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly DataContext _context;
        public ContactsRepository(DataContext context)
        {
            _context=context;
        }
        public async Task<IEnumerable<ContactsModel>>GetContactList()
        {
            return await _context.ContactsTBL.ToListAsync();
        }
        public async Task<ContactsModel> GetContactListByID(int id)
        {
            var contact = await _context.ContactsTBL.FindAsync(id);
            if(contact==null)
            {
                return null;
            }
            return contact;
        }
        public async Task<string>AddContact(ContactsModel contacts)
        {
            
            if(contacts!=null)
            {
                await _context.ContactsTBL.AddAsync(contacts);
                await _context.SaveChangesAsync();
                return "Inserted Successfully";
            }
            return "No Contacts Found";
        }
        public async Task<string>UpdateContact(ContactsModel contacts)
        {
            if(contacts.Id!=null || contacts.Id!=0)
            {
                var id = await _context.ContactsTBL.FindAsync(contacts.Id);
                if(!await ContactExists(contacts.Id))
                {
                    return "Contact Not Exists";
                }
                else
                {
                    _context.Entry(contacts).State= EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return "Updated Successfully";
                }
            }
            else
            {
                return "No Value Found";
            }
        }
        
        public async Task<string>DeleteContact(int id)
        {
            if(id!=null)
            {
                var contactid = await _context.ContactsTBL.FindAsync(id);
                if(!await ContactExists(id))
                {
                    return "Contact Not Exists";
                }
                else
                {
                    _context.ContactsTBL.Remove(contactid);
                    await _context.SaveChangesAsync();
                    return "Contact Deleted Successfully";
                }
            }
            return "No Value Found";
        }
        public async Task<string> AddMultipeContacts(IEnumerable<ContactsModel> contacts)
        {
            if (contacts != null && contacts.Any())
            {
                await _context.ContactsTBL.AddRangeAsync(contacts);
                await _context.SaveChangesAsync();
                return "Inserted Successfully";
            }
            return "No Contacts Found";
        }
        private async Task<bool> ContactExists(int id)
        {
            return await _context.ContactsTBL.AnyAsync(e => e.Id == id);
        }
    }
}
