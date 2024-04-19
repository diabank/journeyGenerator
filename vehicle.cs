namespace journeyGenerator
{
    public abstract class Vehicle
    {
        /// <summary>
        /// The identifier field is the first field of the vehicle line.It is free ASCII text that will uniquely identify the type of
        /// vehicle.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The descriptor field is the second field of the vehicle line.It is free ASCII text that gives a human-readable
        /// description of the vehicle.
        /// </summary>
        public string Descriptor { get; set; }

        /// <summary>
        /// The weight field is the third field of the vehicle line.It shall contain a floating point value that will express the
        /// weight of the vehicle in pounds.
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// The width field is the fourth field of the vehicle line.It shall contain a floating point value that will express the
        /// width of the vehicle in feet.
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// The height field is the fifth field of the vehicle line.It shall contain a floating point value that will express the
        /// height of the vehicle in feet.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// The length field is the sixth field of the vehicle line.It shall contain a floating point value that will express the
        /// length of the vehicle in feet.
        /// </summary>
        public string Length { get; set; }

    }
}
