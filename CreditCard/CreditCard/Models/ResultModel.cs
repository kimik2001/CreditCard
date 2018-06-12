using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCard.Models
{
    public class ResultModel
    {
        public string result { get; set; }
        public string cardtype { get; set; }

        public bool validatation (string cardnumber, string expirydate)
        {
            int len1 = cardnumber.Length;
            int len2 = expirydate.Length;
            if (len1 < 15 || len1 > 16)
            {
                result = "Invalid";
                cardtype = "Unknown";
                return false;
            }
            if (len2 != 6)
            {
                result = "Invalid";
                cardtype = "Unknown";
                return false;
            }
            string firstdigit = cardnumber.Substring(0, 1);
            if (len1 == 15)
            {
                if (firstdigit != "3")
                {
                    result = "Invalid";
                    cardtype = "Unknown";
                    return false;
                }
                else
                {
                    result = "Valid";
                    cardtype = "Amex";
                    return true;
                }
            }
            else
            {
                if (firstdigit == "4") // Visa
                {
                    if (isLeapYear(expirydate))
                    {
                        result = "Valid";
                        cardtype = "Visa";
                        return true;
                    }
                    else
                    {
                        result = "Invalid";
                        cardtype = "Unknown";
                        return false;
                    }
                }
                else if (firstdigit == "5") //MasterCard
                {
                    if (isPrimeNumber(expirydate))
                    {
                        result = "Valid";
                        cardtype = "Master";
                        return true;
                    }
                    else
                    {
                        result = "Invalid";
                        cardtype = "Unknown";
                        return false;
                    }
                }
                else if (firstdigit == "3") //JCB
                {
                    result = "Valid";
                    cardtype = "JCB";
                    return true;
                }
                else
                {
                    result = "Valid";
                    cardtype = "Unknown";
                    return false;
                }

            }
            return false;
        }

        bool isLeapYear(string expirydate)
        {
            int year = Convert.ToInt32(expirydate.Substring(2, 4));
            if (year % 4 == 0)
                return true;
            else
                return false;
        }

        static bool isPrimeNumber(string expirydate)
        {
            int year = Convert.ToInt32(expirydate.Substring(2, 4));
            Console.WriteLine(year.ToString());
            int count = 0;
            for (int i = 2; i <= year / 2; i++)
            {
                if (year % i == 0)
                {
                    count++;
                    break;
                }
            }
            if (count > 0)
                return false;
            else
                return true;
        }
    }
}