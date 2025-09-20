namespace PasswordVault.Exceptions
{
    // Exceção para quando uma plataforma não está registrada
    public class PlatformIsNotRegisteredException : Exception
    {
        public PlatformIsNotRegisteredException() { }

        public PlatformIsNotRegisteredException(string message) : base(message) { }

        public PlatformIsNotRegisteredException(string message, Exception ex)
            : base(message, ex) { }
    }
}
