using Bloomberglp.Blpapi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Parsers
{
    internal static class Extensions
    {
        public static DateTime GetAsDateTimeUtc(this Element element, string fieldName)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(element.GetElementAsString(fieldName), CultureInfo.InvariantCulture);
            return dateTimeOffset.UtcDateTime;
        }

        public static string? NullIfEmpty(this string input)
        {
            return string.IsNullOrEmpty(input.Trim()) ? null : input;
        }

        public static int? NullIfZero(this int input)
        {
            return input==0 ? null : input;
        }

        public static double? NullIfZero(this double input)
        {
            return input == 0 ? null : input;
        }
    }

}
