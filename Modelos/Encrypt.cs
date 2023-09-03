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
        public string Encriptar(string claveSinEncriptar)
        {
            // Se crea un objeto de tipo SHA256, un algoritmo de Encriptación de información
            SHA256 s = SHA256.Create();

            // Se convierte la cadena de caracteres 'claveSinEncriptar' en un arreglo de bytes utilizando UTF-8 encoding
            byte[] bytes = s.ComputeHash(Encoding.UTF8.GetBytes(claveSinEncriptar));

            // Se crea un StringBuilder para construir la representación en cadena hexadecimal del hash
            StringBuilder sb = new StringBuilder();

            // Se recorre cada byte en el arreglo 'bytes'
            for (int i = 0; i < bytes.Length; i++)
            {
                // Se convierte el byte actual en una cadena hexadecimal de longitud 2 (x2) y se agrega al StringBuilder
                sb.Append(bytes[i].ToString("x2"));
            }

            // Se devuelve la representación hexadecimal del hash como una cadena de caracteres
            return sb.ToString();
        }

    }
}
