using System.Text.Json.Serialization;
using PasswordVault.Exceptions;

namespace PasswordVault.Models
{
    // Conjunto de informações para a senha do usuário
    public class Vault
    {
        public string Platform { get; private set; } = "";
        public string Password { get; private set; } = "";
        public DateTime DateOfCreation { get; private set; }
        public DateTime DateOfLastChange { get; private set; }

        // Construtor para deserializar o json
        [JsonConstructor]
        public Vault(
            string platform,
            string password,
            DateTime dateOfCreation,
            DateTime dateOfLastChange
        )
        {
            Platform = platform;
            Password = password;
            DateOfCreation = dateOfCreation;
            DateOfLastChange = dateOfLastChange;
        }

        // Inicializar os valores do objeto
        public Vault(string platform, string password)
        {
            if (password.Length < 8)
            {
                throw new PasswordLengthMustBeGreaterThan8Exception(
                    "Password length must be greater than 8 char"
                );
            }

            Platform = platform;
            Password = password;
            DateOfCreation = DateTime.Now;
            DateOfLastChange = DateTime.Now;
        }

        // Alterar a senha
        public void ChangePassword(string password)
        {
            if (password.Length < 8)
            {
                throw new PasswordLengthMustBeGreaterThan8Exception(
                    "Password length must be greater than 8 char"
                );
            }
            
            Password = password;
            DateOfLastChange = DateTime.Now;
        }
    }
}
