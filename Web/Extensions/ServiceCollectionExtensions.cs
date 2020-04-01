using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Linq;

namespace ContactManagement.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {


        public static MvcOptions AddCustomInputFormatters(this MvcOptions options)
        {
            var xmlInputFormatter = new XmlDataContractSerializerInputFormatter(options);
            options.InputFormatters.Add(xmlInputFormatter);

            return options;
        }

        public static MvcOptions AddCustomOutputFormatters<TJsonOutputFormatter>(this MvcOptions options) where TJsonOutputFormatter : OutputFormatter
        {
            var xmlOutputFormatter = new XmlDataContractSerializerOutputFormatter();
            options.OutputFormatters.Add(xmlOutputFormatter);
            var jsonOutputFormatter = options.OutputFormatters
                                             .OfType<TJsonOutputFormatter>()
                                             .First();
            var customMediaType = new string[] { };
            customMediaType.Execute(e => jsonOutputFormatter.SupportedMediaTypes.Add(e));
            return options;
        }

    }

}
