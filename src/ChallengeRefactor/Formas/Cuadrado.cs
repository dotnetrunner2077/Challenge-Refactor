namespace ChallengeRefactor;

/// <summary>
/// Cuadrado.
/// </summary>
public class Cuadrado : IFormaGeometrica
{
    private readonly float _lado;

    public Cuadrado(float lado)
    {
        _lado = lado;
    }

    public float CalcularArea() => _lado * _lado;

    public float CalcularPerimetro() => _lado * 4;

    public string ObtenerNombre(int idioma, bool plural = false) => idioma switch
    {
        Idiomas.Ingles => plural ? "Squares" : "Square",
        Idiomas.Japones => plural ? "正方形" : "正方形",
        _ => plural ? "Cuadrados" : "Cuadrado",
    };
}
