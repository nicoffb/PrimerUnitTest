using NUnit.Framework;
using Calculadora;

namespace Calculadora.Tests
{
    [TestFixture]
    public class CalculadoraTests
    {
        [Test]
        public void Sumar_DosNumerosPositivos_RetornaLaSuma()
        {
            // Arrange (Preparar)
            var calculadora = new Calculadora();
            int primerNumero = 5;
            int segundoNumero = 3;
            int resultadoEsperado = 8;

            // Act (Actuar)
            int resultadoActual = calculadora.Sumar(primerNumero, segundoNumero);

            // Assert (Afirmar)
            Assert.That(resultadoActual, Is.EqualTo(resultadoEsperado));
        }
        [Test]
        public void Sumar_Ceros_RetornaCero()
        {
            // Arrange
            var calculadora = new Calculadora();
            int a = 0;
            int b = 0;
            int esperado = 0;

            // Act
            int actual = calculadora.Sumar(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(esperado));
        }

        [Test]
        public void Restar_DosNumeros_RetornaLaRestaCorrecta()
        {
            // Arrange
            var calculadora = new Calculadora();
            int minuendo = 10;
            int sustraendo = 4;
            int esperado = 6;

            // Act
            int actual = calculadora.Restar(minuendo, sustraendo);

            // Assert
            Assert.That(actual, Is.EqualTo(esperado));
        }

        [Test]
        public void Multiplicar_DosNumeros_RetornaElProductoCorrecto()
        {
            // Arrange
            var calculadora = new Calculadora();
            int a = 7;
            int b = 6;
            int esperado = 42;

            // Act
            int actual = calculadora.Multiplicar(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(esperado));
        }

        [Test]
        public void Dividir_DosNumeros_RetornaElCocienteCorrecto()
        {
            // Arrange
            var calculadora = new Calculadora();
            int dividendo = 20;
            int divisor = 5;
            int esperado = 4;

            // Act
            int actual = calculadora.Dividir(dividendo, divisor);

            // Assert
            Assert.That(actual, Is.EqualTo(esperado));
        }

        [Test]
        public void Dividir_PorCero_LanzaArgumentExceptionConParametroB()
        {
            // Arrange
            var calculadora = new Calculadora();
            int dividendo = 10;
            int divisor = 0;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => calculadora.Dividir(dividendo, divisor));
            Assert.That(ex.ParamName, Is.EqualTo("b"));
        }
    }
}