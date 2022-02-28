using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace ZenAchitecture.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VisibilityLevel
    {
        ForMe,
        ForAdmins,
        ForEveryone
    };
}
