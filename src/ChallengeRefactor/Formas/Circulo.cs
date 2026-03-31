namespace ChallengeRefactor;

/// <summary>
/// Círculo.
/// </summary>
public class Circulo : IFormaGeometrica
{
    private readonly float _radio;

    public Circulo(float radio)
    {
        _radio = radio;
    }

    public float CalcularArea() => (float)(Math.PI * _radio * _radio);

    public float CalcularPerimetro() => (float)(2 * Math.PI * _radio);

    public string ObtenerNombre(int idioma, bool plural = false) => idioma switch
    {
        Idiomas.Ingles => plural ? "Circles" : "Circle",
        Idiomas.Japones => plural ? "円" : "円",
        _ => plural ? "Círculos" : "Círculo",
    };
}
