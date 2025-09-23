using System.Security.Cryptography;
using PasswordVault.Utils;

namespace PasswordVault.Services
{
    // Serviços do gerador de senhas
    public class PasswordGenerator
    {
        // Caracteres suportados
        private static string allChars = "abcdefghijklmnopqrstuvwxyz" +   // minúsculas
                  "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +   // maiúsculas
                  "0123456789" +                   // números
                  "!@#$%^&*()-_=+[]{};:'\",.<>?/|"; // caracteres especiais

        // Gerar senha
        public static string GeneratePassword(int size)
        {
            char[] password = new char[size];
    
            for (int i = 0; i < size; i++)
            {
                int number = RandomNumberGenerator.GetInt32(0, allChars.Length);
                password[i] = allChars[number];
            }

            return new string(password);
        }
    }
}
