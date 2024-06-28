using BusinessLogic.Core.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Shared.Services
{
    public class PersonDetailsService
    {
        public PersonDetailsRepository _personalDetailsRepository = new PersonDetailsRepository();

        public PersonDetailsService() { }

        public List<PersonDetailsModel> GetAllPersonalDetails()
        {
            return _personalDetailsRepository.GetPersonDetails();
        }

        public int UpdatePersonDetails(PersonDetailsModel personDetails)
        {
            return _personalDetailsRepository.UpdatePersonDetails(personDetails);
        }

        public PersonDetailsModel GetPersonDetailsByCode(int code)
        {

            return _personalDetailsRepository.GetPersonDetailsByCode(code);
        }

        public int CreatePerson(PersonDetailsModel personDetails)
        {
            return _personalDetailsRepository.CreatePerson(personDetails);
        }

        public List<PersonDetailsModel> SearchPersonalDetails(string searchValue){
            return _personalDetailsRepository.SearchPersonalDetails(searchValue);
        }
    }
}
