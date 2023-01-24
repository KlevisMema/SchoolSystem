using System.Text.Json.Serialization;

namespace SchoolSystem.DAL.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }
}