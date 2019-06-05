using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Services
{
    public class DataAccess
    {
        private const string CacheKey = "ContactStore";

        List<Contact> contacts = new List<Contact>();
        /// <summary>
        /// Uncomment constructor code to pre-seed session cache
        /// </summary>
        public DataAccess()
        {
            var context = HttpContext.Current;

            if (context != null)
            {
                if (context.Cache[CacheKey] == null)
                {
                    //contacts.Add(new Contact { FirstName = "Tom", LastName = "Xurry", Id = Guid.NewGuid(), EmailAddress = "Tom_Xurry@email.com" });
                    //contacts.Add(new Contact { FirstName = "Joe", LastName = "Smooth", Id = Guid.NewGuid(), EmailAddress = "Joe_Smooth@email.com" });
                    //contacts.Add(new Contact { FirstName = "Lisa", LastName = "Thompson", Id = Guid.NewGuid(), EmailAddress = "lisatompson@email.com" });
                    //contacts.Add(new Contact { FirstName = "Jeff", LastName = "Xurry", Id = Guid.NewGuid(), EmailAddress = "jeff_xurry@email.com" });
                    //contacts.Add(new Contact { FirstName = "Ben", LastName = "Thomas", Id = Guid.NewGuid(), EmailAddress = "benThomas10.email@gmail.com" });
                    //contacts.Add(new Contact { FirstName = "Brenda", LastName = "Thompson", Id = Guid.NewGuid(), EmailAddress = "brenda_thompson@email.com" });
                    context.Cache[CacheKey] = contacts;
                }
            }

            
        }

        public List<Contact> GetAllContacts(bool sortAcending = true)
        {
            var context = HttpContext.Current;

            if (context != null)
            {
                contacts = (List<Contact>)context.Cache[CacheKey];
                contacts = sortAcending ?
                contacts.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList() :
                contacts.OrderByDescending(x => x.LastName).ThenByDescending(x => x.FirstName).ToList();
                return contacts;
            }
            contacts.Add(new Contact { FirstName = "No Contacts Available", LastName = "No Contacts Available", Id = Guid.NewGuid(), EmailAddress = "No Contacts Available" });            
            return contacts;
        }

        public List<Contact> GetContactsByLastName(string lastName, bool sortAcending = true)
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                contacts = (List<Contact>)context.Cache[CacheKey];
                contacts = sortAcending ?
                contacts.Where(x => x.LastName == lastName).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList() :
                contacts.Where(x => x.LastName == lastName).OrderByDescending(x => x.LastName).ThenByDescending(x => x.FirstName).ToList();
                return contacts;
            }
            contacts.Add(new Contact { FirstName = "No Contacts Available", LastName = "No Contacts Available", Id = Guid.NewGuid(), EmailAddress = "No Contacts Available" });
            return contacts;
        }

        public bool AddContact(Contact contact)
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                try
                {
                    var currentData = ((List<Contact>)context.Cache[CacheKey]).ToList();
                    contact.Id = Guid.NewGuid();
                    currentData.Add(contact);
                    context.Cache[CacheKey] = currentData.ToList();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }
    }
}