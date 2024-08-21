using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webapi_cc.Models;

namespace Webapi_cc.Controllers
{
    public class CountryController : ApiController
    {
        List<Country> countrylist = new List<Country>()
        {
            new Country{Id=1,CountryName="India",Capital="Delhi"},
            new Country{Id=2,CountryName="Japan",Capital="Tokyo"},
            new Country{Id=3,CountryName="China",Capital="Bejing"},
            new Country{Id=4,CountryName="England",Capital="London"},
            new Country{Id=5,CountryName="Srilanka",Capital="Colombia"},

        };
        
        //Get
        [HttpGet]
        public HttpResponseMessage GetAllCountries()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countrylist);
            return response;
        }

        [HttpGet]
        public IHttpActionResult GetCountryById(int cId)
        {
            string cname = countrylist.Where(c => c.Id ==cId).SingleOrDefault()?.CountryName;
            if (cname == null)
            {
                return NotFound();
            }
            return Ok(cname);
        }

        //Post
        [HttpPost]
        public List<Country> PostAll([FromBody] Country country)
        {
            countrylist.Add(country);
            return countrylist;
        }

        // Put
        [HttpPut]
        public IEnumerable<Country> Put(int cid, [FromUri] Country c)
        {
            countrylist[cid - 1] = c;
            return countrylist;
        }

        // Delete
        [HttpDelete]
        public List<Country> Delete(int Id)
        {
            countrylist.RemoveAt(Id - 1);
            return countrylist;
        }
    }
}
