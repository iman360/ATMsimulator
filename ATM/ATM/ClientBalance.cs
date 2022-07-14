using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ClientBalance
    {
        
        public string accountTypeCode { get; set; }
        public int Balance { get; set; }
        public string BalanceString
        {
            get
            {
                return Balance + " $";
            }
        }
    }
}
