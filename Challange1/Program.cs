using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Challange1;
using Newtonsoft.Json;



public class Program
{
    public static void Main(string[] args)
    {
        
        var summary = BenchmarkRunner.Run<Method>();
    }
}

[SimpleJob(RuntimeMoniker.Net80)]
[RPlotExporter]
public class Method
{

    [Benchmark]
    public string EliminateProps()
    {
        var json = @"
        {
            ""prop1"":""N/A"",
            ""prop2"":""-"",
            ""prop3"":""valid"",
            ""prop4"":""test"",
            ""prop5"": [""test"", ""N/A"", ""-""]
            ""prop6"": { ""prop7"": ""N/A"" },
            ""prop8"": [""-"", ""N/A"", ""-""]
        }";
        Console.WriteLine(json);
        string output = string.Empty;
        
        var lines = json.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var line in lines)
        {
            string arrayLine = String.Empty;
            bool foundInvalidArrayElement = false;
            var isValidLine = true;
            foreach (var invalidValue in InvalidValues.INVALID_CAR_VALUES)
            {
                if (line.Contains('[') && line.Contains(invalidValue))
                {
                    if (foundInvalidArrayElement)
                    {
                        arrayLine = arrayLine.Replace(invalidValue, @"");
                    }
                    else
                    {
                        arrayLine = line.Replace(invalidValue, @"");
                    }
                    foundInvalidArrayElement = true;
                }
                if (line.Contains(invalidValue) && string.IsNullOrEmpty(arrayLine))
                {
                    isValidLine = false;
                    break;
                }
            }

            if (isValidLine)
            {
                if (string.IsNullOrEmpty(arrayLine))
                {
                    output += line + Environment.NewLine;
                }
                else
                {
                    arrayLine = arrayLine.Replace("\"\"", "").Replace(", ", "").Replace(" ,", "");
                    output += arrayLine + Environment.NewLine;
                }
            }
        }
        // while (json.Contains('\n'))
        // {
        //     var isValidLine = true;
        //     var line = json.Substring(json.IndexOf('"'), json.IndexOf('\n'));
        //     foreach (var invalidValue in InvalidValues.INVALID_CAR_VALUES)
        //     {
        //         if (line.Contains(invalidValue))
        //         {
        //             isValidLine = false;
        //         }
        //     }
        //
        //     if (isValidLine)
        //     {
        //         output += line;
        //     }
        //     json = json.Remove(json.IndexOf('"'), json.IndexOf('\n') - json.IndexOf('"'));
        // }

        Console.WriteLine("-----");
        Console.WriteLine(output);
        
        return output;
    }
    
    [Benchmark]
    public string EliminateProps1()
    {
        var car = new Car()
        {
            Engine = "N/A",
            Model = "Tesla",
        };
        
        return JsonConvert.SerializeObject(car);
    }
    
    // [Benchmark]
    // public string EliminateProps2()
    // {
    //     var car = new Car()
    //     {
    //         Engine = "N/A",
    //         Model = "Tesla",
    //     };
    //     return DisplayValidProperties<Car>(car);
    // }
    //
    // public static string DisplayValidProperties<T>(T obj)
    // {
    //     if (obj == null) return default!;
    //     var newObj = Activator.CreateInstance<T>();
    //     // Get the properties of the object
    //     var properties = obj.GetType().GetProperties();
    //
    //     foreach (var property in properties)
    //     {
    //         // Get the value of the property
    //         var value = property.GetValue(obj);
    //
    //         // If the value is not "N/A", display the property
    //         if (value != null && !InvalidValues.INVALID_CAR_VALUES.Contains(value.ToString()??""))
    //         {
    //             property.SetValue(newObj, value);
    //         }
    //     }
    //     return System.Text.Json.JsonSerializer.Serialize(newObj);
    // }
}



