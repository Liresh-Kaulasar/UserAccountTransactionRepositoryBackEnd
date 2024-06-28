using BusinessLogic.Core.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Shared.Services
{
    public class TransactionsService
    {
        public TransactionsRepository _transactionsRepository = new TransactionsRepository();

        public TransactionsService() { }

        public List<TransactionRecordModel> GetTransactionDetailsByAccountCode(int accountCode)
        {
            return _transactionsRepository.GetTransactionDetailsByAccountCode(accountCode);
        }

        public int CreateTransaction(TransactionRecordModel transactionRecord)
        {
            return _transactionsRepository.CreateTransaction(transactionRecord);
        }

        public TransactionRecordModel GetTransactionDetailsByTransactionCode(int transactionCode)
        {
            return _transactionsRepository.GetTransactionDetailsByTransactionCode(transactionCode);
        }
    }
}
