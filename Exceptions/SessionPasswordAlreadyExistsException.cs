namespace PasswordVault.Exceptions
{
    // Exceção de senha para acessar os cofres já existente
    public class SessionPasswordAlreadyExistsException : Exception
    {
        public SessionPasswordAlreadyExistsException() { }

        public SessionPasswordAlreadyExistsException(string message) : base(message) { }

        public SessionPasswordAlreadyExistsException(string message, Exception ex)
            : base(message, ex) { }
    }
}
