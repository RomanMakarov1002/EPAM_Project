using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MvcPL.Infrastructure
{
    public static class HashForPassword
    {
        public static string GenerateHash(string password)
        {        
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] result = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(result);
        }   
    }
}