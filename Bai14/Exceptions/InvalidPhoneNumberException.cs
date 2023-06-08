using System.Runtime.Serialization;

namespace Bai14.Exceptions
{
    [Serializable]
    class InvalidPhoneNumberException : Exception
    {
        private const string DefaultMessage = "Invalid Phone Number!";
        public InvalidPhoneNumberException() : base(DefaultMessage) { }
        public InvalidPhoneNumberException(string message) : base(DefaultMessage+" "+message) { }
        public InvalidPhoneNumberException(string message, Exception inner) : base(message, inner) { }
        protected InvalidPhoneNumberException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
