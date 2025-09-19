using PasswordVault.Models;

namespace PasswordVault.Utils
{
    // Helpers dos cofres
    public class VaultHelper
    {
        public static bool VerifyPlataformExists(string platform, List<Vault> vaults)
        {
            return vaults.Any(x => x.Platform.ToLower() == platform.ToLower());
        }
    }
}
