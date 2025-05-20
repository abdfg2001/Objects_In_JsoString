
namespace ExpandoObjectTest
{
    public interface IPeople
    {
    }
    public class PersonAge : IPeople
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonGen : IPeople
    {
        public string? Name { get; set; }
        public string? Gen { get; set; }
        public int Height { get; set; }
    }
    public class Person : IPeople
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public bool IsEmployed { get; set; }
        public List<string>? Skills { get; set; }
    }

    public class PersonCodigo : IPeople
    {
        public string? Codigo { get; set; }
    }
}
