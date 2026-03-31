namespace ChallengeRefactor;

/// <summary>
/// Trapecio.
/// Requiere la base mayor, la base menor y la altura.
/// Los lados laterales se asumen iguales (trapecio isósceles) para el perímetro,
/// calculados desde la geometría cuando no se proveen explícitamente.
/// </summary>
public class Trapecio : IFormaGeometrica
{
    private readonly float _baseMayor;
    private readonly float _baseMenor;
    private readonly float _altura;
    private readonly float _lado;

    /// <param name="baseMayor">Longitud de la base mayor.</param>
    /// <param name="baseMenor">Longitud de la base menor.</param>
    /// <param name="altura">Altura del trapecio.</param>
    /// <param name="lado">Longitud de los lados laterales (isósceles). Si es 0 se calcula automáticamente.</param>
    public Trapecio(float baseMayor, float baseMenor, float altura, float lado = 0)
    {
        _baseMayor = baseMayor;
        _baseMenor = baseMenor;
        _altura = altura;
        _lado = lado == 0
            ? (float)Math.Sqrt(Math.Pow((_baseMayor - _baseMenor) / 2, 2) + Math.Pow(altura, 2))
            : lado;
    }

    public float CalcularArea() => (_baseMayor + _baseMenor) / 2 * _altura;

    public float CalcularPerimetro() => _baseMayor + _baseMenor + 2 * _lado;

    public string ObtenerNombre(int idioma, bool plural = false) => idioma switch
    {
        Idiomas.Ingles => plural ? "Trapezoids" : "Trapezoid",
        Idiomas.Japones => plural ? "台形" : "台形",
        _ => plural ? "Trapecios" : "Trapecio",
    };
}
