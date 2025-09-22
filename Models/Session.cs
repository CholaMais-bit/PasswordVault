using System.Text.Json.Serialization;
using PasswordVault.Exceptions;

namespace PasswordVault.Models
{
    // Contém a senha do usuário para acessar os cofres
    public class Session
    {
        public static string PasswordHash { get; private set; } = "";

        // Inicializa os valores
        public Session(string password)
        {
            if (PasswordHash != "")
            {
                throw new SessionPasswordAlreadyExistsException("A password already exists");
            }

            if (password.Length < 8)
            {
                throw new PasswordLengthMustBeGreaterThan8Exception(
                    "Password length must be greater than 8 char"
                );
            }

            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Retorna a senha criptografada
        public static string GetPasswordHash()
        {
            return PasswordHash;
        }

        // Método para carregar a senha do json
        public static void LoadPasswordFromJson(string password)
        {
            if (password != null)
            {
                PasswordHash = password;
            }
        }

        // Método para mudar a senha mestra
        public static void ChangePassword(string newPassword)
        {
            if (newPassword.Length < 8)
            {
                throw new PasswordLengthMustBeGreaterThan8Exception(
                    "Password length must be greater than 8 char"
                );
            }

            PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        }

        // Verifica se a senha da sessão está certa
        public static bool VerifyPasswordSession(string password)
        {
            if (!BCrypt.Net.BCrypt.Verify(password, Session.GetPasswordHash()))
            {
                throw new SessionPasswordWrongException("The session password is wrong");
            }

            return true;
        }
    }
}
