using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException() : base("Invalid userId") { }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found") { }
    }

    public class TaskAlreadyExistsException : Exception
    {
        public TaskAlreadyExistsException() : base("The task already exists") { }
    }
}
