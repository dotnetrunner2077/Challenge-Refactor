using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>\r\n",
                ReporteFormas.Imprimir(new List<Formas>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>\r\n",
                ReporteFormas.Imprimir(new List<Formas>(), 2));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnJapones()
        {
            Assert.AreEqual("<h1>投票リストフォーム！</h1>\r\n",
                ReporteFormas.Imprimir(new List<Formas>(), 3));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<Formas> {new Cuadrado(5)};

            var resumen = ReporteFormas.Imprimir(cuadrados, ReporteFormas.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>\r\nCuadrado | Area: 25 | Perímetro: 20<br/>\r\nTOTAL:<br/>\r\n1 formas \r\nPerímetro: 20 \r\nÁrea: 25\r\n", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<Formas>
            {
                new Cuadrado (5),
                new Cuadrado (1),
                new Cuadrado (3)
            };

            var resumen = ReporteFormas.Imprimir(cuadrados, ReporteFormas.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>\r\nSquare | Area: 25 | Perímetro: 20<br/>\r\nSquare | Area: 1 | Perímetro: 4<br/>\r\nSquare | Area: 9 | Perímetro: 12<br/>\r\nTOTAL:<br/>\r\n3 shapes \r\nPerimeter: 36 \r\nÁrea: 35\r\n", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<Formas>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m),
                new Trapecio(2.75m,4,3,2,6),
                new Trapecio(4.2m,9,7,8,16)
            };

            var resumen = ReporteFormas.Imprimir(formas, ReporteFormas.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>\r\nSquare | Area: 25 | Perímetro: 20<br/>\r\nCircle | Area: 7,07 | Perímetro: 9,42<br/>\r\nTriangle | Area: 6,93 | Perímetro: 12<br/>\r\nSquare | Area: 4 | Perímetro: 8<br/>\r\nTriangle | Area: 35,07 | Perímetro: 27<br/>\r\nCircle | Area: 5,94 | Perímetro: 8,64<br/>\r\nTriangle | Area: 7,64 | Perímetro: 12,6<br/>\r\nTrapezoid | Area: 10,13 | Perímetro: 14,75<br/>\r\nTrapezoid | Area: 46,2 | Perímetro: 37,2<br/>\r\nTOTAL:<br/>\r\n9 shapes \r\nPerimeter: 149,61 \r\nÁrea: 147,97\r\n",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<Formas>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            var resumen = ReporteFormas.Imprimir(formas, ReporteFormas.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>\r\nCuadrado | Area: 25 | Perímetro: 20<br/>\r\nCírculo | Area: 7,07 | Perímetro: 9,42<br/>\r\nTriángulo | Area: 6,93 | Perímetro: 12<br/>\r\nCuadrado | Area: 4 | Perímetro: 8<br/>\r\nTriángulo | Area: 35,07 | Perímetro: 27<br/>\r\nCírculo | Area: 5,94 | Perímetro: 8,64<br/>\r\nTriángulo | Area: 7,64 | Perímetro: 12,6<br/>\r\nTOTAL:<br/>\r\n7 formas \r\nPerímetro: 97,66 \r\nÁrea: 91,65\r\n",
                resumen);
        }
    }
}
