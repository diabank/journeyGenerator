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

            //double endLat = 0.00;
            //double endLong = 0.00;
            //GeoCalc.GetEndingCoordinates(38.88, -104.70, 270, 4224, out endLat, out endLong);
            //Console.WriteLine("End Lat:{0} End Long:{1}", endLat.ToString(),endLong.ToString());

            //var randomPower = Utilities.RandomEnumValue<PowerEnum>();
            //Console.WriteLine(randomPower.ToString());
            //var randomBodyStyle = Utilities.RandomEnumValue<BodyStyleEnum>();
            //Console.WriteLine(randomBodyStyle.ToString());
            //var randomFuel = Utilities.RandomEnumValue<FuelEnum>();
            //Console.WriteLine(randomFuel.ToString());

            //var bearingChange = Utilities.GenerateRandomBearingChangeForCar(330);
            //Console.WriteLine(bearingChange.ToString());

            Console.ReadLine();
            //38.88664603767084, -104.70403694901884
            //38.88546557708244, -104.71948984765054
        }
    }
}
