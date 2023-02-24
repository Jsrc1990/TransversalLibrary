using System.Text.RegularExpressions;

namespace TransversalLibrary
{
    /// <summary>
    /// Define las extensiones para las cadenas
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Valida si el valor contiene solo letras y espacios
        /// </summary>
        /// <param name="value">El valor</param>
        /// <returns>True si el valor contiene solo letras y espacios, False si no</returns>
        public static bool IsOnlyLettersAndSpaces(this string value)
        {
            // Patrón de expresión regular para validar solo letras y espacios
            string pattern = @"^[a-zA-Z\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        /// <summary>
        /// Valida si el valor contiene solo números
        /// </summary>
        /// <param name="value">El valor</param>
        /// <returns>True si el valor contiene solo números, False si no</returns>
        public static bool IsOnlyNumbers(this string value)
        {
            // Patrón de expresión regular para validar solo números
            string pattern = @"^\d+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        /// <summary>
        /// Valida si el email tiene el formato correcto
        /// </summary>
        /// <param name="email">El correo electrónico</param>
        /// <returns>True si el formato del email es correcto, False si no</returns>
        public static bool IsValidEmail(this string email)
        {
            // Patrón de expresión regular para direcciones de correo electrónico
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                             + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                             + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        /// <summary>
        /// Valida si la contraseña tiene el formato correcto
        /// </summary>
        /// <param name="password">La contraseña</param>
        /// <remarks>
        /// Al principio y al final de la cadena ^$
        /// Debe tener al menos una letra (?=.*[A-Za-z])
        /// Debe tener al menos un dígito (?=.*\d)
        /// Debe tener al menos un carácter especial (?=.*[$@$!%*#?&])
        /// Debe tener una longitud mínima de 8 caracteres {8,}
        /// </remarks>
        /// <returns>True si el formato de la contraseña es correcto, False si no</returns>
        public static bool ValidatePassword(this string password)
        {
            // Patrón de expresión regular para validar el formato de una contraseña
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }

        /// <summary>
        /// Reemplaza espacios consecutivos por un solo espacio
        /// </summary>
        /// <param name="value">El valor</param>
        /// <returns>La cadena con un solo espacio entre palabras</returns>
        public static string ReplaceMultipleSpacesAndTrim(this string value)
        {
            // Patrón de expresión regular para reemplazar múltiples espacios
            string pattern = @"^\s+|\s+$|\s+(?=\s)";
            Regex regex = new Regex(pattern);
            return regex.Replace(value, "");
        }
    }
}