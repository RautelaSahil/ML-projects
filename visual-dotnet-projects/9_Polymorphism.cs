using System;

// =====================================================================
// PART 1: COMPILE-TIME POLYMORPHISM (Method Overloading / Static Binding)
// =====================================================================
class AreaCalculator
{
    // 1. Overload for Square: Area = side * side
    public double CalculateArea(double side)
    {
        return side * side;
    }

    // 2. Overload for Rectangle: Area = length * breadth
    public double CalculateArea(double length, double breadth)
    {
        return length * breadth;
    }

    // 3. Overload for Circle: Area = PI * r * r
    public double CalculateArea(double radius, bool isCircle)
    {
        return Math.PI * radius * radius;
    }

    // 4. Overload for Triangle: Area = 0.5 * base * height
    public double CalculateArea(float baseLength, float height)
    {
        return 0.5 * baseLength * height;
    }
}

// =====================================================================
// PART 2: RUN-TIME POLYMORPHISM (Method Overriding / Dynamic Binding)
// =====================================================================
class Shape
{
    public string Name { get; set; }

    public Shape(string name)
    {
        Name = name;
    }

    // Virtual method to be overridden by derived classes
    public virtual void Draw()
    {
        Console.WriteLine("[Base Class: Shape] Drawing a generic shape: " + Name);
    }

    public virtual void Description()
    {
        Console.WriteLine("-> This is a 2D geometric shape.");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius) : base("Circle")
    {
        Radius = radius;
    }

    // Overriding base class virtual method
    public override void Draw()
    {
        Console.WriteLine("[Derived Class: Circle] Drawing a Circle with radius " + Radius);
    }

    public override void Description()
    {
        Console.WriteLine("-> Circle is perfectly round with no corners.");
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height) : base("Rectangle")
    {
        Width = width;
        Height = height;
    }

    // Overriding base class virtual method
    public override void Draw()
    {
        Console.WriteLine("[Derived Class: Rectangle] Drawing a Rectangle (" + Width + " x " + Height + ")");
    }

    public override void Description()
    {
        Console.WriteLine("-> Rectangle has 4 right angles and parallel opposite sides.");
    }
}

class Triangle : Shape
{
    public Triangle() : base("Triangle") { }

    public override void Draw()
    {
        Console.WriteLine("[Derived Class: Triangle] Drawing a 3-sided Triangle.");
    }

    public override void Description()
    {
        Console.WriteLine("-> Triangle has 3 edges and 3 vertices.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==========================================================================");
        Console.WriteLine("        Polymorphism in C# (Compile-Time and Run-Time)                   ");
        Console.WriteLine("==========================================================================");

        // -----------------------------------------------------------------
        // SECTION 1: COMPILE-TIME POLYMORPHISM DEMONSTRATION
        // -----------------------------------------------------------------
        Console.WriteLine("\n[1] COMPILE-TIME POLYMORPHISM (Method Overloading):");
        Console.WriteLine("    Method name 'CalculateArea' is overloaded with different signatures:\n");

        AreaCalculator calc = new AreaCalculator();

        double squareArea = calc.CalculateArea(5.0);
        double rectArea = calc.CalculateArea(6.0, 4.0);
        double circleArea = calc.CalculateArea(3.0, true);
        double triangleArea = calc.CalculateArea(8.0f, 5.0f);

        Console.WriteLine("  * Square Area       (side = 5)          : " + squareArea);
        Console.WriteLine("  * Rectangle Area    (len = 6, br = 4)   : " + rectArea);
        Console.WriteLine("  * Circle Area       (radius = 3)        : {0:F2}", circleArea);
        Console.WriteLine("  * Triangle Area     (base = 8, h = 5)   : " + triangleArea);

        // -----------------------------------------------------------------
        // SECTION 2: RUN-TIME POLYMORPHISM DEMONSTRATION
        // -----------------------------------------------------------------
        Console.WriteLine("\n[2] RUN-TIME POLYMORPHISM (Method Overriding):");
        Console.WriteLine("    Base class reference pointing to derived class objects:\n");

        // Base class array holding derived class instances
        Shape[] shapes = new Shape[]
        {
            new Circle(7.5),
            new Rectangle(10.0, 4.5),
            new Triangle()
        };

        foreach (Shape s in shapes)
        {
            // Dynamic dispatch resolves the appropriate Draw() method at runtime
            s.Draw();
            s.Description();
            Console.WriteLine();
        }

        Console.WriteLine("==========================================================================");
    }
}
