using HIClaims.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Reflection;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HIClaims.BL
{
    public class CustomerClaim
    {
        public List<Claim> GetClaims()
        {
            string result = string.Empty;
           List<Claim> claims = new List<Claim>();
            var path="~/bin/Resources/ClaimData.json";

            var resourcePath = HttpContext.Current.Server.MapPath(@path);
            using (StreamReader reader = new StreamReader(resourcePath))
            {
                result = reader.ReadToEnd();
            }
            claims = JsonConvert.DeserializeObject<List<Claim>>(result);
            return claims;
        }

        public bool SaveClaims( Claim claim)
        {
            bool returnValue = false;
            var excp_Msg="Err_msg Place holder";
            try
            {
                
                //var resourcePath = HttpRuntime.AppDomainAppPath + "/bin/Resources/ClaimData.json";
                var resourcePath = HttpContext.Current.Server.MapPath(@"~/bin/Resources/ClaimData.json");

                var claims = GetClaims();
                claims.Add(claim);
                var result = JsonConvert.SerializeObject(claims);
                System.IO.File.WriteAllText(resourcePath, result);
                returnValue = true;
            }catch(Exception e)
            {
                returnValue = false;
                excp_Msg=e.Message;
                throw;
            }
            return returnValue;

        }

    }
}