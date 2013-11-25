using System;
using System.Net.Mail;

namespace Momento.Models.Subscriber.Extensions
{
    public class StringExtensions
    {
        public static bool IsValidEmail(string emailAddress)
        {
            if (!String.IsNullOrEmpty(emailAddress))
            {
                try
                {
                    var address = new MailAddress(emailAddress);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }   
            }
            return false;
        }
    }
}