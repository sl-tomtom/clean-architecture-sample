using System;

namespace Tomtom.Domain.Value
{
    public class Value
    {
        public static Value Create(string description, int id) => new Value(description, id);

        public int Id { get; }
        public string Description { get; }

        private Value(string value, int id)
        {
            Description = value;
            Id = id;
        }
    }
}
