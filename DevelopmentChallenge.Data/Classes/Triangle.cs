using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Triangle : Shape
    {
        private readonly decimal _lado;

        public override ShapeEnum Tipo { get { return ShapeEnum.TrianguloEquilatero; } }

        public Triangle(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
}
