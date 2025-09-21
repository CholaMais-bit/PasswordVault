namespace PasswordVault.Exceptions
{
    // Exceção para senha de sessão errada
    public class SessionPasswordWrongException : Exception
    {
        public SessionPasswordWrongException() { }

        public SessionPasswordWrongException(string message) : base(message) { }

        public SessionPasswordWrongException(string message, Exception ex)
         : base(message, ex) { }
    }
}
