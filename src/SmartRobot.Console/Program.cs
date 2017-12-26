namespace SmartRobot.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Robot(new MapReader());
            var g = new Point(3, 5);

            while (r.Position != g)
            {
                System.Console.WriteLine(r.Position);
                r.StepTwards(g);
            }
            System.Console.WriteLine(r.Position);
        }
    }



}
