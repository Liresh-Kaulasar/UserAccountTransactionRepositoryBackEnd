using BusinessLogic.Core.Models;
using BusinessLogic.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace UserTransactions.Web.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserTransactionsAPIController : ApiController
    {

        public PersonDetailsService _personDetailsService = new PersonDetailsService();

        public AccountsService _accountsService = new AccountsService();

        public UserTransactionsAPIController() {
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetAllPersonalDetails")]
        public IHttpActionResult GetAllPersonalDetails()
        {
            var personalDetails = _personDetailsService.GetAllPersonalDetails();
            return Ok(personalDetails);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetAllPersonalDetailsPagedResult")]
        public IHttpActionResult GetAllPersonalDetailsPagedResult(int page, int pageSize)
        {
            var personalDetails = _personDetailsService.GetAllPersonalDetails();
            return Ok(personalDetails.Skip((page-1)*pageSize).Take(pageSize).ToList());
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetPersonDetailsByCode/{code}")]
        public IHttpActionResult GetPersonDetailsByCode(int code)
        {
            var personDetails = _personDetailsService.GetPersonDetailsByCode(code);
            return Ok(personDetails);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetAccountDetailsByCode/{code}")]
        public IHttpActionResult GetAccountDetailsByCode(int code)
        {
            try
            {
                var accountDetails = _accountsService.GetAccountDetailsByCode(code);
                return Ok(accountDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/SearchPersonalDetails/{searchValue}")]
        public IHttpActionResult SearchPersonalDetails(string searchValue)
        {
            var personDetails = _personDetailsService.SearchPersonalDetails(searchValue);
            return Ok(personDetails);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/UpdatePersonalDetails")]
        public IHttpActionResult UpdatePerson(PersonDetailsModel personDetails)
        {
            var rowsAffected = _personDetailsService.UpdatePersonDetails(personDetails);
            return Ok(rowsAffected);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/UpdateAccountDetails")]
        public IHttpActionResult UpdateAccountDetails(PersonAccountModel personAccount)
        {
            var rowsAffected = _accountsService.UpdateAccountDetails(personAccount);
            return Ok(rowsAffected);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/CreatePerson")]
        public IHttpActionResult CreatePerson(PersonDetailsModel personDetails)
        {
            var rowsAffected = _personDetailsService.CreatePerson(personDetails);
            return Ok(rowsAffected);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetAccountDetailsByPersonCode/{personCode}")]
        public IHttpActionResult GetAccountDetailsByPersonCode(int personCode)
        {
            var personDetails = _accountsService.GetAccountDetailsByPersonCode(personCode);
            return Ok(personDetails);
        }

        // POST: api/UserTransactionsAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserTransactionsAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserTransactionsAPI/5
        public void Delete(int id)
        {
        }
    }
}
