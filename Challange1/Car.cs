using System.Text.Json.Serialization;

namespace Challange1;
public class Car
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Engine { get; set; } = string.Empty;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Model { get; set; } = string.Empty;
    
    public bool ShouldSerializeEngine() => !InvalidValues.INVALID_CAR_VALUES.Contains(Engine);
    public bool ShouldSerializeModel() => !InvalidValues.INVALID_CAR_VALUES.Contains(Model);
}