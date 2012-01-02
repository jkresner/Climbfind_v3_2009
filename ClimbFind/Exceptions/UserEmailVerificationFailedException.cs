using System;

namespace ClimbFind.Exceptions
{
    public class UserEmailVerificationFailedException : Exception
    {
        public UserEmailVerificationFailedException(string message) : base (message) {}
    }
}
