namespace journeyGenerator
{
    public class Waypoint
    {
        /// <summary>
        /// The latitude field is the first field of the waypoint line.It shall contain a floating point value that will express
        /// the latitude of this waypoint in decimal degrees.
        /// </summary>
        public string Latitude {  get; set; }

        /// <summary>
        /// The longitude field is the second field of the waypoint line.It shall contain a floating point value that will
        /// express the longitude of this waypoint in decimal degrees.
        /// </summary>
        public string Longitude {  get; set; }

        /// <summary>
        /// The delta time field is the third field of the waypoint line.It shall contain a floating point value that will express
        /// the change in time in number of seconds elapsed since the last waypoint
        /// </summary>
        public string DeltaTime {  get; set; }

        public Waypoint()
        {
                
        }

        public override string ToString()
        {
            return $"{Latitude},{Longitude},{DeltaTime}";
        }
    }
}
