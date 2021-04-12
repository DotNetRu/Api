﻿using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;

namespace DotNetRu.Server.SpaClient
{
    public class BalzorHttpMessageHandlerFactory
    {
        public static HttpMessageHandler CreateDefault()
        {
            return CreateDefault(null);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "proxy")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static HttpMessageHandler CreateDefault(IWebProxy? proxy)
        {
            var handler = new HttpClientHandler();

            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }

            if (handler.SupportsProxy && proxy != null)
            {
                handler.UseProxy = true;
                handler.Proxy = proxy;
            }

            return handler;
        }
    }
}