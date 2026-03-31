using ChallengeRefactor;
using Xunit;

namespace ChallengeRefactor.Tests;

public class ReporteFormasTests
{
    // ─── Lista vacía ────────────────────────────────────────────────────────────

    [Fact]
    public void Imprimir_ListaVacia_Castellano_RetornaMensajeVacio()
    {
        var resultado = ReporteFormas.Imprimir([], Idiomas.Castellano);
        Assert.Equal("<h1>Lista vacía de formas!</h1>", resultado);
    }

    [Fact]
    public void Imprimir_ListaVacia_Ingles_RetornaMensajeVacio()
    {
        var resultado = ReporteFormas.Imprimir([], Idiomas.Ingles);
        Assert.Equal("<h1>Empty list of shapes!</h1>", resultado);
    }

    [Fact]
    public void Imprimir_ListaVacia_Japones_RetornaMensajeVacio()
    {
        var resultado = ReporteFormas.Imprimir([], Idiomas.Japones);
        Assert.Equal("<h1>図形リストが空です！</h1>", resultado);
    }

    // ─── Un solo Cuadrado ───────────────────────────────────────────────────────

    [Fact]
    public void Imprimir_UnCuadrado_Castellano_RetornaReporteCorrecto()
    {
        var formas = new List<IFormaGeometrica> { new Cuadrado(5) };
        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Castellano);

        Assert.Contains("<h1>Reporte de Formas</h1>", resultado);
        Assert.Contains("1 Cuadrado", resultado);
        Assert.Contains("Area 25", resultado);
        Assert.Contains("Perímetro 20", resultado);
        Assert.Contains("1 formas", resultado);
    }

    [Fact]
    public void Imprimir_UnCuadrado_Ingles_RetornaReporteCorrecto()
    {
        var formas = new List<IFormaGeometrica> { new Cuadrado(5) };
        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Ingles);

        Assert.Contains("<h1>Shapes report</h1>", resultado);
        Assert.Contains("1 Square", resultado);
        Assert.Contains("Area 25", resultado);
        Assert.Contains("Perimeter 20", resultado);
        Assert.Contains("1 shapes", resultado);
    }

    [Fact]
    public void Imprimir_UnCuadrado_Japones_RetornaReporteCorrecto()
    {
        var formas = new List<IFormaGeometrica> { new Cuadrado(5) };
        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Japones);

        Assert.Contains("<h1>図形レポート</h1>", resultado);
        Assert.Contains("1 正方形", resultado);
        Assert.Contains("面積 25", resultado);
        Assert.Contains("周囲 20", resultado);
        Assert.Contains("1 図形", resultado);
    }

    // ─── Múltiples formas mixtas ────────────────────────────────────────────────

    [Fact]
    public void Imprimir_MultipleFormas_Castellano_CalculaTotalesCorrectos()
    {
        var formas = new List<IFormaGeometrica>
        {
            new Cuadrado(5),
            new Circulo(3),
            new TrianguloEquilatero(4),
        };

        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Castellano);

        Assert.Contains("3 formas", resultado);
        Assert.Contains("1 Cuadrado", resultado);
        Assert.Contains("1 Círculo", resultado);
        Assert.Contains("1 Triángulo Equilátero", resultado);
    }

    [Fact]
    public void Imprimir_MultipleFormas_Ingles_CalculaTotalesCorrectos()
    {
        var formas = new List<IFormaGeometrica>
        {
            new Cuadrado(5),
            new Cuadrado(3),
            new Circulo(2),
        };

        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Ingles);

        Assert.Contains("3 shapes", resultado);
        Assert.Contains("2 Squares", resultado);
        Assert.Contains("1 Circle", resultado);
    }

    // ─── Trapecio ────────────────────────────────────────────────────────────────

    [Fact]
    public void Trapecio_CalculaAreaCorrecta()
    {
        // Área = (baseMayor + baseMenor) / 2 * altura = (8 + 4) / 2 * 5 = 30
        var trapecio = new Trapecio(8, 4, 5, 5);
        Assert.Equal(30f, trapecio.CalcularArea(), 2);
    }

    [Fact]
    public void Trapecio_CalculaPerimetroCorrectoConLadoExplicito()
    {
        // Perímetro = baseMayor + baseMenor + 2 * lado = 8 + 4 + 2*5 = 22
        var trapecio = new Trapecio(8, 4, 5, 5);
        Assert.Equal(22f, trapecio.CalcularPerimetro(), 2);
    }

    [Fact]
    public void Trapecio_CalculaPerimetroConLadoAutoCalculado()
    {
        // isósceles: diferencia de bases = 8-4 = 4, mitad = 2; lado = sqrt(2²+5²) = sqrt(29)
        var trapecio = new Trapecio(8, 4, 5);
        var ladoEsperado = (float)Math.Sqrt(4 + 25);
        Assert.Equal(8 + 4 + 2 * ladoEsperado, trapecio.CalcularPerimetro(), 2);
    }

    [Fact]
    public void Trapecio_ObtenerNombre_Castellano() =>
        Assert.Equal("Trapecio", new Trapecio(8, 4, 5).ObtenerNombre(Idiomas.Castellano));

    [Fact]
    public void Trapecio_ObtenerNombre_Ingles() =>
        Assert.Equal("Trapezoid", new Trapecio(8, 4, 5).ObtenerNombre(Idiomas.Ingles));

    [Fact]
    public void Trapecio_ObtenerNombre_Japones() =>
        Assert.Equal("台形", new Trapecio(8, 4, 5).ObtenerNombre(Idiomas.Japones));

    [Fact]
    public void Imprimir_ConTrapecio_Castellano_ContieneNombreCorrecto()
    {
        var formas = new List<IFormaGeometrica> { new Trapecio(8, 4, 5, 5) };
        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Castellano);
        Assert.Contains("1 Trapecio", resultado);
        Assert.Contains("Area 30", resultado);
    }

    // ─── Rectángulo ─────────────────────────────────────────────────────────────

    [Fact]
    public void Rectangulo_CalculaAreaCorrecta()
    {
        var rect = new Rectangulo(4, 6);
        Assert.Equal(24f, rect.CalcularArea(), 2);
    }

    [Fact]
    public void Rectangulo_CalculaPerimetroCorrecto()
    {
        var rect = new Rectangulo(4, 6);
        Assert.Equal(20f, rect.CalcularPerimetro(), 2);
    }

    [Fact]
    public void Rectangulo_ObtenerNombre_Castellano() =>
        Assert.Equal("Rectángulo", new Rectangulo(4, 6).ObtenerNombre(Idiomas.Castellano));

    [Fact]
    public void Rectangulo_ObtenerNombre_Ingles() =>
        Assert.Equal("Rectangle", new Rectangulo(4, 6).ObtenerNombre(Idiomas.Ingles));

    [Fact]
    public void Rectangulo_ObtenerNombre_Japones() =>
        Assert.Equal("長方形", new Rectangulo(4, 6).ObtenerNombre(Idiomas.Japones));

    [Fact]
    public void Imprimir_ConRectangulo_Ingles_ContieneNombreCorrecto()
    {
        var formas = new List<IFormaGeometrica> { new Rectangulo(4, 6) };
        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Ingles);
        Assert.Contains("1 Rectangle", resultado);
        Assert.Contains("Area 24", resultado);
        Assert.Contains("Perimeter 20", resultado);
    }

    // ─── Círculo ─────────────────────────────────────────────────────────────────

    [Fact]
    public void Circulo_CalculaAreaCorrecta()
    {
        var circulo = new Circulo(5);
        Assert.Equal((float)(Math.PI * 25), circulo.CalcularArea(), 2);
    }

    [Fact]
    public void Circulo_CalculaPerimetroCorrecto()
    {
        var circulo = new Circulo(5);
        Assert.Equal((float)(2 * Math.PI * 5), circulo.CalcularPerimetro(), 2);
    }

    // ─── Triángulo Equilátero ────────────────────────────────────────────────────

    [Fact]
    public void TrianguloEquilatero_CalculaAreaCorrecta()
    {
        var triangulo = new TrianguloEquilatero(4);
        Assert.Equal((float)(Math.Sqrt(3) / 4 * 16), triangulo.CalcularArea(), 2);
    }

    [Fact]
    public void TrianguloEquilatero_CalculaPerimetroCorrecto()
    {
        var triangulo = new TrianguloEquilatero(4);
        Assert.Equal(12f, triangulo.CalcularPerimetro(), 2);
    }

    // ─── Idioma Japonés (completo) ───────────────────────────────────────────────

    [Fact]
    public void Imprimir_MultipleFormas_Japones_ContieneTextoJapones()
    {
        var formas = new List<IFormaGeometrica>
        {
            new Cuadrado(3),
            new Rectangulo(2, 4),
            new Trapecio(6, 3, 4, 4),
            new Circulo(2),
            new TrianguloEquilatero(3),
        };

        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Japones);

        Assert.Contains("<h1>図形レポート</h1>", resultado);
        Assert.Contains("正方形", resultado);
        Assert.Contains("長方形", resultado);
        Assert.Contains("台形", resultado);
        Assert.Contains("円", resultado);
        Assert.Contains("正三角形", resultado);
        Assert.Contains("5 図形", resultado);
        Assert.Contains("面積", resultado);
        Assert.Contains("周囲", resultado);
    }

    // ─── Plural ──────────────────────────────────────────────────────────────────

    [Fact]
    public void Imprimir_DosCuadrados_Castellano_UsaPlural()
    {
        var formas = new List<IFormaGeometrica> { new Cuadrado(3), new Cuadrado(5) };
        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Castellano);
        Assert.Contains("2 Cuadrados", resultado);
    }

    [Fact]
    public void Imprimir_DosCirculos_Ingles_UsaPlural()
    {
        var formas = new List<IFormaGeometrica> { new Circulo(3), new Circulo(5) };
        var resultado = ReporteFormas.Imprimir(formas, Idiomas.Ingles);
        Assert.Contains("2 Circles", resultado);
    }
}
