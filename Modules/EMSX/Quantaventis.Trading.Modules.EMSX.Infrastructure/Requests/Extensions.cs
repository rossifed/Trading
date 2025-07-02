using Bloomberglp.Blpapi;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    public static class Extensions
    {

        public static void SetIfNotNullOrEmpty(this Request request, Name field, string? value)
        {

            if (!string.IsNullOrEmpty(value))
                request.Set(field, value);
        }
        public static void SetIfNotNull(this Request request, Name field, TimeSpan? value, string format)
        {

            if (value != null)
                request.Set(field, value?.ToString(format));
        }
        public static void SetIfNotNull(this Request request, Name field, DateTime? value, string format)
        {

            if (value != null)
                request.Set(field, value?.ToString(format));
        }
        public static void SetIfNotNull(this Request request, Name field, double? value)
        {

            if (value != null)
                request.Set(field, value.Value);
        }
        public static void SetIfNotNull(this Request request, Name field, int? value)
        {

            if (value != null)
                request.Set(field, value.Value);
        }

        public static void SetIfNotNull(this Request request, Name field, float? value)
        {

            if (value != null)
                request.Set(field, value.Value);
        }

        public static void SetIfNotNull(this Request request, Name field, long? value)
        {

            if (value != null)
                request.Set(field, value.Value);
        }
    }
}
