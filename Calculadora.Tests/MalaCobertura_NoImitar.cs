using NUnit.Framework;
using Calculadora;

namespace Calculadora.Tests
{
    [TestFixture]
    public class ValidadorDatos_MalaCobertura
    {
        private ValidadorDatos validador;

        [SetUp]
        public void Setup()
        {
            validador = new ValidadorDatos();
        }

        // ❌ MALA PRÁCTICA: Tests triviales que solo "ejecutan" el código
        // sin verificar realmente el comportamiento

        [Test]
        public void EsEmailValido_ConEmail_ReturnsBoolean()
        {
            // ❌ MALO: Solo verifica que devuelve algo, sin validar qué devuelve
            var resultado = validador.EsEmailValido("test@example.com");
            Assert.That(resultado, Is.TypeOf<bool>());
        }

        [Test]
        public void EsContraseñaValida_ConString_ReturnsBoolean()
        {
            // ❌ MALO: Solo verifica el tipo de retorno
            var resultado = validador.EsContraseñaValida("Password123");
            Assert.That(resultado, Is.TypeOf<bool>());
        }

        [Test]
        public void EsTelefonoValido_ConNumero_ReturnsBoolean()
        {
            // ❌ MALO: Ni siquiera valida el resultado
            validador.EsTelefonoValido("123456789");
            // Sin Assert, este test "pasa" sin verificar nada
        }

        [Test]
        public void EsPositivo_ConNumero_NoLanzaExcepcion()
        {
            // ❌ MALO: Solo verifica que no falla, no que funcione correctamente
            Assert.DoesNotThrow(() => validador.EsPositivo(5));
        }
    }
}