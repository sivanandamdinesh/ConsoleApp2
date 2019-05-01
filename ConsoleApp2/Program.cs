using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Increment increment = new Increment {id = 1};
            List<Increment> increments = new List<Increment>();
            increments.Add(new Increment {id = 1});
            increments.Add(new Increment {id = 2});
            Account account = new Account {accountid = 1, increments = increments};
            List<Account> accounts = new List<Account>();
            accounts.Add(account);

            var increment1 = increments.Where(x => x.id == 1).ToList();
            var plans = new List<Plan>
            {
                new Plan
                {
                    accounts = accounts,
                    planid = 1
                }
            };

            var s = plans.Where(x => x.planid == 1)
                .Select(x => new
                {
                    ////plans = x,
                    account = x.accounts
                        .Where(y => y.accountid == 1)
                        .Select(z => new
                            {
                                increments = z.increments.Where(a => a.id == 0)
                            }

                        )
                }).ToList();
        }
    }

    public class Plan
    {
        public List<Account> accounts { get; set; }
        public int planid { get; set; }
    }

    public class Account
    {
        public int accountid { get; set; }
        public List<Increment> increments { get; set; }
    }

    public class Increment
    {
        public  int id { get; set; }
    }

    /* code changed*/
}
