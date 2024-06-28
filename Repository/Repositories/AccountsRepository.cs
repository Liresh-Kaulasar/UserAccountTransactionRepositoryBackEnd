using BusinessLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccountsRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UserTransactionDatabaseConnection"].ConnectionString;


        public List<PersonAccountModel> GetAccountDetailsByPersonCode(int personCode)
        {
            List<PersonAccountModel> accounts = new List<PersonAccountModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("StoredProc_GetAccountDetailsByPersonCode", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonCode", personCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PersonAccountModel account = new PersonAccountModel
                            {
                                Code = Convert.ToInt32(reader["code"]),
                                Person_code = Convert.ToInt32(reader["person_code"]),
                                Account_number = reader["account_number"].ToString(),
                                Outstanding_balance = Convert.ToDecimal(reader["outstanding_balance"])
                            };

                            accounts.Add(account);
                        }
                    }
                }
            }

            return accounts;
        }

        public PersonAccountModel GetAccountDetailsByCode(int code)
        {

            PersonAccountModel personAccount = new PersonAccountModel();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("StoredProc_GetAccountDetailsByCode", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Code", code);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personAccount = new PersonAccountModel
                            {
                                Code = Convert.ToInt32(reader["code"]),
                                Person_code = Convert.ToInt32(reader["person_code"]),
                                Account_number = reader["account_number"].ToString(),
                                Outstanding_balance = Convert.ToDecimal(reader["outstanding_balance"])
                            };
                        }
                    }
                }
            }

            return personAccount;
        }

        public int UpdateAccountDetails(PersonAccountModel personAccount)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("StoredProc_UpdateAccountDetails", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Code", personAccount.Code);
                    command.Parameters.AddWithValue("@AccountNumber", personAccount.Account_number);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }
    }

}