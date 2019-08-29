using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace apifinansys.Middlewares
{
    public class StoreUserDataMiddleware
    {
        private readonly RequestDelegate _next;

        public StoreUserDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context, IHeaderEvent headerEvent)
        {
            try
            {
                string token = string.Empty;
                headerEvent.Token = context.Request.Headers["Authorization"];

                if (!string.IsNullOrEmpty(headerEvent.Token))
                {
                    var arrBearerToken = headerEvent.Token.Split("Bearer");
                    token = arrBearerToken[1].Trim();

                    string[] parts = token.Split('.');
                    string header = parts[0];
                    string payload = parts[1];
                    byte[] crypto = Base64UrlDecode(parts[2]);

                    string headerJson = Encoding.UTF8.GetString(Base64UrlDecode(header));
                    JObject headerData = JObject.Parse(headerJson);

                    string payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));
                    JObject payloadData = JObject.Parse(payloadJson);

                    var key = "worldisfullofdevelopers";
                    var keyBytes = Encoding.UTF8.GetBytes(key); // your key here

                    //var computedJwtSignature = Encoding.UTF8.GetString(HashAlgorithms[GetHashAlgorithm(algorithm)](keyBytes, bytesToSign));
                    // var decodedCrypto = Convert.ToBase64String(crypto);
                    // var decodedSignature = Convert.ToBase64String(signature);

                    //if (jwtSignature != computedJwtSignature)
                    //{
                    //    throw new ApplicationException(string.Format("Invalid signature. Expected {0} got {1}", decodedCrypto, decodedSignature));
                    //}


                }





                if (headerEvent.Token != null)
                    if (headerEvent.Token.Contains("Bearer"))
                    {
                        await context.Response.WriteAsync("Not Autorized!");
                        return;
                    }

            }
            catch (Exception)
            {
                throw;
            }

            await _next(context);
        }


        static byte[] Base64UrlDecode(string arg)
        {
            string s = arg;
            s = s.Replace('-', '+'); // 62nd char of encoding
            s = s.Replace('_', '/'); // 63rd char of encoding
            switch (s.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: s += "=="; break; // Two pad chars
                case 3: s += "="; break; // One pad char
                default:
                    throw new System.Exception(
             "Illegal base64url string!");
            }
            return Convert.FromBase64String(s); // Standard base64 decoder
        }

    }
}
