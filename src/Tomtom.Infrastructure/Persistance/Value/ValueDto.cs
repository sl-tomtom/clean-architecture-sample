namespace Tomtom.Infrastructure.Adapters.Value
{
    internal class ValueDto
    {
        public ValueDto(int id, string detail)
        {
            Id = id;
            Detail = detail;
        }

        public int Id { get; internal set; }
        public string Detail { get; internal set; }
    }
}