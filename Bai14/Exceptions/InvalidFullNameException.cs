
using System.Runtime.Serialization;


namespace Bai14.Exceptions
{
    [Serializable]
    class InvalidFullNameException : Exception
    {
        private const string DefaultMessage = "Invalid Full Name!";
        public InvalidFullNameException() : base(DefaultMessage) { }
        public InvalidFullNameException(string message) : base(DefaultMessage + " " + message) { }
        public InvalidFullNameException(string message, Exception innerException) : base(message, innerException) { }
        protected InvalidFullNameException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
