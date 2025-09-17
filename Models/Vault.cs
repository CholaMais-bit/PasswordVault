namespace PasswordVault.Models
{
    // Conjunto de informações para a senha do usuário
    public class Vault
    {
        public string Site { get; private set; } = "";
        public string Password { get; private set; } = "";
        public DateTime DateOfCreation { get; private set; } = default;
        public DateTime DateOfLastChange { get; private set; } = default;

        // Inicializar os valores do objeto
        public Vault(string site, string password)
        {
            Site = site;
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
