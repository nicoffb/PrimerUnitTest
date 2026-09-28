namespace Calculadora
{
    public class Calculadora
    {
        /// <summary>
        /// Suma dos números enteros
        /// </summary>
        /// <param name="a">Primer número</param>
        /// <param name="b">Segundo número</param>
        /// <returns>La suma de a y b</returns>
        public int Sumar(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Resta dos números enteros
        /// </summary>
        /// <param name="a">Minuendo</param>
        /// <param name="b">Sustraendo</param>
        /// <returns>La resta de a - b</returns>
        public int Restar(int a, int b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplica dos números enteros
        /// </summary>
        /// <param name="a">Primer número</param>
        /// <param name="b">Segundo número</param>
        /// <returns>El producto de a * b</returns>
        public int Multiplicar(int a, int b)
        {
            return a * b;
        }

        /// <summary>
        /// Divide dos números enteros
        /// </summary>
        /// <param name="a">Dividendo</param>
        /// <param name="b">Divisor</param>
        /// <returns>El resultado de a / b</returns>
        /// <exception cref="ArgumentException">Se lanza si b es 0</exception>
        public int Dividir(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException("No se puede dividir entre cero", nameof(b));

            return a / b;
        }
    }
}