namespace DevelopmentChallenge.Data.Classes
{
    public abstract class Shape
    {
        public virtual ShapeEnum Tipo { get; }
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
     }
}
