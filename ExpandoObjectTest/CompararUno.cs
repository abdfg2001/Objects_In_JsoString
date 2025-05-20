using Newtonsoft.Json;
using System.Dynamic;
using System.Reflection;


namespace ExpandoObjectTest
{
    public static class CompararUno
    {

        //compare if there is an object in a list of json objects
        public static List<IPeople> Comparar<T>(string jsonStr) where T : new()
        {
            var value = new T();
            var expandoObject = JsonConvert.DeserializeObject<List<ExpandoObject>>(jsonStr);
            dynamic dynamicObject = expandoObject!;
            var People = new List<IPeople>();
            foreach (var item in dynamicObject)
            {
                var properties = ((IDictionary<string, object>)item).Keys;
                var values = ((IDictionary<string, object>)item).Values;
                var objProperties = value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                int count = 0;
                count = properties.Count();
                if (count == objProperties.Length)
                {
                    //Console.WriteLine("Igual Object de Longitud");
                    count = 0;
                    foreach (var property in properties)
                    {
                        //Console.WriteLine(property);
                        var prop = objProperties.FirstOrDefault(p => p.Name == property);
                        if (prop != null)
                        {
                            count++;
                        }
                    }
                    if (count == objProperties.Length)
                    {
                        //Console.WriteLine("Igual Object: " + value.GetType());
                        var Clase = Activator.CreateInstance(value.GetType());
                        for (int i = 0; i < objProperties.Length; i++)
                        {

                            if (objProperties[i].PropertyType == typeof(string))
                            {
                                Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, values.ElementAt(i).ToString());
                            }
                            else if (objProperties[i].PropertyType == typeof(int))
                            {
                                Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, Convert.ToInt32(values.ElementAt(i)));
                            }
                            else if (objProperties[i].PropertyType == typeof(bool))
                            {
                                Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, Convert.ToBoolean(values.ElementAt(i)));
                            }
                            else if (objProperties[i].PropertyType == typeof(List<string>))
                            {
                                var list = new List<string>();
                                foreach (var item1 in (IEnumerable<object>)values.ElementAt(i))
                                {
                                    list.Add(item1.ToString()!);
                                }
                                Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, list);
                            }
                            else
                                Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, values.ElementAt(i));
                        }
                        People.Add((IPeople)Clase!);
                    }
                    else
                    {
                        //Console.WriteLine("Diferente Object con igual numero de Campos");
                        for (int i = 0; i < properties.Count(); i++)
                        {
                            //Console.WriteLine("Property: " + properties.ElementAt(i) + " Value: " + values.ElementAt(i));
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("Diferente Object");
                    for (int i = 0; i < properties.Count(); i++)
                    {
                        //Console.WriteLine("Property: " + properties.ElementAt(i) + " Value: " + values.ElementAt(i));
                    }
                }

            }
            return People;
        }

        //compare between an object and an object in a json string list
        public static IPeople Comparar1<T>(string jsonStr) where T : new()
        {
            var value = new T();
            var expandoObject = JsonConvert.DeserializeObject<ExpandoObject>(jsonStr);
            dynamic dynamicObject = expandoObject!;
            IPeople People = null!; // Initialize the variable to avoid CS0165  


            var properties = ((IDictionary<string, object>)dynamicObject).Keys;
            var values = ((IDictionary<string, object>)dynamicObject).Values;
            var objProperties = value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int count = 0;
            count = properties.Count();
            if (count == objProperties.Length)
            {
                count = 0;
                foreach (var property in properties)
                {
                    var prop = objProperties.FirstOrDefault(p => p.Name == property);
                    if (prop != null)
                    {
                        count++;
                    }
                }
                if (count == objProperties.Length)
                {
                    var Clase = Activator.CreateInstance(value.GetType());
                    for (int i = 0; i < objProperties.Length; i++)
                    {
                        if (objProperties[i].PropertyType == typeof(string))
                        {
                            Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, values.ElementAt(i).ToString());
                        }
                        else if (objProperties[i].PropertyType == typeof(int))
                        {
                            Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, Convert.ToInt32(values.ElementAt(i)));
                        }
                        else if (objProperties[i].PropertyType == typeof(bool))
                        {
                            Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, Convert.ToBoolean(values.ElementAt(i)));
                        }
                        else if (objProperties[i].PropertyType == typeof(List<string>))
                        {
                            var list = new List<string>();
                            foreach (var item1 in (IEnumerable<object>)values.ElementAt(i))
                            {
                                list.Add(item1.ToString()!);
                            }
                            Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, list);
                        }
                        else
                            Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, values.ElementAt(i));
                    }
                    People = (IPeople)Clase!;
                }
            }

            return People;
        }

        //compare if a list of objects is present in a list of JSON string objects
        public static List<IPeople> Comparar2(Type[] types, string jsonStr)
        {
            var expandoObject = JsonConvert.DeserializeObject<List<ExpandoObject>>(jsonStr);
            dynamic dynamicObject = expandoObject!;
            var People = new List<IPeople>();
            foreach (var type in types)
            {
                var value = Activator.CreateInstance(type);
                foreach (var item in dynamicObject)
                {
                    var properties = ((IDictionary<string, object>)item).Keys;
                    var values = ((IDictionary<string, object>)item).Values;
                    var objProperties = value!.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    int count = 0;
                    count = properties.Count();
                  if (count == objProperties.Length)
                  {
                    count = 0;
                    foreach (var property in properties)
                    {
                        //Console.WriteLine(property);
                        var prop = objProperties.FirstOrDefault(p => p.Name == property);
                        if (prop != null)
                        {
                            count++;
                        }
                    }
                        if (count == objProperties.Length)
                        {
                            //Console.WriteLine("Igual Object: " + value.GetType());
                            var Clase = Activator.CreateInstance(value.GetType());
                            for (int i = 0; i < objProperties.Length; i++)
                            {
                                if (objProperties[i].PropertyType == typeof(string))
                                {
                                    Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, values.ElementAt(i).ToString());
                                }
                                else if (objProperties[i].PropertyType == typeof(int))
                                {
                                    Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, Convert.ToInt32(values.ElementAt(i)));
                                }
                                else if (objProperties[i].PropertyType == typeof(bool))
                                {
                                    Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, Convert.ToBoolean(values.ElementAt(i)));
                                }
                                else if (objProperties[i].PropertyType == typeof(List<string>))
                                {
                                    var list = new List<string>();
                                    foreach (var item1 in (IEnumerable<object>)values.ElementAt(i))
                                    {
                                        list.Add(item1.ToString()!);
                                    }
                                    Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, list);
                                }
                                else
                                    Clase!.GetType().GetProperty(objProperties[i].Name)?.SetValue(Clase, values.ElementAt(i));
                            }


                            People.Add((IPeople)Clase!);
                        } 
                  }
                }
            }
            return People;
        }
    }
}
