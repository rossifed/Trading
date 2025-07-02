using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public static class RequestExtension
    {

        public static void SetIfNotNullOrEmpty(this Request request, string field, string? value)
        {

            if (!string.IsNullOrEmpty(value))
                request.Set(field, value);
        }
        public static void SetIfNotNull(this Request request, string field, TimeSpan? value, string format)
        {

            if (value != null)
                request.Set(field, value?.ToString(format));
        }
        public static void SetIfNotNull(this Request request, string field, DateTime? value, string format)
        {

            if (value != null)
                request.Set(field, value?.ToString(format));
        }
        public static void SetIfNotNull(this Request request, string field, double? value)
        {

            if (value != null)
                request.Set(field, value.Value);
        }
        public static void SetIfNotNull(this Request request, string field, int? value)
        {

            if (value != null)
                request.Set(field, value.Value);
        }

        public static void SetIfNotNull(this Request request, string field, float? value)
        {

            if (value != null)
                request.Set(field, value.Value);
        }

        public static void SetIfNotNull(this Request request, string field, long? value)
        {

            if (value != null)
                request.Set(field, value.Value);
        }
    }
}
