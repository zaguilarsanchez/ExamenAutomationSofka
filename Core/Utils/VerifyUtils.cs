using Xunit;
using System;

namespace ExamenAutomationSofka.Core.Utils
{
    public static class VerifyUtils
    {
        // Compara dos textos y lanza un error personalizado si fallan
        public static void ToEqual(string actual, string expected, string message)
        {
            Assert.True(actual.Equals(expected), $"{message}. Esperado: {expected}, pero se obtuvo: {actual}");
        }

        // Verifica si un elemento o condición es verdadera
        public static void IsTrue(bool condition, string message)
        {
            Assert.True(condition, message);
        }

        // Verifica si un texto contiene a otro (muy útil para mensajes de éxito)
        public static void Contains(string actual, string expectedPart, string message)
        {
            Assert.Contains(expectedPart, actual);
        }
    }
}