using System;

namespace kcar.model
{
    public class kcarSettingsNotFoundException : Exception
    {
        public kcarSettingsNotFoundException(string message) : base(message)
        {
        }
    }

    public class kcarNotFoudException : Exception
    {
        public kcarNotFoudException(string message) : base(message)
        {
        }
    }
}