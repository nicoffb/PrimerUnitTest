namespace Calculadora
{
    public class ValidadorDatos
    {
        /// <summary>
        /// Valida si un email tiene un formato correcto
        /// </summary>
        /// <param name="email">Email a validar</param>
        /// <returns>True si el email es válido, False en caso contrario</returns>
        public bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (!email.Contains("@"))
                return false;

            string[] partes = email.Split("@");
            if (partes.Length != 2)
                return false;

            string parte1 = partes[0];
            string parte2 = partes[1];

            if (string.IsNullOrWhiteSpace(parte1) || string.IsNullOrWhiteSpace(parte2))
                return false;

            if (!parte2.Contains("."))
                return false;

            return true;
        }

        /// <summary>
        /// Valida si una contraseña cumple los requisitos mínimos de seguridad
        /// </summary>
        /// <param name="password">Contraseña a validar</param>
        /// <returns>True si la contraseña es válida, False en caso contrario</returns>
        public bool EsContraseñaValida(string password)
        {
            // Requisitos mínimos:
            // - Mínimo 8 caracteres
            // - Al menos una mayúscula
            // - Al menos una minúscula
            // - Al menos un número

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool tieneMayuscula = password.Any(char.IsUpper);
            bool tieneMinuscula = password.Any(char.IsLower);
            bool tieneNumero = password.Any(char.IsDigit);

            return tieneMayuscula && tieneMinuscula && tieneNumero;
        }

        /// <summary>
        /// Valida si un número de teléfono tiene un formato válido
        /// </summary>
        /// <param name="telefono">Número de teléfono a validar</param>
        /// <returns>True si el teléfono es válido, False en caso contrario</returns>
        public bool EsTelefonoValido(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            // Aceptar formatos: 123456789, +34-123-456-789, (123) 456-7890
            string soloNumeros = new string(telefono.Where(char.IsDigit).ToArray());

            return soloNumeros.Length >= 9 && soloNumeros.Length <= 15;
        }

        /// <summary>
        /// Valida si un número es positivo
        /// </summary>
        /// <param name="numero">Número a validar</param>
        /// <returns>True si el número es positivo, False en caso contrario</returns>
        public bool EsPositivo(int numero)
        {
            return numero > 0;
        }
    }
}