using Microsoft.AspNetCore.WebUtilities;

namespace GhasedakSms.Core
{
    public class Helper
    {
        public static string BuildQueryString(string baseUrl, Dictionary<string, string> queryParams, string arrayKey = null, List<string> arrayValues = null)
        {
            var queryString = QueryHelpers.AddQueryString(baseUrl, queryParams);
            if (arrayKey != null && arrayValues != null)
            {
                //arrayValues.Select(value => queryString = QueryHelpers.AddQueryString(queryString, arrayKey, value));
                foreach (var value in arrayValues)
                {
                    queryString = QueryHelpers.AddQueryString(queryString, arrayKey, value);
                }
            }
            return queryString;
        }

    }
}
