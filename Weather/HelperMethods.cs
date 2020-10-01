using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    public class HelperMethods
    {
        public static string GetZipCode()
        {
            Console.WriteLine("What's your zip code?");
            string zipCode = Console.ReadLine();
            return zipCode;
        }

        public static double TempConv(string temp)
        {
            double tempKel = double.Parse(temp);
            double tempF = 1.8 * (tempKel - 273) + 32;
            return tempF;
        }

        public static bool YesOrNO()
        {
            Console.WriteLine("Would you like to enter another?\n" + "Please enter yes or no");
            string userResponse = Console.ReadLine();
            userResponse = userResponse.ToUpper();

            while (userResponse != "YES" && userResponse != "NO")
            {
                Console.WriteLine("Please answer: Yes or No\n");
                userResponse = Console.ReadLine();
                userResponse = userResponse.ToUpper();
            }

            if (userResponse == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
