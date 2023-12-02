using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circle : Shape
    {
        private readonly decimal _lado;

        public override ShapeEnum Tipo { get { return ShapeEnum.Circulo; } }

        public Circle(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
           return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
           return (decimal)Math.PI * _lado;
        }
    }
}
