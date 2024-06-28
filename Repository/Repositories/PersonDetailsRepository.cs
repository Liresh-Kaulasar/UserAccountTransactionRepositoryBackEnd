using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BusinessLogic.Core.Models;
using System.Runtime.Remoting.Contexts;

namespace Repository.Repositories
{
    public class PersonDetailsRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UserTransactionDatabaseConnection"].ConnectionString;

        public PersonDetailsRepository()
        {
        }

        public List<PersonDetailsModel> GetPersonDetails()
        {
            var detailsList = new List<PersonDetailsModel>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("StoredProc_GetAllPersonDetails", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var details = new PersonDetailsModel
                {
                    Code = Convert.ToInt32(reader["code"]),
                    Name = reader["name"].ToString(),
                    Surname = reader["surname"].ToString(),
                    Id_number = reader["id_number"].ToString()
                };
                detailsList.Add(details);
            }

            return detailsList;
        }

        public int UpdatePersonDetails(PersonDetailsModel personDetails)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("StoredProc_UpdatePersonDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Code", personDetails.Code);
                    command.Parameters.AddWithValue("@Name", personDetails.Name);
                    command.Parameters.AddWithValue("@Surname", personDetails.Surname);
                    command.Parameters.AddWithValue("@IdNumber", personDetails.Id_number);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public int CreatePerson(PersonDetailsModel personDetails)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("StoredProc_InsertPersonalDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", personDetails.Name);
                    command.Parameters.AddWithValue("@Surname", personDetails.Surname);
                    command.Parameters.AddWithValue("@IdNumber", personDetails.Id_number);

                    try
                    {
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }

            return rowsAffected;
        }


        public PersonDetailsModel GetPersonDetailsByCode(int code)
        {
            PersonDetailsModel personDetails = new PersonDetailsModel();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("StoredProc_GetPersonDetailsById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Code", code);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            personDetails = new PersonDetailsModel
                            {
                                Code = Convert.ToInt32(reader["Code"]),
                                Name = reader["Name"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                Id_number = reader["Id_number"].ToString()
                            };
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
            }

            return personDetails;
        }

        public List<PersonDetailsModel> SearchPersonalDetails(string searchString)
        {
            var detailsList = new List<PersonDetailsModel>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("StoredProc_SearchPersonalDetails", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@SearchValue", searchString);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var details = new PersonDetailsModel
                {
                    Code = Convert.ToInt32(reader["code"]),
                    Name = reader["name"].ToString(),
                    Surname = reader["surname"].ToString(),
                    Id_number = reader["id_number"].ToString()
                };
                detailsList.Add(details);
            }

            return detailsList;
        }
    }
}
