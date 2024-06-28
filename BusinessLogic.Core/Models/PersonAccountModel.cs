using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Core.Models
{
    public class PersonAccountModel
    {
        public int Code { get; set; }
        public int Person_code { get; set; }
        public string Account_number { get; set; }
        public decimal Outstanding_balance { get; set; }
    }
}
