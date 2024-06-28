using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Core.Models
{
    public class TransactionRecordModel
    {
            public int AccountCode { get; set; } 
            public DateTime TransactionDate { get; set; } 
            public DateTime CaptureDate { get; set; } 
            public double Amount { get; set; } 
            public string Description { get; set; }
    }
}
