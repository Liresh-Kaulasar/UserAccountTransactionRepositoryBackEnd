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
            var accountDetail = new PersonAccountModel();
            try
            {
                accountDetail = _accountsRepository.GetAccountDetailsByCode(code);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return accountDetail;
        }

        public int UpdateAccountDetails(PersonAccountModel personAccount)
        {
            return _accountsRepository.UpdateAccountDetails(personAccount);
        }

        public int CreateAccount(PersonAccountModel personAccount) { 
            return _accountsRepository.CreateAccount(personAccount);
        }
    }
}
