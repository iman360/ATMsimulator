using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CurrentUser
    {
        public string clientCode { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string NIP { get; set; }
        public int isLock { get; set; }
        public string clientCodeString
        {
            get
            {
                return clientCode.ToString();
            }
        }
    }
}
