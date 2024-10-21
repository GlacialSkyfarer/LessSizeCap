using System.Text.Json.Serialization;

namespace LessSizeCap;

public class Config {
    [JsonInclude] public bool SomeSetting = true;
}
