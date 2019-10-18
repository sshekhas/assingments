using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSyatem
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean status = true;
            int option,acc;
            Console.WriteLine("welcome to bank system");
            Console.WriteLine("you need to enter name and account opening balance to create account");
            UserDetails[] userdetails = new UserDetails[10];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0} name and account opening balance",(i+1));
                userdetails[i]= new UserDetails(Console.ReadLine(), Convert.ToInt64(Console.ReadLine()),(i+1));
            }
            for (int i = 0; i < 3; i++)
            {
                userdetails[i].DisplayUserDetails();
            }

            while (status)
            {
                Console.WriteLine("select one of the options\n0.Exit\n1.Deposit\n2.Withdraw");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0: status = false;
                        break;
                    case 1: Console.WriteLine("enter the account no. to deposit in");
                        acc = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter amount to deposit");
                        userdetails[(acc-1)].DepositToAcc(Convert.ToInt64(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("enter the account no. to withdraw from");
                        acc = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter amount you want to withdraw");
                        userdetails[(acc-1)].WithDrawFromAcc(Convert.ToInt64(Console.ReadLine()));
                        break;
                    default: Console.WriteLine("enter valid option");
                        break;
                }
            }

        }
    }
}
