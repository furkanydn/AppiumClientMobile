using System;
using System.Collections.Generic;
using System.Text;

namespace AppiumClientMobile.Service.Exceptions
{
    public class InvalidServerInstanceException : Exception
    {
        private readonly static string Prefix = "Geçersiz sunucu örneği istisnası oluştu: ";

        public InvalidServerInstanceException(string message, Exception exception) : base($"{Prefix}{message}", exception)
        {

        }

        public InvalidServerInstanceException(string message) : base($"{Prefix}{message}")
        {

        }
    }
}
