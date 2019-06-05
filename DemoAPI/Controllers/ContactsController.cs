using DemoAPI.Models;
using DemoAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DemoAPI.Controllers
{
    public class ContactsController : ApiController
    {
        //construct dataAccess on instance
        private DataAccess dataAccess;
        public ContactsController()
        {
            dataAccess = new DataAccess();
        }

        // GET: api/Contacts
        /// <summary>
        /// Gets all contacts in default ascending sort by Last Name
        /// </summary>
        /// <param name="sortAscending"></param>
        /// <returns></returns>
        public List<Contact> Get(bool sortAscending = true)
        {
            return dataAccess.GetAllContacts(sortAscending);
        }

        // GET: api/Contacts?lastName={lastName}
        /// <summary>
        /// Gets contacts where LastName matches the lastName parameter
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="sortAscending"></param>
        /// <returns></returns>
        public List<Contact> Get(string lastName, bool sortAscending = true)
        {
            return dataAccess.GetContactsByLastName(lastName, sortAscending);
        }

        // POST: api/Contacts
        /// <summary>
        /// Posts a new contact object
        /// </summary>
        /// <param name="contact"></param>
        public HttpResponseMessage Post(Contact contact)
        {           
            if (dataAccess.AddContact(contact))
            {
                var newUrl = this.Url.Link("Default", new { Controller = "Success" });
                return Request.CreateResponse(HttpStatusCode.Created, new {Success = true , RedirectUrl = newUrl});
            }

            var badResponse = Request.CreateResponse(HttpStatusCode.BadRequest);
            return badResponse;
        }

    }
}
