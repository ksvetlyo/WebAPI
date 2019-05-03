using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class ContactController : ApiController
    {

        Contact[] contacts = new Contact[]
        {
            new Contact() {Id = 0, FirstName = "Peter", LastName = "Markov"},
            new Contact() {Id = 0, FirstName = "Bruce", LastName = "Wayne"},
            new Contact() {Id = 0, FirstName = "Tony", LastName = "Stark"}
        };

        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET: api/Contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contact
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
