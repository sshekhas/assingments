using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSyatem
{
    class UserDetails
    {
        private string name;
        private int accNo;
        private long balance;
        //internal int count = 0;

        public UserDetails(string name, long balance,int accNo)
        {
            this.name = name;
            this.balance = balance;
            this.accNo = accNo;
            Console.WriteLine("account created");
        }
        public void DisplayUserDetails()
        {
            Console.WriteLine("NAME: {0}\nACCOUNT NUMBER: {1}\nBALANCE: {2}",name,accNo,balance);
        }
        public void DepositToAcc(long deposit)
        {
            balance = (balance + deposit);
            Console.WriteLine("Deposited {0} to account with name {1}\nFinal balance is {2}",deposit,name,balance);

        }
        public void WithDrawFromAcc(long withdraw)
        { if ((balance - withdraw) < 500)
            {
                Console.WriteLine("can not withdraw {0} ERROR voilate MIN balance",withdraw);
            }
            else 
            {
                balance = (balance - withdraw);
                Console.WriteLine("Withdrawn {0} from account with name {1}\nFinal balance is {2}",withdraw,name,balance);
            }
            
        }

    }
}
