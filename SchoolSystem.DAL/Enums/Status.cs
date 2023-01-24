using System.Text.Json.Serialization;

namespace SchoolSystem.DAL.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Present = 1,
        Missing = 2,
    }
}