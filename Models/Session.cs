namespace PasswordVault.Models
{
    // Contém a senha do usuário para acessar os cofres
    public class Session
    {
        public static string PasswordHash { get; private set; } = "";

        // Inicializa os valores
        public Session(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Retorna a senha criptografada
        public static string GetPasswordHash()
        {
            return PasswordHash;
        }
    }
}
