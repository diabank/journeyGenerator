namespace journeyGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car()
            {
                Descriptor = "OLIVE BRANCH"
            };

            Boat boat = new Boat()
            {
                Descriptor = "ESPERANCE"
            };

            Journey carJourney = new Journey(car);
            Journey boatJourney = new Journey(boat);

            boatJourney.GenerateBoatWayPoints();
            carJourney.GenerateCarWayPoints();

            boatJourney.WriteToFile();
            carJourney.WriteToFile();

            Console.WriteLine("Journey Generator ... Complete");
            Console.ReadLine();
        }
    }
}
