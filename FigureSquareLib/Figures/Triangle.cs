namespace FigureSquareLib.Figures
{
    public class Triangle : IFigure
    {
        public double First { get; }
        public double Second { get; }
        public double Third { get; }
        public Triangle(double first, double second, double third)
        {
            if (first <= 0 || second <= 0 || third <= 0
                ||
                first + second <= third
                ||
                first + third <= second
                ||
                second + third <= first)
            {
                throw new ArgumentException();
            }

            First = first;
            Second = second;
            Third = third;
        }

        public double Perimeter()
        {
            return First + Second + Third;
        }

        public double Aria()
        {
            var halfPerimeter = Perimeter() / 2;
            return Math.Sqrt(halfPerimeter
                            * (halfPerimeter - First)
                            * (halfPerimeter - Second)
                            * (halfPerimeter - Third));
        }

        public bool IsRight()
        {
            var first = First == Math.Sqrt(Second * Second + Third * Third);
            var second = Second == Math.Sqrt(First * First + Third * Third);
            var third = Third == Math.Sqrt(First * First + Second * Second);
            
            return first || second || third;
        }
    }
}