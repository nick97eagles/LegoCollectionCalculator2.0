using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegoCollectionCalculator2._0.Server.Helpers.OAuth;

internal static class WebUtils
{
    public static IEnumerable<WebParameter> ParseQueryString(Uri uri)
    {
        var parsedQuery = HttpUtility.ParseQueryString(uri.Query);

        var queryStringParameters = parsedQuery
            .AllKeys
            .SelectMany(parsedQuery.GetValues!, (key, value) => new { key, value });

        return queryStringParameters.Select(p => new WebParameter(p.key!, p.value!));
    }
}