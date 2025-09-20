using PasswordVault.Exceptions;
using PasswordVault.Models;

namespace PasswordVault.Utils
{
    // Classe para utilitários de sessão
    public class SessionHelper
    {
        // Verifica se a senha da sessão está certa
        public static void VerifyPasswordSession(string password)
        {
            if (!BCrypt.Net.BCrypt.Verify(password, Session.GetPasswordHash()))
            {
                throw new SessionPasswordWrongException("The session password is wrong");
            }
        }
    }
}
