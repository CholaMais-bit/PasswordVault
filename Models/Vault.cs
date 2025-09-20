using System.Text.Json.Serialization;
using PasswordVault.Exceptions;

namespace PasswordVault.Models
{
    // Conjunto de informações para a senha do usuário
    public class Vault
    {
        public string Platform { get; private set; } = "";
        public string Password { get; private set; } = "";
        public DateTime DateOfCreation { get; private set; } = default;
        public DateTime DateOfLastChange { get; private set; } = default;

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
            Platform = platform;
            Password = password;
            DateOfCreation = DateTime.Now;
        }

        // Alterar a senha
        public void ChangePassword(string password)
        {
            Password = password;
            DateOfLastChange = DateTime.Now;
        }
    }
}
