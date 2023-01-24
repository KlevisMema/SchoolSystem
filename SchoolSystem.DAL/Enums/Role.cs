using System.Text.Json.Serialization;

namespace SchoolSystem.DAL.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Teacher = 1,
        Student = 2
    }
}