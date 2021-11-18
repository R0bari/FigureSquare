using System;
using System.Collections.Generic;
using Xunit;
using FigureSquareLib.Figures;

namespace FigureSquareLibTests;

public class FigureTests
{
    [Fact]
    public void TriangleTest()
    {
        var testList = new List<Tuple<double, double, double, double, double>>()
        {
            Tuple.Create<double, double, double, double, double>(3, 4, 5, 12, 6),
            Tuple.Create<double, double, double, double, double>(5, 8, 12, 25, 14.5237),
            Tuple.Create<double, double, double, double, double>(10, 20, 24, 54, 98.1784),
            Tuple.Create<double, double, double, double, double>(15, 25, 35, 75, 162.3798),
            Tuple.Create<double, double, double, double, double>(25, 25, 25, 75, 270.6329),
            Tuple.Create<double, double, double, double, double>(20000, 18400, 34000, 72400, 151_542_041.6914)
        };

        foreach (var testData in testList)
        {
            var actualCircle = new Triangle(testData.Item1, testData.Item2, testData.Item3);
            var actualPerimeter = Math.Round(actualCircle.Perimeter(), 4);
            var actualSquare = Math.Round(actualCircle.Aria(), 4);
            Assert.Equal(testData.Item4, actualPerimeter);
            Assert.Equal(testData.Item5, actualSquare);
        }

        Assert.True(new Triangle(3, 4, 5).IsRight());
        Assert.True(new Triangle(5, 12, 13).IsRight());
    }

    [Fact]
    public void CircleTest()
    {
        var testList = new List<Tuple<double, double, double>>()
        {
            Tuple.Create<double, double, double>(3, 18.8496, 28.2743),
            Tuple.Create<double, double, double>(5, 31.4159, 78.5398),
            Tuple.Create<double, double, double>(10, 62.8319, 314.1593),
            Tuple.Create<double, double, double>(15, 94.2478, 706.8583),
            Tuple.Create<double, double, double>(25, 157.0796, 1_963.4954),
            Tuple.Create<double, double, double>(20000, 125663.7061, 1_256_637_061.4359)
        };

        foreach (var testData in testList)
        {
            var actualCircle = new Circle(testData.Item1);
            var actualPerimeter = Math.Round(actualCircle.Perimeter(), 4);
            var actualSquare = Math.Round(actualCircle.Aria(), 4);
            Assert.Equal(testData.Item2, actualPerimeter);
            Assert.Equal(testData.Item3, actualSquare);
        }
    }


    [Fact]
    public void PolymorphTest()
    {
        var testList = new List<Tuple<IFigure, double>>()
        {
            Tuple.Create<IFigure, double>(new Triangle(3, 4, 5), 6),
            Tuple.Create<IFigure, double>(new Triangle(5, 12, 13), 30),
            Tuple.Create<IFigure, double>(new Circle(5), 78.5398),
            Tuple.Create<IFigure, double>(new Circle(12), 452.3893)
        };

        foreach (var testData in testList)
        {
            Assert.Equal(testData.Item2, Math.Round(testData.Item1.Aria(), 4));
        }
    }
}