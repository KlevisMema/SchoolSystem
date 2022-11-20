using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SchoolSystem.DAL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        Male  =1,
        Female
    }
}