using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SchoolSystem.DAL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        Present = 1,
        Missing = 2,
    }
}