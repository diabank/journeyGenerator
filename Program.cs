using SNC;

namespace journeyGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car()
            {
                Descriptor = "LEAF",
            };

            Boat boat = new Boat()
            {
                Descriptor = "Esperance"
            };
            Console.WriteLine(car);
            Console.WriteLine(boat);

            Journey carJourney = new Journey(car);
            Journey boatJourney = new Journey(boat);

            carJourney.GenerateWayPoints();
            boatJourney.GenerateWayPoints();

            Console.ReadLine();
        }
    }
}
