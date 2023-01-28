#region Usings

using System.Text.Json.Serialization;

#endregion

namespace SchoolSystem.DAL.Enums
{
    /// <summary>
    ///     Status enum starting from 1.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Present = 1,
        Missing = 2,
    }
}