namespace BSwD_Week_2
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<Shape> shapes = Shape.GenerateRandomShapes(5);

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }

            Console.WriteLine("Largest area:");
            Console.WriteLine(Shape.LargestShape(shapes));
        }
    }
}