using System;
using System.Text;

namespace Cebulit.API.Services
{
    public static class ConfigProvider
    {
        public static byte[] GetTokenKey()
        {
            try
            {
                var key = Startup.StaticConfig["TokenKey"];
                if (string.IsNullOrWhiteSpace(key)) throw new Exception("Empty key");

                return Encoding.UTF8.GetBytes(key);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}