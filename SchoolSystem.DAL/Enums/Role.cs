using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SchoolSystem.DAL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {
        Teacher = 1,
        Student = 2
    }
}
