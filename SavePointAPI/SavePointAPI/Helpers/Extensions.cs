using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointApp.Helpers
{
    // Make static so it can only be accessed by this class

    public static class Extensions
    {
        // Create a custom HTTP response message
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            // Add a header for the custom HTTP response message
            response.Headers.Add("Application-Error", message);

            // Add header to make custom header available to the browser
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");

            // Allow any origin to access this message
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
