using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Core.Models
{
    public class TransactionRecordModel
    {
            public int Code { get; set; }
            public int Account_code { get; set; } 
            public DateTime Transaction_date { get; set; } 
            public DateTime Capture_date { get; set; } 
            public double Amount { get; set; } 
            public string Description { get; set; }
    }
}
