using System.Collections.Specialized;
using System.Web;

namespace Sequoia.Client.Http.Configuration
{
    public class Query
    {
        public string QueryString { get; set; }

        protected internal void SetQueryParams(object queryParams)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            if (queryParams.GetType() == typeof(string))
            {
                QueryString = (string)queryParams;
            }

            // query parameters
            if (queryParams != null)
            {
                if (queryParams is NameValueCollection)
                {
                    var query = queryParams as NameValueCollection;
                    var keyValuePair = query.AllKeys.SelectMany(query.GetValues, (key, value) => new 
                    { 
                        key = key, 
                        value = value 
                    });

                    foreach (var pair in keyValuePair)
                        if (pair.value != null)
                            queryString.Add(pair.key, pair.value);

                    return;
                }

                foreach (var property in queryParams.GetType().GetProperties())
                {
                    var propertyValue = property.GetValue(queryParams, null);
                    if (propertyValue == null)
                        continue;
                    queryString.Add(property.Name, property.GetValue(queryParams).ToString());
                }
            }

            QueryString = "?" + queryString.ToString();
        }
    }
}
