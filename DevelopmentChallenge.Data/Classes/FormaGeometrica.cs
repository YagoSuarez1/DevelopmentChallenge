/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        public static string Imprimir(List<Shape> formas, string lng = "es-AR")
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lng);
            
            var sb = new StringBuilder();

            if (!formas.Any())
                sb.Append(language.ResourceManager.GetString("EmptyList"));
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append(language.ResourceManager.GetString("ReportTitle"));

                var areaCuadrados = formas.OfType<Square>().Sum(x => x.CalcularArea());
                var perimetroCuadrados = formas.OfType<Square>().Sum(x => x.CalcularPerimetro());
                var areaCirculos = formas.OfType<Circle>().Sum(x => x.CalcularArea());
                var perimetroCirculos = formas.OfType<Circle>().Sum(x => x.CalcularPerimetro());
                var areaTriangulos = formas.OfType<Triangle>().Sum(x => x.CalcularArea());
                var perimetroTriangulos = formas.OfType<Triangle>().Sum(x => x.CalcularPerimetro());
                var areaRectangulos = formas.OfType<Rectangle>().Sum(x => x.CalcularArea());
                var perimetroRectangulos = formas.OfType<Rectangle>().Sum(x => x.CalcularPerimetro());

                sb.Append(ObtenerLinea(formas.OfType<Square>().Count(), areaCuadrados, perimetroCuadrados, ShapeEnum.Cuadrado));
                sb.Append(ObtenerLinea(formas.OfType<Circle>().Count(), areaCirculos, perimetroCirculos, ShapeEnum.Circulo));
                sb.Append(ObtenerLinea(formas.OfType<Triangle>().Count(), areaTriangulos, perimetroTriangulos, ShapeEnum.TrianguloEquilatero));
                sb.Append(ObtenerLinea(formas.OfType<Rectangle>().Count(), areaRectangulos, perimetroRectangulos, ShapeEnum.Rectangulo));

                // FOOTER
                sb.Append(TranslatorHelper.GetTranslation("Total"));
                sb.Append($"{formas.Count} {TranslatorHelper.GetTranslation("Shapes")} ");
                sb.Append($"{TranslatorHelper.GetTranslation("Perimeter")} {(perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroRectangulos).ToString("#.##")} ");
                sb.Append($"{TranslatorHelper.GetTranslation("Area")} {(areaCuadrados + areaCirculos + areaTriangulos + areaRectangulos).ToString("#.##")}");
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, ShapeEnum tipo)
        {
            return cantidad > 0 ? string.Format(TranslatorHelper.GetTranslation("ReportLine"), cantidad, TraducirForma(tipo, cantidad), area, perimetro) : string.Empty;
        }

        private static string TraducirForma(ShapeEnum tipo, int cantidad)
        {
            switch (tipo)
            {
                case ShapeEnum.Cuadrado:
                    return cantidad == 1 ? TranslatorHelper.GetTranslation("Square") : TranslatorHelper.GetTranslation("Squares");
                case ShapeEnum.Circulo:
                    return cantidad == 1 ? TranslatorHelper.GetTranslation("Circle") : TranslatorHelper.GetTranslation("Circles");
                case ShapeEnum.TrianguloEquilatero:
                    return cantidad == 1 ? TranslatorHelper.GetTranslation("Triangle") : TranslatorHelper.GetTranslation("Triangles");
                case ShapeEnum.Rectangulo:
                    return cantidad == 1 ? TranslatorHelper.GetTranslation("Rectangle") : TranslatorHelper.GetTranslation("Rectangles");
            }

            return string.Empty;
        }
    }
}
