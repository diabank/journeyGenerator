namespace journeyGenerator
{
    public class Boat : Vehicle
    {
        /// <summary>
        /// The power field is the first additional field boats add to the vehicle line.It is ASCII text that will be one of
        ///“UNPOWERED”, “SAIL”, or “MOTOR”, case-insensitive and quotes excluded.
        /// </summary>
        public PowerEnum Power {  get; set; }

        /// <summary>
        /// The draft field is the second additional field boats add to the vehicle line. It shall contain a floating point value
        /// that will express the draft of the boat in feet.Draft is the vertical distance between the waterline and the
        ///bottom of the boat.
        /// </summary>
        public string Draft {  get; set; }

        /// <summary>
        /// The manufacturer field is the third additional field boats add to the vehicle line. It is free ASCII text that gives a
        /// human-readable name of the manufacturer of the boat.
        /// </summary>
        public BoatManufacturerEnum Manufacturer {  get; set; }

        public Boat()
        {
            Identifier = "BOAT";
            Weight = Utilities.RandomGenerator(1000, 5000).ToString("0.00");
            Width = Utilities.RandomDoubleGenerator(5, 10).ToString("0.00");
            Height = Utilities.RandomDoubleGenerator(5, 20).ToString("0.00");
            Length = Utilities.RandomDoubleGenerator(5, 160).ToString("0.00");
            Power = Utilities.GenerateValueOutofEnum<PowerEnum>();
            Draft = Utilities.RandomDoubleGenerator(5, 10).ToString("0.00");
            Manufacturer = Utilities.GenerateValueOutofEnum<BoatManufacturerEnum>();
        }

        public override string ToString()
        {
            return $"{Identifier},{Descriptor},{Weight},{Width},{Height},{Length},{Power},{Draft},{Manufacturer}";
        }
    }
}
