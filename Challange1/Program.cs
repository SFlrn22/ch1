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
    public string EliminateProps1()
    {
        var car = new Car()
        {
            Engine = "N/A",
            Model = "Tesla",
        };
        
        return JsonConvert.SerializeObject(car);
    }
    
    [Benchmark]
    public string EliminateProps2()
    {
        var car = new Car()
        {
            Engine = "N/A",
            Model = "Tesla",
        };
        return DisplayValidProperties<Car>(car);
    }
    
    public static string DisplayValidProperties<T>(T obj)
    {
        if (obj == null) return default!;
        var newObj = Activator.CreateInstance<T>();
        // Get the properties of the object
        var properties = obj.GetType().GetProperties();

        foreach (var property in properties)
        {
            // Get the value of the property
            var value = property.GetValue(obj);

            // If the value is not "N/A", display the property
            if (value != null && !InvalidValues.INVALID_CAR_VALUES.Contains(value.ToString()??""))
            {
                property.SetValue(newObj, value);
            }
        }
        return System.Text.Json.JsonSerializer.Serialize(newObj);
    }
}



