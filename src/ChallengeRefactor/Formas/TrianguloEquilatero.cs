namespace ChallengeRefactor;

/// <summary>
/// Triángulo Equilátero.
/// </summary>
public class TrianguloEquilatero : IFormaGeometrica
{
    private readonly float _lado;

    public TrianguloEquilatero(float lado)
    {
        _lado = lado;
    }

    public float CalcularArea() => (float)(Math.Sqrt(3) / 4 * _lado * _lado);

    public float CalcularPerimetro() => _lado * 3;

    public string ObtenerNombre(int idioma, bool plural = false) => idioma switch
    {
        Idiomas.Ingles => plural ? "Equilateral Triangles" : "Equilateral Triangle",
        Idiomas.Japones => plural ? "正三角形" : "正三角形",
        _ => plural ? "Triángulos Equiláteros" : "Triángulo Equilátero",
    };
}
