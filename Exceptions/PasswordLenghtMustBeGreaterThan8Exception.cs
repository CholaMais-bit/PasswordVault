namespace PasswordVault.Exceptions
{
    // Classe para exceções de plataforma já existente
    public class PasswordLengthMustBeGreaterThan8Exception : Exception
    {
        public PasswordLengthMustBeGreaterThan8Exception() { }

        public PasswordLengthMustBeGreaterThan8Exception(string message) : base(message) { }

        public PasswordLengthMustBeGreaterThan8Exception(string message, Exception ex)
            : base(message, ex) { }
    }
}
