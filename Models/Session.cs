using System.Text.Json.Serialization;
using PasswordVault.Exceptions;

namespace PasswordVault.Models
{
    // Contém a senha do usuário para acessar os cofres
    public class Session
    {
        public static string PasswordHash { get; set; } = "";

        // Inicializa os valores
        public Session(string password)
        {
            char[] forbiddenChars = { '"', '\\', '/', '\b', '\f', '\n', '\r', '\t' };

            if (password.IndexOfAny(forbiddenChars) >= 0)
            {
                throw new ForbiddenCharsException("User input cannot contain: \\");
            }

            if (PasswordHash != "")
            {
                throw new SessionPasswordAlreadyExistsException("A password already exists");
            }

            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Retorna a senha criptografada
        public static string GetPasswordHash()
        {
            return PasswordHash;
        }
    }
}
