using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "aaaaaaaaa";
            string letters = "acdegilmnoprstuw";
            Int64 iHashString = 0;
            int i = 0, numberOfIterations = 0;

            while (iHashString != 910897038977002 && i < message.Length)
            {
                iHashString = hash(message);
                numberOfIterations++;

                if (iHashString < 910897038977002)
                {
                    message = message.Remove(i,1).Insert(i,letters[letters.IndexOf(message[i]) + 1].ToString());
                }
                else if (iHashString > 910897038977002)
                {
                    message = message.Remove(i, 1).Insert(i, letters[letters.IndexOf(message[i]) - 1].ToString());
                    i++;
                }
            }
                                                
            if (iHashString == 910897038977002)
                Console.WriteLine("Success! The string hash is {0} and the original string is {1} and this took {2} iterations", iHashString, message, numberOfIterations);
            else
                Console.WriteLine("Fail. The string is {0}", iHashString);
            
            Console.ReadLine();
            return;
        }

        static Int64 hash(string s)
        {
            Int64 h = 7;
            string letters = "acdegilmnoprstuw";
            for(Int32 i = 0; i < s.Length; i++) 
            {
                h = (h * 37 + letters.IndexOf(s[i])); 
            }
            return h;
        }
