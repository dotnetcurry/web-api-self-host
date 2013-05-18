using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiServer
{
    public class ContactsController : ApiController
    {
        Contact[] contacts = new Contact[]  
        {  
            new Contact { Id = 1, Name = "Suprotim", Country="India", Phone="101 101 1101"},  
            new Contact { Id = 2, Name = "Sumit", Country="US", Phone="202 202 2202" },  
            new Contact { Id = 3, Name = "Mahesh", Country="India", Phone="303 303 3303" }  
        };

        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        public Contact Get(int id)
        {
            var product = contacts.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        public IEnumerable<Contact> GetContactsByCountry(string country)
        {
            return contacts.Where(p => string.Equals(p.Country, country,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
