using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http.Headers;

namespace Microsoft.Exchange.WebServices.Data
{
    class HttpHeadersToWebHeaderCollection
    {
        public static WebHeaderCollection Convert(HttpHeaders headers)
        {
            WebHeaderCollection webHeaders = new WebHeaderCollection();
            foreach (KeyValuePair<string, IEnumerable<String>> header in headers)
            {
                string values = "";
                foreach (string value in header.Value)
                {
                    values += ((values.Length == 0) ? "" : ",") + value;
                }
                webHeaders[header.Key] = values;
            }
            return webHeaders;
        }
    }
}
