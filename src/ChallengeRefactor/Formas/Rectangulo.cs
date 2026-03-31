namespace ChallengeRefactor;

/// <summary>
/// Rectángulo.
/// </summary>
public class Rectangulo : IFormaGeometrica
{
    private readonly float _ancho;
    private readonly float _alto;

    public Rectangulo(float ancho, float alto)
    {
        _ancho = ancho;
        _alto = alto;
    }

    public float CalcularArea() => _ancho * _alto;

    public float CalcularPerimetro() => 2 * (_ancho + _alto);

    public string ObtenerNombre(int idioma, bool plural = false) => idioma switch
    {
        Idiomas.Ingles => plural ? "Rectangles" : "Rectangle",
        Idiomas.Japones => plural ? "長方形" : "長方形",
        _ => plural ? "Rectángulos" : "Rectángulo",
    };
}
