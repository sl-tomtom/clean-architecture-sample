namespace Tomtom.Application.Value
{
    public class ValueViewModel
    {
        public int Id { get; set; }

        public string Detail { get; set; }

        public ValueViewModel(int id, string detail)
        {
            Id = id;
            Detail = detail;
        }
    }
}