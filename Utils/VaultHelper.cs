using PasswordVault.Exceptions;
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

        // Verifica se a plataforma existe
        public static Vault FindVaultOrThrow(string platform, List<Vault> vaults)
        {
            Vault? vault = vaults.FirstOrDefault(x => x.Platform.ToLower() == platform.ToLower());

            if (vault == null)
            {
                throw new PlatformIsNotRegisteredException("This platform is not registered");
            }

            return vault;
        }
    }
}
