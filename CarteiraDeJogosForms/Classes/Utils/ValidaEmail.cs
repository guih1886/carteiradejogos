using System.Text.RegularExpressions;

namespace CarteiraDeJogosForms.Classes.Utils;

public static class ValidaEmail
{
    public static bool ValidarEmail(string email)
    {
        string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
    }
}
