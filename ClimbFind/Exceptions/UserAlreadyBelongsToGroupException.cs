using System;

namespace ClimbFind.Exceptions
{
    public class UserAlreadyBelongsToGroupException : Exception
    {
        public UserAlreadyBelongsToGroupException(string message) : base (message) {}
    }
}
