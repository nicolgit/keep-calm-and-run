using System;

namespace kcar.model
{
    public class kcarBase : Exception
    {
        public kcarBase(string message) : base(message)
        {
        }
    }

    public class kcarSettingsNotFoundException : kcarBase
    {
        public kcarSettingsNotFoundException(string message) : base(message)
        {
        }
    }

    public class kcarNotFoundException : kcarBase
    {
        public kcarNotFoundException(string message) : base(message)
        {
        }
    }

    public class kcarParametersException : kcarBase
    {
        public kcarParametersException(string message) : base(message)
        {
        }
    }
}