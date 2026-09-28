using NUnit.Framework;
using Calculadora;

namespace Calculadora.Tests
{
    [TestFixture]
    public class ValidadorDatos_BuenaCobertura
    {
        private ValidadorDatos validador;

        [SetUp]
        public void Setup()
        {
            validador = new ValidadorDatos();
        }

        // ========== Tests de Email ==========

        [Test]
        public void EsEmailValido_ConEmailValido_RetornaTrue()
        {
            // ✅ BUENO: Verifica el caso positivo explícitamente
            var resultado = validador.EsEmailValido("usuario@example.com");
            Assert.That(resultado, Is.True, "Un email válido debería retornar True");
        }

        [Test]
        public void EsEmailValido_ConEmailNulo_RetornaFalse()
        {
            // ✅ BUENO: Prueba caso límite (null)
            var resultado = validador.EsEmailValido(null);
            Assert.That(resultado, Is.False, "Un email nulo debería retornar False");
        }

        [Test]
        public void EsEmailValido_ConEmailVacio_RetornaFalse()
        {
            // ✅ BUENO: Prueba caso límite (vacío)
            var resultado = validador.EsEmailValido("");
            Assert.That(resultado, Is.False, "Un email vacío debería retornar False");
        }

        [Test]
        public void EsEmailValido_ConEmailSoloEspacios_RetornaFalse()
        {
            // ✅ BUENO: Prueba caso de espacios en blanco
            var resultado = validador.EsEmailValido("   ");
            Assert.That(resultado, Is.False, "Un email con solo espacios debería retornar False");
        }

        [Test]
        public void EsEmailValido_ConEmailSinArroba_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito crítico (@ obligatorio)
            var resultado = validador.EsEmailValido("usuarioexample.com");
            Assert.That(resultado, Is.False, "Un email sin @ debería retornar False");
        }

        [Test]
        public void EsEmailValido_ConMultiplesArrobas_RetornaFalse()
        {
            // ✅ BUENO: Prueba caso límite (múltiples @)
            var resultado = validador.EsEmailValido("usuario@test@example.com");
            Assert.That(resultado, Is.False, "Un email con múltiples @ debería retornar False");
        }

        [Test]
        public void EsEmailValido_ConPartePrimeraVacia_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito (parte antes de @ no puede estar vacía)
            var resultado = validador.EsEmailValido("@example.com");
            Assert.That(resultado, Is.False, "Un email sin parte inicial debería retornar False");
        }

        [Test]
        public void EsEmailValido_ConParteSegundaVacia_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito (parte después de @ no puede estar vacía)
            var resultado = validador.EsEmailValido("usuario@");
            Assert.That(resultado, Is.False, "Un email sin dominio debería retornar False");
        }

        [Test]
        public void EsEmailValido_ConDominioSinPunto_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito crítico (dominio debe tener .)
            var resultado = validador.EsEmailValido("usuario@example");
            Assert.That(resultado, Is.False, "Un dominio sin punto debería retornar False");
        }

        // ========== Tests de Contraseña ==========

        [Test]
        public void EsContraseñaValida_ConContraseñaValida_RetornaTrue()
        {
            // ✅ BUENO: Cumple todos los requisitos
            var resultado = validador.EsContraseñaValida("MiPassword123");
            Assert.That(resultado, Is.True, "Una contraseña que cumple todos los requisitos debería ser válida");
        }

        [Test]
        public void EsContraseñaValida_ConContraseñaMuyCorta_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito de longitud mínima
            var resultado = validador.EsContraseñaValida("Pas1");
            Assert.That(resultado, Is.False, "Una contraseña muy corta debería ser inválida");
        }

        [Test]
        public void EsContraseñaValida_SinMayuscula_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito de mayúscula
            var resultado = validador.EsContraseñaValida("mipassword123");
            Assert.That(resultado, Is.False, "Una contraseña sin mayúscula debería ser inválida");
        }

        [Test]
        public void EsContraseñaValida_SinMinuscula_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito de minúscula
            var resultado = validador.EsContraseñaValida("MIPASSWORD123");
            Assert.That(resultado, Is.False, "Una contraseña sin minúscula debería ser inválida");
        }

        [Test]
        public void EsContraseñaValida_SinNumero_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito de número
            var resultado = validador.EsContraseñaValida("MiPassword");
            Assert.That(resultado, Is.False, "Una contraseña sin número debería ser inválida");
        }

        [Test]
        public void EsContraseñaValida_ConNulo_RetornaFalse()
        {
            // ✅ BUENO: Prueba caso límite
            var resultado = validador.EsContraseñaValida(null);
            Assert.That(resultado, Is.False, "Una contraseña nula debería ser inválida");
        }

        // ========== Tests de Teléfono ==========

        [Test]
        public void EsTelefonoValido_ConTelefonoValido_RetornaTrue()
        {
            // ✅ BUENO: Prueba formato simple válido
            var resultado = validador.EsTelefonoValido("123456789");
            Assert.That(resultado, Is.True, "Un teléfono válido debería retornar True");
        }

        [Test]
        public void EsTelefonoValido_ConTelefonoFormato_RetornaTrue()
        {
            // ✅ BUENO: Prueba formato con guiones
            var resultado = validador.EsTelefonoValido("+34-123-456-789");
            Assert.That(resultado, Is.True, "Un teléfono con formato válido debería retornar True");
        }

        [Test]
        public void EsTelefonoValido_ConTelefonoTooShort_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito de longitud mínima
            var resultado = validador.EsTelefonoValido("12345");
            Assert.That(resultado, Is.False, "Un teléfono muy corto debería ser inválido");
        }

        [Test]
        public void EsTelefonoValido_ConTelefonoTooLong_RetornaFalse()
        {
            // ✅ BUENO: Prueba requisito de longitud máxima
            var resultado = validador.EsTelefonoValido("123456789012345678");
            Assert.That(resultado, Is.False, "Un teléfono muy largo debería ser inválido");
        }

        [Test]
        public void EsTelefonoValido_ConTelefonoVacio_RetornaFalse()
        {
            // ✅ BUENO: Prueba caso límite
            var resultado = validador.EsTelefonoValido("");
            Assert.That(resultado, Is.False, "Un teléfono vacío debería ser inválido");
        }

        // ========== Tests de Número Positivo ==========

        [Test]
        public void EsPositivo_ConNumeroPositivo_RetornaTrue()
        {
            // ✅ BUENO: Prueba el caso positivo
            var resultado = validador.EsPositivo(5);
            Assert.That(resultado, Is.True, "Un número positivo debería retornar True");
        }

        [Test]
        public void EsPositivo_ConNumeroCero_RetornaFalse()
        {
            // ✅ BUENO: Prueba caso límite (cero no es positivo)
            var resultado = validador.EsPositivo(0);
            Assert.That(resultado, Is.False, "El número cero debería retornar False");
        }

        [Test]
        public void EsPositivo_ConNumeroNegativo_RetornaFalse()
        {
            // ✅ BUENO: Prueba el caso negativo
            var resultado = validador.EsPositivo(-5);
            Assert.That(resultado, Is.False, "Un número negativo debería retornar False");
        }
    }
}