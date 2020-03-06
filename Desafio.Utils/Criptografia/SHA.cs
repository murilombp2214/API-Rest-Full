using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Desafio.Utils.Criptografia
{
    public static class SHA
    {
        public static string HashSHA256(string value)
        {
            using (SHA512 objSha = SHA512.Create())
            {
                byte[] bytes = objSha.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder Retorno = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    Retorno.Append(bytes[i].ToString());
                return Retorno.ToString().ToUpper();
            }


        }
    }
}
