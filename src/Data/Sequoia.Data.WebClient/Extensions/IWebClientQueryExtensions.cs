﻿using Sequoia.Data.WebClient.Interfaces;
using System.Collections.Specialized;
using System.Web;

namespace Sequoia.Data.WebClient.Extensions
{
    public static class IWebClientQueryExtensions
    {
        /// <summary>
        /// Add params to query uri
        /// </summary>
        /// <param name="queryParams">Parameters object - new { key = value}</param>
        public static IWebClient WithQueryParams(this IWebClient webClient, object queryParams)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            // query parameters
            if (queryParams != null)
            {
                if (queryParams is NameValueCollection)
                {
                    var query = queryParams as NameValueCollection;

                    var keyValuePair = query.AllKeys.SelectMany(query.GetValues, (key, value) => new { key = key, value = value });

                    foreach (var pair in keyValuePair)
                        if (pair.value != null)
                            queryString.Add(pair.key, pair.value);

                    return webClient;
                }

                foreach (var property in queryParams.GetType().GetProperties())
                {
                    var propertyValue = property.GetValue(queryParams, null);
                    if (propertyValue == null)
                        continue;
                    queryString.Add(property.Name, property.GetValue(queryParams).ToString());
                }
            }

            webClient.Configuration.QueryString = "?" + queryString.ToString();

            return webClient;
        }

        /// <summary>
        /// Add params string to query uri
        /// </summary>
        /// <param name="queryParamsString">Query params. Start with '?', like ?key=value</param>
        public static IWebClient WithQueryParams(this IWebClient webClient, string queryParamsString)
        {
            webClient.Configuration.QueryString = queryParamsString;

            return webClient;
        }

        /// <summary>
        /// Add header to request
        /// </summary>
        public static IWebClient WithHeader(this IWebClient webClient, string headerKey, string headerValue)
        {
            webClient.HttpClient.DefaultRequestHeaders.Add(headerKey, headerValue);

            return webClient;
        }
    }
}
