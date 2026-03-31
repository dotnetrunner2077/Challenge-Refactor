/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte. => Japonés xD
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    //Primero creo la clase base abstracta para calcular el área y perimetro de cada forma. 
    //Y porsupuesto el nombre en el idiema que reciba como parámetro
    public abstract class Formas
    {

        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string Nombre(int idioma);
    }

    //Creo una clase para cada forma (cuadrado) y aplico el principio de herencia para sobrescribir los metodos de la clase padre (Formas)
    public class Cuadrado : Formas
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        //Sobrescribo la clase y aplico las expresión lambda.
        public override decimal CalcularArea() => _lado * _lado;

        //Sobrescribo la clase y aplico las expresión lambda.
        public override decimal CalcularPerimetro() => _lado * 4;

        //Sobrescribo la clase y aplico las expresión lambda.
        public override string Nombre(int idioma) => ReporteFormas.TraducirForma("Cuadrado", idioma);
    }

    //Creo una clase para cada forma (Circulo) y aplico el principio de herencia para sobrescribir los metodos de la clase padre (Formas)
    public class Circulo : Formas
    {
        private readonly decimal _radio;

        public Circulo(decimal radio)
        {
            _radio = radio;
        }

        public override decimal CalcularArea() => (decimal)Math.PI * (_radio / 2) * (_radio / 2);

        public override decimal CalcularPerimetro() => (decimal)Math.PI * _radio;

        public override string Nombre(int idioma) => ReporteFormas.TraducirForma("Círculo", idioma);
    }

    public class TrianguloEquilatero : Formas
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;

        public override decimal CalcularPerimetro() => _lado * 3;

        public override string Nombre(int idioma) => ReporteFormas.TraducirForma("Triángulo", idioma);
    }

    //Creo una clase para cada forma (Trapecio/Rectangulo) y aplico el principio de herencia para sobrescribir los metodos de la clase padre (Formas)
    public class Trapecio : Formas
    {
        private readonly decimal _baseMenor;
        private readonly decimal _baseMayor;
        private readonly decimal _altura;
        private readonly decimal _lado1;
        private readonly decimal _lado2;

        public Trapecio(decimal baseMenor, decimal baseMayor, decimal altura, decimal lado1, decimal lado2)
        {
            _baseMenor = baseMenor;
            _baseMayor = baseMayor;
            _altura = altura;
            _lado1 = lado1;
            _lado2 = lado2;
        }

        public override decimal CalcularArea() => ((_baseMayor + _baseMenor) * _altura) / 2;

        public override decimal CalcularPerimetro() => _baseMenor + _baseMayor + _lado1 + _lado2;

        public override string Nombre(int idioma) => ReporteFormas.TraducirForma("Trapecio", idioma);
    }

    public static class ReporteFormas
    {
        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Japones = 3;

        public static string Imprimir(List<Formas> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.AppendLine("<h1>Lista vacía de formas!</h1>");
                else if (idioma == Japones)
                    sb.AppendLine("<h1>投票リストフォーム！</h1>");
                else
                    sb.AppendLine("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                if (idioma == Castellano)
                    sb.AppendLine("<h1>Reporte de Formas</h1>");
                else if (idioma == Japones)
                    sb.AppendLine("<h1>正しい関係</h1>");
                else
                    sb.AppendLine("<h1>Shapes report</h1>");

                var totalPerimetro = 0m;
                var totalArea = 0m;

                foreach (var forma in formas)
                {
                    var area = forma.CalcularArea();
                    var perimetro = forma.CalcularPerimetro();

                    totalArea += area;
                    totalPerimetro += perimetro;

                    sb.AppendLine($"{forma.Nombre(idioma)} | Area: {area:#.##} | Perímetro: {perimetro:#.##}<br/>");
                }

                sb.AppendLine("TOTAL:<br/>");
                if (idioma == Castellano)
                    sb.AppendLine($"{formas.Count} formas ");
                else if (idioma == Japones)
                    sb.AppendLine($"{formas.Count} 形状 ");
                else
                    sb.AppendLine($"{formas.Count} shapes ");

                if (idioma == Castellano)
                    sb.AppendLine($"Perímetro: {totalPerimetro:#.##} ");
                else if (idioma == Japones)
                    sb.AppendLine($"周囲: {totalPerimetro:#.##} ");
                else
                    sb.AppendLine($"Perimeter: {totalPerimetro:#.##} ");

                sb.AppendLine($"Área: {totalArea:#.##}");
            }

            return sb.ToString();
        }

        public static string TraducirForma(string nombreForma, int idioma)
        {
            if (idioma == Castellano)
            {
                return nombreForma;
            }
            else if (idioma == Japones)
            {
                switch (nombreForma)
                {
                    case "Cuadrado": return "四角";
                    case "Círculo": return "丸";
                    case "Triángulo": return "三角形";
                    case "Trapecio": return "空中ブランコ";
                    default: return nombreForma;
                }
            }
            else
            {
                switch (nombreForma)
                {
                    case "Cuadrado": return "Square";
                    case "Círculo": return "Circle";
                    case "Triángulo": return "Triangle";
                    case "Trapecio": return "Trapezoid";
                    default: return nombreForma;
                }
            }
        }
    }
}