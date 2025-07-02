using Bloomberglp.Blpapi;
using Request = Bloomberglp.Blpapi.Request;
using System.Globalization;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses
{
    public static class Extensions
    {
        public static long GetAsLongOrDefault(this Message msg, string field, long defaultValue = 0)
            => GetAsLongOrDefault(msg, new Name(field),  defaultValue);
        public static long GetAsLongOrDefault(this Message msg, Name field, long defaultValue = 0)
        => msg.HasElement(field) ? (long)msg.GetElementAsInt64(field) : defaultValue;

        public static int GetAsIntOrDefault(this Message msg, string field, int defaultValue = 0)
             => GetAsIntOrDefault(msg, new Name(field), defaultValue);
        public static int GetAsIntOrDefault(this Message msg, Name field, int defaultValue = 0)
        => msg.HasElement(field) ? (int)msg.GetElementAsInt32(field) : defaultValue;


        public static float GetAsFloatOrDefault(this Message msg, string field, float defaultValue = 0)
            => GetAsFloatOrDefault(msg, new Name(field), defaultValue);

        public static float GetAsFloatOrDefault(this Message msg, Name field, float defaultValue = 0)
            => msg.HasElement(field) ? (float)msg.GetElementAsFloat32(field) : defaultValue;

        public static bool GetAsBoolOrDefault(this Message msg, string field, bool defaultValue = false)
            => GetAsBoolOrDefault(msg, new Name(field), defaultValue);
        public static bool GetAsBoolOrDefault(this Message msg, Name field, bool defaultValue = false)
            => msg.HasElement(field) ? (bool)msg.GetElementAsBool(field) : defaultValue;


        public static double GetAsDoubleOrDefault(this Message msg, string field, double defaultValue = 0)
          => GetAsDoubleOrDefault(msg, new Name(field), defaultValue);

        public static double GetAsDoubleOrDefault(this Message msg, Name field, double defaultValue = 0)
            => msg.HasElement(field) ? (double)msg.GetElementAsFloat64(field) : defaultValue;

        public static string GetAsStringOrDefault(this Message msg, string field, string defaultValue = "")
             => GetAsStringOrDefault(msg, new Name(field), defaultValue);
        public static string GetAsStringOrDefault(this Message msg, Name field, string defaultValue = "")
             => msg.HasElement(field) ? (string)msg.GetElementAsString(field) : defaultValue;

        public static DateTime? GetAsDateTimeOrDefault(this Message msg, string field, string format, DateTime? defaultValue = null)
            => GetAsDateTimeOrDefault(msg, new Name(field), format, defaultValue);
        public static DateTime? GetAsDateTimeOrDefault(this Message msg, Name field, string format, DateTime? defaultValue = null)
         => msg.HasElement(field) && msg.GetElementAsInt32(field) != 0 ? DateTime.ParseExact(msg.GetElementAsInt32(field).ToString(), format, CultureInfo.InvariantCulture) : defaultValue;

        public static TimeSpan? GetAsTimeSpanOrDefaultFromSecond(this Message msg, string field, TimeSpan? defaultValue = null)
        => GetAsTimeSpanOrDefaultFromSecond(msg, new Name(field), defaultValue);
        public static TimeSpan? GetAsTimeSpanOrDefaultFromSecond(this Message msg, Name field, TimeSpan? defaultValue = null)
         => msg.HasElement(field) ? TimeSpan.FromSeconds(msg.GetElementAsInt32(field)): defaultValue;

       
    }
}
