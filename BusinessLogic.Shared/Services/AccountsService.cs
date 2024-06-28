using BusinessLogic.Core.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Shared.Services
{
    public class AccountsService
    {
        public AccountsRepository _accountsRepository = new AccountsRepository();

        public AccountsService() { }

        public List<PersonAccountModel> GetAccountDetailsByPersonCode(int personCode)
        {       
            return _accountsRepository.GetAccountDetailsByPersonCode(personCode);
        }

        public PersonAccountModel GetAccountDetailsByCode(int code)
        {
            return _accountsRepository.GetAccountDetailsByCode(code);
        }

        public int UpdateAccountDetails(PersonAccountModel personAccount)
        {
            return _accountsRepository.UpdateAccountDetails(personAccount);
        }
    }
}
