using System;
using System.Runtime.Serialization;

namespace BusinessLogicLayer.Implementation.Exceptions
{
    [Serializable]
    public class AdvertNotFoundException : Exception
    {
        public AdvertNotFoundException()
        {
        }

        public AdvertNotFoundException(string message) : base(message)
        {
        }

        public AdvertNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdvertNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}