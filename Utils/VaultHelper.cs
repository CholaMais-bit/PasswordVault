using PasswordVault.Models;

namespace PasswordVault.Utils
{
    // Helpers dos cofres
    public class VaultHelper
    {
        public static bool VerifyPlataformExists(string platform, List<Vault> vaults)
        {
            Vault? vault = vaults.FirstOrDefault(x => x.Platform == platform);

            return string.Equals(platform, vault);
        }
    }
}
