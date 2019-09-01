using Calculadora;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        Operaciones Operacion;

        [SetUp]
        public void Setup()
        {
            Operacion = new Operaciones();
        }

        //Pruebas de Suma
        [Test]
        public void TestValidSumaNumerosEnterosPositivos()
        {
            Assert.AreEqual(4, Operacion.Suma(2, 2),"La suma ha fallado!");
        }

        [Test]
        public void TestValidSumaNumerosDecimalesPositivos()
        {
            Assert.AreEqual(10.5, Operacion.Suma(5.5,5), "La suma ha fallado!");
        }

        [Test]
        public void TestValidSumaNumerosEnterosNegativos()
        {
            Assert.AreEqual(-14, Operacion.Suma(-2, -12), "La suma ha fallado!");
        }

        [Test]
        public void TestValidSumaNumerosDecimalesNegativos()
        {
            Assert.AreEqual(-171.8, Operacion.Suma(-156.3, -15.5), "La suma ha fallado!");
        }

        [Test]
        public void TestValidSumaDeSuma()
        {
            Assert.AreEqual(23, Operacion.Suma(Operacion.Suma(9, 9), 5), "La suma ha fallado!");
        }

        //Pruebas de Resta
        [Test]
        public void TestValidRestaNumerosEnterosPositivos()
        {
            Assert.AreEqual(6, Operacion.Resta(10, 4), "La resta ha fallado!");
        }

        [Test]
        public void TestValidRestaNumerosDecimalesPositivos()
        {
            Assert.AreEqual(0.5, Operacion.Resta(5.5, 5), "La resta ha fallado!");
        }

        [Test]
        public void TestValidRestaNumerosEnterosNegativos()
        {
            Assert.AreEqual(10, Operacion.Resta(-2, -12), "La resta ha fallado!");
        }

        [Test]
        public void TestValidRestaNumerosDecimalesNegativos()
        {
            Assert.AreEqual(-140.8, Operacion.Resta(-156.3, -15.5), "La resta ha fallado!");
        }

        [Test]
        public void TestValidRestaDeResta()
        {
            Assert.AreEqual(-5, Operacion.Resta(Operacion.Resta(9, 9), 5), "La resta ha fallado!");
        }

        //Pruebas de Multiplicación
        [Test]
        public void TestValidMultiplicacionNumerosEnterosPositivos()
        {
            Assert.AreEqual(64, Operacion.Multiplicacion(8, 8), "La multiplicación ha fallado!");
        }

        [Test]
        public void TestValidMultiplicacionNumerosDecimalesPositivos()
        {
            Assert.AreEqual(27.5, Operacion.Multiplicacion(5.5, 5), "La multiplicación ha fallado!");
        }

        [Test]
        public void TestValidMultiplicacionNumerosEnterosNegativos()
        {
            Assert.AreEqual(24, Operacion.Multiplicacion(-2, -12), "La multiplicación ha fallado!");
        }

        [Test]
        public void TestValidMultiplicacionNumerosDecimalesNegativos()
        {
            Assert.AreEqual(2422.65, Operacion.Multiplicacion(-156.3, -15.5), "La multiplicación ha fallado!");
        }

        [Test]
        public void TestValidMultiplicacionDeMultiplicacion()
        {
            Assert.AreEqual(405, Operacion.Multiplicacion(Operacion.Multiplicacion(9, 9), 5), "La multiplicación ha fallado!");
        }
        //Pruebas de División
        [Test]
        public void TestValidDivisionNumerosEnterosPositivos()
        {
            Assert.AreEqual(9, Operacion.Division(81, 9), "La división ha fallado!");
        }

        [Test]
        public void TestValidDivisionNumerosDecimalesPositivos()
        {
            Assert.AreEqual(1.1, Operacion.Division(5.5, 5), "La división ha fallado!");
        }

        [Test]
        public void TestValidDivisionNumerosEnterosNegativos()
        {
            Assert.AreEqual(0.16666666666666666d, Operacion.Division(-2, -12), "La división ha fallado!");
        }

        [Test]
        public void TestValidDivisionNumerosDecimalesNegativos()
        {
            Assert.AreEqual(10.083870967741936d, Operacion.Division(-156.3, -15.5), "La división ha fallado!");
        }

        [Test]
        public void TestValidDivisionDeDivision()
        {
            Assert.AreEqual(0.20000000000000001, Operacion.Division(Operacion.Division(9, 9), 5), "La división ha fallado!");
        }
    }
}