using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Modelos
{
    public class Encrypt
    {
        public string Encriptar(string mensaje)
        {
            string hash = "encriptar contra";
            byte[] data = UTF8Encoding.UTF8.GetBytes(mensaje);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key= md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode= CipherMode.ECB;

            ICryptoTransform tranform = tripledes.CreateEncryptor();
            byte[] result= tranform.TransformFinalBlock(data, 0 , data.Length);

            return Convert.ToBase64String(result);
        }

        public string desencriptar(string mensajeEn)
        {
            string hash = "encriptar contra";
            byte[] data = Convert.FromBase64String(mensajeEn);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform tranform = tripledes.CreateDecryptor();
            byte[] result = tranform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }
    }
}
