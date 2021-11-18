namespace FigureSquareLib.Figures
{
    public class Circle : IFigure
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            if (radius <= 0) {
                throw new ArgumentException();
            }
            Radius = radius;
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double Aria()
        {
            return Math.PI * Radius * Radius;
        }
    }
}