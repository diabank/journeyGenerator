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
        public double[] WaypointsTimeIntervals {  get; set; }

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
        /// Number Of Turn
        /// </summary>
        public int NumberOfTurn { get; set; }

        /// <summary>
        /// When is the Next Turn?
        /// </summary>
        public Queue<int> NextTurn { get; set; }

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
            WaypointsTimeIntervals = Utilities.GenerateRandomWaypointTimeIntervals(NumberOfWaypoints -1 , 1, 3599);
            
            // The vehicles must turn at least 3 times on their route.
            NumberOfTurn = Utilities.RandomGenerator(3, 10);
            NextTurn = Utilities.GenerateRandomTurningPoint(NumberOfWaypoints, NumberOfTurn);


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
        public void GenerateCarWayPoints()
        {
            if(!(Vehicle is Car)) 
            {
                throw new ApplicationException("Vehicle is not a car");
            }

            double currentLat = 0.00;
            double currentLong = 0.00;

            //default turning point is 2
            int nextTurningPoint = 2;

            //First Waypoint - Starting Point
            Waypoints.Add(new Waypoint()
            {
                Latitude = StartingLatitude,
                Longitude = StartingLongitude,
                DeltaTime = 0
            });

            currentLat = StartingLatitude;
            currentLong = StartingLongitude;
            nextTurningPoint = NextTurn.Dequeue();

            for(int i = 0; i < NumberOfWaypoints - 1; i++) 
            {
                //Convert Miles per hour to Feet per second
                var distanceTravelled = ((Speed * 5280)/3600) *  WaypointsTimeIntervals[i];
                double latCalculated = 0.00;
                double longCalculated = 0.00;

                //Is it time to turn?
                if(nextTurningPoint == (i+1) && NextTurn.Any())
                {
                    Bearing = Utilities.GenerateRandomBearingChangeForCar(Bearing);
                    nextTurningPoint = NextTurn.Dequeue();
                }

                //Get new waypoint coordinates 
                GeoCalc.GetEndingCoordinates(currentLat, currentLong, Bearing, distanceTravelled, out latCalculated, out longCalculated);

                var newWayPoint = new Waypoint()
                {
                    Latitude = Math.Round(latCalculated, 6),
                    Longitude = Math.Round(longCalculated, 6),
                    DeltaTime = WaypointsTimeIntervals[i]
                };


                Waypoints.Add(newWayPoint);

                currentLat = newWayPoint.Latitude;
                currentLong = newWayPoint.Longitude;
            }
        }

        /// <summary>
        /// Generate WayPoints
        /// </summary>
        public void GenerateBoatWayPoints()
        {
            if (!(Vehicle is Boat))
            {
                throw new ApplicationException("Vehicle is not a Boat");
            }

            //Boat boat = (Boat)Vehicle;

            double currentLat = 0.00;
            double currentLong = 0.00;

            //default turning point is 2
            int nextTurningPoint = 2;

            //First Waypoint - Starting Point
            Waypoints.Add(new Waypoint()
            {
                Latitude = StartingLatitude,
                Longitude = StartingLongitude,
                DeltaTime = 0
            });

            currentLat = StartingLatitude;
            currentLong = StartingLongitude;
            nextTurningPoint = NextTurn.Dequeue();

            for (int i = 0; i < NumberOfWaypoints - 1; i++)
            {
                //Convert Miles per hour to Feet per second
                var distanceTravelled = ((Speed * 5280) / 3600) * WaypointsTimeIntervals[i];
                double latCalculated = 0.00;
                double longCalculated = 0.00;
                int someNewBearing = 0;

                //Is it time to turn?
                if (nextTurningPoint == (i + 1) && NextTurn.Any())
                {
                    someNewBearing = Utilities.GenerateRandomBearingChangeForBoat(Bearing);
                    nextTurningPoint = NextTurn.Dequeue();
                }


                GeoCalc.GetEndingCoordinates(currentLat, currentLong, someNewBearing, distanceTravelled, out latCalculated, out longCalculated);

                if(!Utilities.IsBoatWithinZone(latCalculated, longCalculated, BoatZone)) 
                {
                    someNewBearing = Utilities.GenerateRandomBearingChangeForBoat(Bearing);
                    GeoCalc.GetEndingCoordinates(currentLat, currentLong, someNewBearing, distanceTravelled, out latCalculated, out longCalculated);
                }
                
                Bearing = someNewBearing;
                var newWayPoint = new Waypoint()
                {
                    Latitude = Math.Round(latCalculated, 6),
                    Longitude = Math.Round(longCalculated, 6),
                    DeltaTime = WaypointsTimeIntervals[i]
                };

                Waypoints.Add(newWayPoint);

                currentLat = newWayPoint.Latitude;
                currentLong = newWayPoint.Longitude;
            }
        }

        /// <summary>
        /// Generate and Write To File
        /// </summary>
        public void WriteToFile()
        {
            string fileName = "";
            dynamic vehicleBuilt = null;

            if (Vehicle is Car)
            {
                fileName = "carJourney.jny";
                vehicleBuilt = (Car)Vehicle;
            }
            else if (Vehicle is Boat)
            {
                fileName = "boatJourney.jny";
                vehicleBuilt = (Boat)Vehicle;
            }


            string docPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            using (StreamWriter outputFile = new StreamWriter(docPath))
            {
                outputFile.WriteLine(vehicleBuilt.ToString());

                foreach (var waypoint in Waypoints)
                {                    
                    outputFile.WriteLine(waypoint.ToString());
                }
            }
        }
    }
}
