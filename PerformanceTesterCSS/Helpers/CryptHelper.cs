using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceTesterCSS.Helpers
{
    public class CryptHelper
    {
        public static Boolean CheckPassword(String pass, String hash)
        {
            String altHash = "$2a" + hash.Substring(3);
            return BCrypt.Net.BCrypt.Verify(pass, altHash);
        }
        public static String HashPassowrd(String pass)
        {
            return BCrypt.Net.BCrypt.HashPassword(pass);
        }
    }
}
