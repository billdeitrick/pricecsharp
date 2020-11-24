using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise02
{
    public interface Shape
    {
        public double Area { get; }
    }

    public class Rectangle : Shape {

        public double Height, Width;
    
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Area
        {
            get
            {
                return Height * Width;
            }
        }

    }

    public class Square : Rectangle {

        public Square(double sideLength) : base(sideLength, sideLength) { }

    }

    public class Circle : Shape
    {

        public double Height, Width, Radius;

        public Circle(double radius) {
            Radius = radius;
            Height = Width = Radius * 2;
        }

        public double Area
        {
            get
            {
                return Math.PI * Math.Pow(Radius, 2);
            }
        }
    }
}
