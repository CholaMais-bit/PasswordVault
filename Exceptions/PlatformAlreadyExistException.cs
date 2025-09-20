namespace PasswordVault.Exceptions
{
    // Classe para exceções de plataforma já existente
    public class PlatformAlreadyExistException : Exception
    {
        public PlatformAlreadyExistException() { }

        public PlatformAlreadyExistException(string message) : base(message) { }

        public PlatformAlreadyExistException(string message, Exception ex)
            : base(message, ex) { }
    }
}
