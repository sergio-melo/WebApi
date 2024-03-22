using System.Text.Json.Serialization;

namespace WebApi_Video.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        HR,
        Financial,
        Purchas,
        Customer,
        Janitorial
    }
}
