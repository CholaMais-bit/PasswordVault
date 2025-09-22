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
            Random rand = new Random();
            char[] password = new char[size];

            for (int i = 0; i < size; i++)
            {
                password[i] = allChars[(rand.Next(allChars.Length))];
            }

            return new string(password);
        }
    }
}
