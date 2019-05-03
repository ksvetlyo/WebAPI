using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        Contact[] contacts = {
            new Contact() {Id = 0, FirstName = "Peter", LastName = "Parker"},
            new Contact() {Id = 1, FirstName = "Bruce", LastName = "Banner"},
            new Contact() {Id = 2, FirstName = "Tony", LastName = "Stark"},
            new Contact() {Id = 3, FirstName = "Stephen", LastName = "Strange"},
            new Contact() {Id = 4, FirstName = "Natasha", LastName = "Romanoff"}
        };

        [HttpGet]
        [Route("")]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Contact contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpGet]
        [Route("{name}")]
        public IEnumerable<Contact> GetContactByName(string name)
        {
            Contact[] contactArray = contacts.Where<Contact>(c => c.FirstName.Contains(name)).ToArray();

            return contactArray;
        }

        [HttpPost]
        [Route("")]
        public IEnumerable<Contact> Post([FromBody]Contact newContact)
        {
            List<Contact> contactList = contacts.ToList();

            newContact.Id = contactList.Count;
            contactList.Add(newContact);
            contacts = contactList.ToArray();

            return contacts;
        }

        [HttpPut]
        [Route("{id:int}")]
        public IEnumerable<Contact> Put(int id, [FromBody]Contact updatedContact)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(c => c.Id == id);

            if (contact != null)
            {
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
            }
            return contacts;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IEnumerable<Contact> Delete(int id)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(c => c.Id == id);

            List<Contact> contactList = contacts.ToList();

            var itemToRemove = contactList.Single(r => r.Id == contact.Id);

            if (contact != null)
            {           
                contactList.Remove(itemToRemove);
                contacts = contactList.ToArray();
            }

            return contacts;
        }
    }
}
