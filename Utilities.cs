namespace journeyGenerator
{
    public static class Utilities
    {
        /// <summary>
        /// Random Generator 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RandomGenerator(int min, int max)
        {
            Random rnd = new Random();
            var random = rnd.Next(min, max);
            return random;
        }

        /// <summary>
        /// Random Double Generator
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double RandomDoubleGenerator(int min, int max)
        {
            Random rnd = new Random();
            var random = rnd.Next(min, max);
            var randomDouble = rnd.NextDouble();

            return random + randomDouble;
        }

        /// <summary>
        /// Generate Value Out of Enum
        /// 'T' being an enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GenerateValueOutofEnum<T>()
        {
            Random _R = new Random();
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }

        /// <summary>
        /// Generate Random Number Of Waypoint
        /// There should be between 10 and 30 waypoints, inclusive
        /// </summary>
        /// <returns></returns>
        public static int GenerateRandomNumberOfWaypoint()
        {
            //Minus starting which is the first waypoint
            return RandomGenerator(9, 29);
        }

        /// <summary>
        /// Generate Random Waypoint Time Intervals
        /// </summary>
        /// <param name="numberOfWaypoint"></param>
        /// <param name="minTimeInterval"></param>
        /// <param name="maxTimeInterval"></param>
        /// <returns></returns>
        public static int[] GenerateRandomWaypointTimeIntervals(int numberOfWaypoint, int minTimeInterval, int maxTimeInterval) 
        {
            var arrayOfInts = new int[numberOfWaypoint];

            for (int i = 0; i < numberOfWaypoint; i++) 
            {
                arrayOfInts[i] = RandomGenerator(minTimeInterval, maxTimeInterval);
            }

            return arrayOfInts;
        }

        /// <summary>
        /// Generate Random Car Speed
        /// All cars travel between 25 and 60 miles per hour
        /// </summary>
        /// <returns></returns>
        public static int GenerateRandomCarSpeed()
        {
            return RandomGenerator(25, 60);
        }

        /// <summary>
        /// Generate Random Boat Speed based on type of boat
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GenerateRandomBoatSpeed(PowerEnum power) =>
        power switch
        {
            PowerEnum.SAIL => RandomGenerator(15, 30),
            PowerEnum.UNPOWERED => RandomGenerator(1, 10),
            PowerEnum.MOTOR => RandomGenerator(25, 60),
            _ => throw new ArgumentException("Invalid enum value for power", nameof(power))
        };


        /// <summary>
        /// Generate Random Bearing
        /// Range from 0 degree to 359 degree
        /// </summary>
        /// <returns></returns>
        public static int GenerateRandomBearing()
        {
            return RandomGenerator(0, 359);
        }

        /// <summary>
        /// Generate Random Bearing Change For Car
        /// Cars cannot turn more than 90 degrees between waypoints.
        /// </summary>
        /// <param name="currentBearing"></param>
        /// <returns></returns>
        public static int GenerateRandomBearingChangeForCar(int currentBearing)
        {
            var randomBearingChange = RandomGenerator(-90, 90);
            return AdjustBearing(currentBearing + randomBearingChange);
        }

        /// <summary>
        /// Generate Random Bearing Change For Boat
        /// Boats cannot turn more than 30 degrees between waypoints
        /// </summary>
        /// <param name="currentBearing"></param>
        /// <returns></returns>
        public static int GenerateRandomBearingChangeForBoat(int currentBearing)
        {
            var randomBearingChange = RandomGenerator(-30, 30);
            return AdjustBearing(currentBearing + randomBearingChange);
        }

        /// <summary>
        /// Adjust Bearing 
        /// Bearing should be between 0 and 360
        /// </summary>
        /// <param name="bearing"></param>
        /// <returns></returns>
        public static int AdjustBearing(int bearing) 
        {
            if(bearing < 0)
            {
                bearing = 360 - bearing;
            }

            if(bearing > 360) 
            {
                bearing = bearing - 360;
            }

            return bearing;
        }

        /// <summary>
        /// Generate Random Starting Waypoint For Car
        /// NB: staying Continental US for simplicity
        /// </summary>
        /// <returns>Tuple (int latitute, int longitude)</returns>
        public static (int latitute, int longitude) GenerateRandomStartingWaypointForCar()
        {
            var latitude = RandomGenerator(25, 50);
            var longitude = RandomGenerator(-120, -80);
            return (latitude, longitude);
        }

        /// <summary>
        /// Generate Random Starting Waypoint In specific Boat Zone
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static (int latitute, int longitude) GenerateRandomStartingWaypointInBoatZone(BoatZoneEnum zone) =>
        zone switch
        {
            BoatZoneEnum.Zone1 => GenerateRandomStartingWaypointInBoatZone1(),
            BoatZoneEnum.Zone2 => GenerateRandomStartingWaypointInBoatZone2(),
            BoatZoneEnum.Zone3 => GenerateRandomStartingWaypointInBoatZone3(),
            BoatZoneEnum.Zone4 => GenerateRandomStartingWaypointInBoatZone4(),
            _ => throw new ArgumentException("Invalid enum value for zone", nameof(zone))
        };


        /// <summary>
        /// Generate Random Starting Waypoint In Boat Zone 4
        /// NB: shaving off floating for simplicity
        /// </summary>
        /// <returns>Tuple (int latitute, int longitude)</returns>
        public static (int latitute, int longitude) GenerateRandomStartingWaypointInBoatZone4()
        {
            var latitude = RandomGenerator(-41, -2);
            var longitude = RandomGenerator(63, 94);
            return (latitude, longitude);
        }

        /// <summary>
        /// Generate Random Starting Waypoint In Boat Zone 3
        /// NB: shaving off floating for simplicity
        /// </summary>
        /// <returns>Tuple (int latitute, int longitude)</returns>
        public static (int latitute, int longitude) GenerateRandomStartingWaypointInBoatZone3()
        {
            var latitude = RandomGenerator(-43, 8);
            var longitude = RandomGenerator(-161, -98);
            return (latitude, longitude);
        }

        /// <summary>
        /// Generate Random Starting Waypoint In Boat Zone 2
        /// NB: shaving off floating for simplicity
        /// </summary>
        /// <returns>Tuple (int latitute, int longitude)</returns>
        public static (int latitute, int longitudee) GenerateRandomStartingWaypointInBoatZone2()
        {
            var latitude = RandomGenerator(-48, -7);
            var longitude = RandomGenerator(-28, 8);
            return (latitude, longitude);
        }

        /// <summary>
        /// Generate Random Starting Waypoint In Boat Zone 1
        /// NB: shaving off floating for simplicity
        /// </summary>
        /// <returns>Tuple (int latitute, int longitude)</returns>
        public static (int latitute, int longitude) GenerateRandomStartingWaypointInBoatZone1()
        {
            var latitude = RandomGenerator(16, 56);
            var longitude = RandomGenerator(-49, -24);
            return (latitude, longitude);
        }

        /// <summary>
        /// Is Boat Within Zone 1
        /// </summary>
        /// <param name="latitute"></param>
        /// <param name="longitude"></param>
        /// <returns>bool</returns>
        public static bool IsBoatWithinZone1(double latitute, double longitude)
        {
            if(latitute < 15.6 || latitute > 56.2)
                return false;

            if(longitude < -49.8 ||  longitude > -23.1)
                return false;

            return true;
        }

        /// <summary>
        /// Is Boat Within Zone 2
        /// </summary>
        /// <param name="latitute"></param>
        /// <param name="longitude"></param>
        /// <returns>bool</returns>
        public static bool IsBoatWithinZone2(double latitute, double longitude)
        {
            if (latitute < -48.8 || latitute > -6.9)
                return false;

            if (longitude < -28.6 || longitude > 8.2)
                return false;

            return true;
        }

        /// <summary>
        /// Is Boat Within Zone 3 
        /// </summary>
        /// <param name="latitute"></param>
        /// <param name="longitude"></param>
        /// <returns>bool</returns>
        public static bool IsBoatWithinZone3(double latitute, double longitude)
        {
            if (latitute < -43.4 || latitute > 8.1)
                return false;

            if (longitude < -161.4 || longitude > -98.4)
                return false;

            return true;
        }

        /// <summary>
        /// Is Boat Within Zone 4
        /// </summary>
        /// <param name="latitute"></param>
        /// <param name="longitude"></param>
        /// <returns>bool</returns>
        public static bool IsBoatWithinZone4(double latitute, double longitude)
        {
            if (latitute < -41.1 || latitute > -1.4)
                return false;

            if (longitude < 62.2 || longitude > 94.5)
                return false;

            return true;
        }
    }
}
