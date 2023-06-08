using System.Runtime.Serialization;


namespace Bai14.Exceptions
{
    [Serializable]
    class InvalidDOBException: Exception
    {
        private const string DefaultMessage = "Invalid Date of Birth!";
        public InvalidDOBException() : base(DefaultMessage) { }
        public InvalidDOBException(string message) : base(DefaultMessage + " " + message) { }
        public InvalidDOBException(string message, Exception innerException) : base(message, innerException) { }
        protected InvalidDOBException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
