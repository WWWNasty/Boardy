using System;
using System.Runtime.Serialization;

namespace BusinessLogicLayer.Implementation.Exceptions
{
    [Serializable]
    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException()
        {
        }

        public CommentNotFoundException(string message) : base(message)
        {
        }

        public CommentNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}