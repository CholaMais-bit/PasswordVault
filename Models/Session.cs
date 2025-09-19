using System.Text.Json.Serialization;

namespace PasswordVault.Models
{
    // Contém a senha do usuário para acessar os cofres
    public class Session
    {
        public static string PasswordHash { get; set; } = "";

        // Inicializa os valores
        public Session(string password)
        {
            if (password.Contains("\\"))
            {
                throw new Exception("User input cannot contain: \\");
            }

            if (PasswordHash != "")
            {
                throw new Exception("A password already exists");
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
