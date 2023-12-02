namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangle : Shape
    {
        private readonly decimal _base;
        private readonly decimal _altura;

        public override ShapeEnum Tipo { get { return ShapeEnum.Rectangulo; } }

        public Rectangle(decimal @base, decimal altura)
        {
            _base = @base;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return _base * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            return (_base * 2) + (_altura * 2);
        }
    }
}
