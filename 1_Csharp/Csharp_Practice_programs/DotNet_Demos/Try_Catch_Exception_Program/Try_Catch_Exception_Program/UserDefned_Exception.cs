using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try_Catch_Exception_Program
{
    class VotingException : ApplicationException
    {
        public VotingException(string msg): base(msg)
        {
            // null
        }
    }

    class Vote
    {
        int Age;

        public void GetAge()
        {
            Console.WriteLine("Enter your Age :");
            Age = Convert.ToInt32(Console.Read());

            if (Age < 18)
            {
                throw(new VotingException("Age should be above 18 to vote"));
            }
            else
            {
                Console.WriteLine("Thanks for Voting");
                Console.ReadLine();
            }
                
        }
    }



    class UserDefned_Exception
    {
        public static void Main()
        {
            Vote vote = new Vote();
            try
            {
                vote.GetAge();
            }
            catch(VotingException ve)
            {
                Console.WriteLine(ve.Message);
            }
            Console.ReadLine();
            

            
        }
    }
}
