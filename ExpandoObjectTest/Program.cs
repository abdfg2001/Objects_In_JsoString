// See https://aka.ms/new-console-template for more information  
using ExpandoObjectTest;
using System.Reflection;




string json = @"[{""Codigo"":53},{ ""Name"": ""John"", ""Age"": 30 },{""Name"": ""Adrian"", ""Gen"": ""Male"", ""Height"": 12},{ ""Name"": ""Andres"", ""Age"": 14 },{ ""Sex"": ""Man"", ""Age"": 12 },{""Codigo"":19},{""Name"": ""Santa Claus"", ""Age"": 120, ""IsEmployed"":true,""Skills"":[""Gift"",""Toys"",""Merry Christmas""]}]";
var JsonString = "[{\"Name\": \"Rose\", \"Gen\": \"Female\", \"Height\": 17},{\"Name\":\"John Doe\",\"Age\":30,\"IsEmployed\":true,\"Skills\":[\"C#\",\"JavaScript\",\"Python\"]},{\"Name\": \"Adrian\", \"Gen\": \"Male\", \"Height\": 12},{\"Name\": \"Peter\", \"Gen\": \"Male\", \"Height\": 8}]";
var JsonAlong = "{\"Name\":\"Santa Claus\",\"Age\":120,\"IsEmployed\":true,\"Skills\":[\"Gift\",\"Toys\",\"Merry Christmas\"]}";
var JsonShort = "{\"Codigo\":19}";


IPeople Personas = CompararUno.Comparar1<PersonCodigo>(JsonShort);

Console.WriteLine("*************compare between an object and an object in a json string list*************");

if (Personas != null)
{
    var properties = Personas.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach (var property in properties)
    {
        if (property.CanWrite)
        {
            if (property.PropertyType == typeof(List<string>))
            {
                var list = (List<string>)property.GetValue(Personas)!;
                foreach (var item1 in list)
                {
                    Console.WriteLine("Property: " + property.Name + " Value: " + item1);
                }
            }
            else
                Console.WriteLine("Property: " + property.Name + " Value: " + property.GetValue(Personas));
        }
    }
}
else
{
    Console.WriteLine("No object found");
}

Console.WriteLine("************compare if there is an object in a list of json objects*************");

List<IPeople> people = CompararUno.Comparar<Person>(JsonString);

Console.WriteLine("***********************************");

foreach (var item in people)
{
    var properties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach (var property in properties)
    {
        if (property.CanWrite)
        {
            if (property.PropertyType == typeof(List<string>))
            {
                var list = (List<string>)property.GetValue(item)!;
                foreach (var item1 in list)
                {
                    Console.WriteLine("Property: " + property.Name + " Value: " + item1);
                }
            }
            else
                Console.WriteLine("Property: " + property.Name + " Value: " + property.GetValue(item));
        }
        
    }
    Console.WriteLine("---------------------------------");
}

Console.WriteLine("***********************************");

 
List<IPeople> Objetos = CompararUno.Comparar2(new Type[] { typeof(Person), typeof(PersonGen), typeof(PersonAge), typeof(PersonCodigo) }, json);
Console.WriteLine("************compare if a list of objects is present in a list of JSON string objects************");
foreach (var item in Objetos)
{
    var properties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    foreach (var property in properties)
    {
        if (property.CanWrite)
        {
            if (property.PropertyType == typeof(List<string>))
            {
                var list = (List<string>)property.GetValue(item)!;
                foreach (var item1 in list)
                {
                    Console.WriteLine("Property: " + property.Name + " Value: " + item1);
                }
            }
            else
                Console.WriteLine("Property: " + property.Name + " Value: " + property.GetValue(item));
        }
    }
    Console.WriteLine("---------------------------------");
}
