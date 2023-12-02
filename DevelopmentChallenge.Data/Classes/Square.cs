namespace DevelopmentChallenge.Data.Classes
{
    public class Square : Shape
    {
        private readonly decimal _lado;

        public override ShapeEnum Tipo { get { return ShapeEnum.Cuadrado; } }

        public Square(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }
}
