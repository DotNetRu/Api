using System;
using System.Linq;
using System.Text.RegularExpressions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DotNetRu.MeetupManagement.WebApi.Contract.Filters
{
    /// <summary>
    /// BasePath Document Filter sets BasePath property of Swagger and removes it from the individual URL paths
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public class BasePathFilter : IDocumentFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePathFilter"/> class.
        /// Constructor
        /// </summary>
        /// <param name="basePath">BasePath to remove from Operations</param>
        // ReSharper disable once UnusedMember.Global
        public BasePathFilter(string basePath)
        {
            BasePath = basePath;
        }

        /// <summary>
        /// Gets the BasePath of the Swagger Doc
        /// </summary>
        /// <returns>The BasePath of the Swagger Doc</returns>
        public string BasePath { get; }

        /// <summary>
        /// Apply the filter
        /// </summary>
        /// <param name="swaggerDoc">SwaggerDocument</param>
        /// <param name="context">FilterContext</param>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.BasePath = BasePath;

            var pathsToModify = swaggerDoc.Paths.Where(p => p.Key.StartsWith(BasePath, StringComparison.Ordinal)).ToList();

            foreach (var path in pathsToModify)
            {
                if (path.Key.StartsWith(BasePath, StringComparison.Ordinal))
                {
                    string newKey = Regex.Replace(path.Key, $"^{BasePath}", string.Empty);
                    swaggerDoc.Paths.Remove(path.Key);
                    swaggerDoc.Paths.Add(newKey, path.Value);
                }
            }
        }
    }
}
