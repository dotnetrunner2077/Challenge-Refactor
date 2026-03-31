# Challenge-Refactor

> Solución al challenge de refactorización de código orientado a objetos — **.NET 8 / C#**

---

## 📋 Consigna

> *¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas?*

El punto de partida es una clase monolítica (`FormaGeometrica`) con lógica condicional para calcular áreas, perímetros y generar reportes en múltiples idiomas.  
El objetivo es refactorizarla aplicando principios de **Programación Orientada a Objetos** para que el sistema sea fácilmente extensible.

---

## ✅ ToDo resuelto

| Ítem | Estado |
|------|--------|
| Refactorizar respetando principios OOP (interfaz, polimorfismo, SRP) | ✅ |
| Implementar **Trapecio** | ✅ |
| Implementar **Rectángulo** | ✅ |
| Agregar idioma **Japonés** (日本語) al reporte | ✅ |
| Tests unitarios para la funcionalidad nueva y existente (todos en verde) | ✅ |

---

## 🏗️ Arquitectura

```
src/
└── ChallengeRefactor/
    ├── IFormaGeometrica.cs          # Interfaz base para todas las formas
    ├── Idiomas.cs                   # Constantes de idioma (Castellano, Inglés, Japonés)
    ├── ReporteFormas.cs             # Generador de reportes HTML
    └── Formas/
        ├── Cuadrado.cs
        ├── Circulo.cs
        ├── TrianguloEquilatero.cs
        ├── Trapecio.cs              # ✨ Nuevo
        └── Rectangulo.cs            # ✨ Nuevo

tests/
└── ChallengeRefactor.Tests/
    └── ReporteFormasTests.cs        # 28 tests unitarios (xUnit)
```

### Principios aplicados
- **SRP** — cada clase tiene una sola responsabilidad (calcular su propia área/perímetro y saber su nombre).
- **OCP** — agregar una nueva forma o idioma no requiere modificar código existente, sólo agregar una nueva clase.
- **LSP** — todas las formas son intercambiables a través de `IFormaGeometrica`.
- **DIP** — `ReporteFormas` opera sobre la abstracción `IFormaGeometrica`, no sobre tipos concretos.

---

## 🌐 Idiomas soportados

| Constante | Idioma |
|-----------|--------|
| `Idiomas.Castellano` | Español |
| `Idiomas.Ingles` | English |
| `Idiomas.Japones` | 日本語 (Japonés) |

---

## 🔷 Formas disponibles

| Clase | Parámetros del constructor |
|-------|---------------------------|
| `Cuadrado` | `lado` |
| `Circulo` | `radio` |
| `TrianguloEquilatero` | `lado` |
| `Trapecio` | `baseMayor, baseMenor, altura[, lado]` |
| `Rectangulo` | `ancho, alto` |

---

## 🚀 Cómo ejecutar

### Requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Compilar
```bash
dotnet build ChallengeRefactor.slnx
```

### Ejecutar tests
```bash
dotnet test tests/ChallengeRefactor.Tests/ChallengeRefactor.Tests.csproj
```

### Ejemplo de uso
```csharp
using ChallengeRefactor;

var formas = new List<IFormaGeometrica>
{
    new Cuadrado(5),
    new Circulo(3),
    new TrianguloEquilatero(4),
    new Trapecio(8, 4, 5, 5),
    new Rectangulo(6, 3),
};

// Reporte en español
Console.WriteLine(ReporteFormas.Imprimir(formas, Idiomas.Castellano));

// Reporte en inglés
Console.WriteLine(ReporteFormas.Imprimir(formas, Idiomas.Ingles));

// Reporte en japonés
Console.WriteLine(ReporteFormas.Imprimir(formas, Idiomas.Japones));
```

---

## 🧪 Tests

28 tests unitarios escritos con **xUnit** cubren:

- Lista vacía en los tres idiomas
- Cálculo de área y perímetro para cada forma
- Nombres singulares y plurales en los tres idiomas
- Generación correcta de reportes completos
- Totales de área y perímetro acumulados

---

## 📄 Licencia

MIT — ver [LICENSE](LICENSE).
