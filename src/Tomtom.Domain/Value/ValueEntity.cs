namespace Tomtom.Domain.Value
{
    public class ValueEntity
    {
        public static ValueEntity Create(string description, int id) => new ValueEntity(description, id);

        public int Id { get; }
        public string Description { get; }

        private ValueEntity(string value, int id)
        {
            Description = value;
            Id = id;
        }
    }
}
