using System;
using System.Runtime.Serialization;

namespace Tomtom.Application.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        private readonly int id;

        public NotFoundException()
        {
        }

        public NotFoundException(int id, string message) : base(message)
        {
            this.id = id;
        }

        public NotFoundException(int id, string message, Exception innerException) : base(message, innerException)
        {
            this.id = id;

        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}