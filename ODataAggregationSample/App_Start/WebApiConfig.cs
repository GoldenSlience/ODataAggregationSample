using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using ODataAggregationSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace ODataAggregationSample
{
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new ETagMessageHandler());
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }

        private static IEdmModel GetEdmModel() {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "ODataAggregationSample";
            builder.ContainerName = "DefaultContainer";

            builder.EntitySet<Person>("People");
            var edmModel = builder.GetEdmModel() as EdmModel;

            var totalAgeMethod = GetCustomMethods(typeof(Person), "TotalAge");

            CustomAggregateMethodAnnotation customMethods = new CustomAggregateMethodAnnotation();
            customMethods.AddMethod("People.TotalAge", totalAgeMethod);
            edmModel.SetAnnotationValue(edmModel, customMethods);
            
            return edmModel;
        }

        private static Dictionary<Type, MethodInfo> GetCustomMethods(Type customMethodsContainer, string methodName) { 
            return customMethodsContainer.GetMethods().Where(m => m.Name == methodName).Where(m => m.GetParameters().Count() == 1).ToDictionary(m => m.GetParameters().First().ParameterType.GetGenericArguments().First()); 
        }

}
}
