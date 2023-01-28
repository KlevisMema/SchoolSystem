#region Usings

using System.Text.Json.Serialization;

#endregion

namespace SchoolSystem.DAL.Enums
{
    /// <summary>
    ///     Gender Enum starting from 1.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }
}