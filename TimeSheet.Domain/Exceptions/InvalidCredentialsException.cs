namespace TimeSheet.Domain.Exceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException() : base("Usuario ou senha invalidos.") { }
}
