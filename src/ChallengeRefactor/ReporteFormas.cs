using System.Text;

namespace ChallengeRefactor;

/// <summary>
/// Genera reportes HTML con estadísticas de una lista de formas geométricas.
/// </summary>
public class ReporteFormas
{
    /// <summary>
    /// Genera un reporte HTML con el resumen de las formas geométricas proporcionadas.
    /// </summary>
    /// <param name="formas">Lista de formas geométricas.</param>
    /// <param name="idioma">Identificador de idioma (ver <see cref="Idiomas"/>).</param>
    /// <returns>Cadena HTML con el reporte.</returns>
    public static string Imprimir(List<IFormaGeometrica> formas, int idioma)
    {
        if (formas == null || formas.Count == 0)
        {
            return idioma switch
            {
                Idiomas.Ingles => "<h1>Empty list of shapes!</h1>",
                Idiomas.Japones => "<h1>図形リストが空です！</h1>",
                _ => "<h1>Lista vacía de formas!</h1>",
            };
        }

        var sb = new StringBuilder();

        // Encabezado
        sb.Append(idioma switch
        {
            Idiomas.Ingles => "<h1>Shapes report</h1>",
            Idiomas.Japones => "<h1>図形レポート</h1>",
            _ => "<h1>Reporte de Formas</h1>",
        });

        // Agrupamos por tipo para resumir en el detalle
        var grupos = formas
            .GroupBy(f => f.GetType())
            .Select(g => new
            {
                Nombre = g.First().ObtenerNombre(idioma, plural: g.Count() > 1),
                Cantidad = g.Count(),
                Area = g.Sum(f => f.CalcularArea()),
                Perimetro = g.Sum(f => f.CalcularPerimetro()),
            });

        foreach (var grupo in grupos)
        {
            sb.Append(idioma switch
            {
                Idiomas.Ingles =>
                    $"{grupo.Cantidad} {grupo.Nombre} | Area {grupo.Area:#.##} | Perimeter {grupo.Perimetro:#.##} <br/>",
                Idiomas.Japones =>
                    $"{grupo.Cantidad} {grupo.Nombre} | 面積 {grupo.Area:#.##} | 周囲 {grupo.Perimetro:#.##} <br/>",
                _ =>
                    $"{grupo.Cantidad} {grupo.Nombre} | Area {grupo.Area:#.##} | Perímetro {grupo.Perimetro:#.##} <br/>",
            });
        }

        // Totales
        float totalArea = formas.Sum(f => f.CalcularArea());
        float totalPerimetro = formas.Sum(f => f.CalcularPerimetro());
        int totalFormas = formas.Count;

        sb.Append(idioma switch
        {
            Idiomas.Ingles =>
                $"TOTAL:<br/>{totalFormas} shapes Perimeter {totalPerimetro:#.##} Area {totalArea:#.##}",
            Idiomas.Japones =>
                $"合計:<br/>{totalFormas} 図形 周囲 {totalPerimetro:#.##} 面積 {totalArea:#.##}",
            _ =>
                $"TOTAL:<br/>{totalFormas} formas Perímetro {totalPerimetro:#.##} Area {totalArea:#.##}",
        });

        return sb.ToString();
    }
}
