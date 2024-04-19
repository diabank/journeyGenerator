using SNC;

namespace journeyGenerator
{
    public class Journey
    {
        /// <summary>
        /// Class Vehicle
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// List of Waypoints
        /// </summary>
        public List<Waypoint> Waypoints { get; set; }

        /// <summary>
        /// Number Of Waypoint
        /// </summary>
        public int NumberOfWaypoints { get; set; }

        /// <summary>
        /// WaypointsTimeIntervals
        /// </summary>
        public int[] WaypointsTimeIntervals {  get; set; }
        /// <summary>
        /// Bearing
        /// </summary>
        public int Bearing { get; set; }
        /// <summary>
        /// Starting Latitude
        /// </summary>
        public double StartingLatitude { get; set; }
        /// <summary>
        /// Starting Longitude
        /// </summary>
        public double StartingLongitude { get; set; }
        /// <summary>
        /// Boat Zone
        /// </summary>
        public BoatZoneEnum BoatZone { get; set; }

        /// <summary>
        /// vehicle Speed
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Journey() 
        {
            Waypoints = new List<Waypoint>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vehicle">Vehicle doing the journey</param>
        /// <exception cref="ApplicationException"></exception>
        public Journey(Vehicle vehicle)
        {
            Vehicle = vehicle;
            Waypoints = new List<Waypoint>();
            NumberOfWaypoints = Utilities.GenerateRandomNumberOfWaypoint();
            WaypointsTimeIntervals = Utilities.GenerateRandomWaypointTimeIntervals(NumberOfWaypoints -1 , 1, 3600);

            if(vehicle is Boat)
            {
                BoatZone = Utilities.GenerateValueOutofEnum<BoatZoneEnum>();
                var startingPointLatLong = Utilities.GenerateRandomStartingWaypointInBoatZone(BoatZone);
                StartingLatitude = startingPointLatLong.latitute;
                StartingLongitude = startingPointLatLong.longitude;
                Bearing = Utilities.GenerateRandomBearing();
                Boat boat = (Boat)vehicle;
                Speed = Utilities.GenerateRandomBoatSpeed(boat.Power);
            }
            else if(vehicle is Car)
            {
                var startingPointLatLong = Utilities.GenerateRandomStartingWaypointForCar();
                StartingLatitude = startingPointLatLong.latitute;
                StartingLongitude = startingPointLatLong.longitude;
                Bearing = Utilities.GenerateRandomBearing();
                Speed = Utilities.GenerateRandomCarSpeed();
            }
            else
            {
                throw new ApplicationException("Please Send Car or Boat in Journey Constructor");
            }
        }

        /// <summary>
        /// Generate WayPoints
        /// </summary>
        public void GenerateWayPoints()
        {
            double currentLat = 0.00;
            double currentLong = 0.00;

            Waypoints.Add(new Waypoint()
            {
                Latitude = StartingLatitude.ToString(),
                Longitude = StartingLongitude.ToString(),
                DeltaTime = "0"
            });

            currentLat = StartingLatitude;
            currentLong = StartingLongitude;

            for(int i = 0; i < NumberOfWaypoints - 1; i++) 
            {
                //Convert Miles per hour to Feet per second
                var distanceTravelled = ((Speed * 5280)/3600) *  WaypointsTimeIntervals[i];
                double latCalculated = 0.00;
                double longCalculated = 0.00;

                //Get new waypoint coordinates 
                GeoCalc.GetEndingCoordinates(currentLat, currentLong, Bearing, distanceTravelled, out latCalculated, out longCalculated);

                Waypoints.Add(new Waypoint()
                {
                    Latitude = latCalculated.ToString(),
                    Longitude = longCalculated.ToString(),
                    DeltaTime = WaypointsTimeIntervals[i].ToString()
                });

                currentLat = latCalculated;
                currentLong = longCalculated;
            }
        }

        /// <summary>
        /// Generate and Write To File
        /// </summary>
        public void WriteToFile()
        {

        }
    }
}
