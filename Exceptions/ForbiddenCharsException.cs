namespace PasswordVault.Exceptions
{
    // Exceção de caracteres proibidos
    public class ForbiddenCharsException : Exception
    {
        public ForbiddenCharsException() { }

        public ForbiddenCharsException(string message) : base(message) { }

        public ForbiddenCharsException(string message, Exception ex)
            : base(message, ex) { }
    }
}
