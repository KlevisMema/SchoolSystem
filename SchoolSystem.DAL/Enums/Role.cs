#region Usings

using System.Text.Json.Serialization;

#endregion

namespace SchoolSystem.DAL.Enums
{
    /// <summary>
    ///     Roles enum starting from 1.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Teacher = 1,
        Student = 2
    }
}