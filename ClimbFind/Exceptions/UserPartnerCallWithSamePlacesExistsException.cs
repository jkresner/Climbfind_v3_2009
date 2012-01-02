using System;

namespace ClimbFind.Exceptions
{
    public class UserPartnerCallWithSamePlacesExistsException : Exception
    {
        public UserPartnerCallWithSamePlacesExistsException(string message) : base(message) { }
    }
}
