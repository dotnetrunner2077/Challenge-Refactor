namespace ChallengeRefactor;

/// <summary>
/// Contrato que deben cumplir todas las formas geométricas.
/// </summary>
public interface IFormaGeometrica
{
    /// <summary>Calcula el área de la forma.</summary>
    float CalcularArea();

    /// <summary>Calcula el perímetro de la forma.</summary>
    float CalcularPerimetro();

    /// <summary>Devuelve el nombre de la forma en el idioma indicado.</summary>
    string ObtenerNombre(int idioma, bool plural = false);
}
