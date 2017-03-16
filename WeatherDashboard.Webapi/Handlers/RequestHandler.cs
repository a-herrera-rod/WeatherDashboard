using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http.ModelBinding;

namespace WeatherDashboard.Webapi.Handlers
{
    public static class RequestHandler
    {
        private const string validUser = "my_user";
        private const string validPass = "my_password";

        public static void Validate(ModelStateDictionary modelState, AuthenticationHeaderValue header, bool notFound)
        {
            if (!modelState.IsValid)
            {
                throw new HttpException(HttpStatusCode.BadRequest.GetHashCode(), "Bad request");
            }
            else if (notFound)
            {
                throw new HttpException(HttpStatusCode.NotFound.GetHashCode(), "Record not found");
            }
            else
            {
                if (header == null || header.Parameter == null)
                {
                    throw new HttpException(HttpStatusCode.Unauthorized.GetHashCode(), "Not authorized");
                }
                else
                {
                    var headerCredentials = header.Parameter;
                    string username = headerCredentials.Split(':')[0];
                    string password = headerCredentials.Split(':')[1];
                    if (!StringComparer.OrdinalIgnoreCase.Equals(header.Scheme, "basic") || !StringComparer.OrdinalIgnoreCase.Equals(username, validUser) || !StringComparer.Ordinal.Equals(password, validPass))
                    {
                        throw new HttpException(HttpStatusCode.Unauthorized.GetHashCode(), "Not authorized");
                    }
                }
            }
        }
    }
}