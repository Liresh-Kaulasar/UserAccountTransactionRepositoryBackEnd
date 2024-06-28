using BusinessLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TransactionsRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UserTransactionDatabaseConnection"].ConnectionString;
        public TransactionsRepository() { }

        public List<TransactionRecordModel> GetTransactionDetailsByAccountCode(int accountCode)
        {
            List<TransactionRecordModel> transactions = new List<TransactionRecordModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("StoredProc_GetTransactionDetailsByAccountCode", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@account_code", accountCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TransactionRecordModel transaction = new TransactionRecordModel
                            {
                                Code = Convert.ToInt32(reader["code"]),
                                Account_code = Convert.ToInt32(reader["account_code"]),
                                Amount = Convert.ToDouble(reader["amount"]),
                                Capture_date = Convert.ToDateTime(reader["capture_date"]),
                                Transaction_date = Convert.ToDateTime(reader["transaction_date"]),
                                Description = Convert.ToString(reader["description"]),
                            };

                            transactions.Add(transaction);
                        }
                    }
                }
            }

            return transactions;
        }

        public TransactionRecordModel GetTransactionDetailsByTransactionCode(int transactionCode)
        {
            TransactionRecordModel transactions = new TransactionRecordModel();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("StoredProc_GetTransactionDetailsByTransactionCode", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@code", transactionCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TransactionRecordModel transaction = new TransactionRecordModel
                            {
                                Code = Convert.ToInt32(reader["code"]),
                                Account_code = Convert.ToInt32(reader["account_code"]),
                                Amount = Convert.ToDouble(reader["amount"]),
                                Capture_date = Convert.ToDateTime(reader["capture_date"]),
                                Transaction_date = Convert.ToDateTime(reader["transaction_date"]),
                                Description = Convert.ToString(reader["description"]),
                            };
                        }
                    }
                }
            }

            return transactions;
        }

        public int CreateTransaction(TransactionRecordModel transactionRecord)
        {
            int rowsAffected = 0; 
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertTransaction", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@account_code", transactionRecord.Account_code);
                    command.Parameters.AddWithValue("@transaction_date", transactionRecord.Transaction_date);
                    command.Parameters.AddWithValue("@capture_date", transactionRecord.Capture_date);
                    command.Parameters.AddWithValue("@amount", transactionRecord.Amount);
                    command.Parameters.AddWithValue("@description", transactionRecord.Description);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
    }
}
