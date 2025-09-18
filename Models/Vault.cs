using System.Text.Json.Serialization;

namespace PasswordVault.Models
{
    // Conjunto de informações para a senha do usuário
    public class Vault
    {
        public string Plataform { get; private set; } = "";
        public string Password { get; private set; } = "";
        public DateTime DateOfCreation { get; private set; } = default;
        public DateTime DateOfLastChange { get; private set; } = default;

        // Construtor para deserializar o json
        [JsonConstructor]
        public Vault(
            string plataform,
            string password,
            DateTime dateOfCreation,
            DateTime dateOfLastChange
        )
        {
            Plataform = plataform;
            Password = password;
            DateOfCreation = dateOfCreation;
            DateOfLastChange = dateOfLastChange;
        }

        // Inicializar os valores do objeto
        public Vault(string site, string password)
        {
            Plataform = site;
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
