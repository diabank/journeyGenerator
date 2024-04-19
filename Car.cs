namespace journeyGenerator
{
    public class Car : Vehicle
    {
        /// <summary>
        /// The manufacturer field is the first additional field cars add to the vehicle line.It is free ASCII text that gives a
        /// human-readable name of the manufacturer of the car.
        /// </summary>
        public CarManufacturerEnum Manufacturer {  get; set; }

        /// <summary>
        /// The model year field is the second additional field cars add to the vehicle line. It is an unsigned integer value
        /// representing the model year of the vehicle.
        /// </summary>
        public string ModelYear { get; set; }

        /// <summary>
        /// The body style field is the third additional field cars add to the vehicle line. It is ASCII text that will be one of
        ///“COMPACT”, “COUPE”, “SEDAN”, “SPORTS”, “CROSSOVER”, “SUV”, “MINIVAN”, “VAN”, “TRUCK”, “BUS”, or
        ///“SEMI”, case-insensitive and quotes excluded.
        /// </summary>
        public BodyStyleEnum BodyStyle { get; set; }

        /// <summary>
        /// The fuel field is the fourth additional field cars add to the vehicle line. It is ASCII text that will be one of
        /// “REGULAR”, “DIESEL”, “HYBRID”, or “ELECTRIC”, case-insensitive and quotes excluded.
        /// </summary>
        public FuelEnum Fuel {  get; set; }

        public Car()
        {
            Identifier = "CAR";
            Weight = Utilities.RandomGenerator(1000, 5000).ToString("0.00");
            Width = Utilities.RandomDoubleGenerator(5, 10).ToString("0.00");
            Height = Utilities.RandomDoubleGenerator(5, 20).ToString("0.00");
            Length = Utilities.RandomDoubleGenerator(5, 160).ToString("0.00");
            Manufacturer = Utilities.GenerateValueOutofEnum<CarManufacturerEnum>();
            ModelYear = Utilities.RandomGenerator(1980, 2024).ToString();
            BodyStyle = Utilities.GenerateValueOutofEnum<BodyStyleEnum>();
            Fuel = Utilities.GenerateValueOutofEnum<FuelEnum>();
        }

        public override string ToString()
        {
            return $"{Identifier},{Descriptor},{Weight},{Width},{Height},{Length},{Manufacturer},{ModelYear},{BodyStyle},{Fuel}";
        }
    }
}
