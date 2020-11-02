using System;
using System.IO;
using System.Linq;

using VatsimLibrary.VatsimClient;
using VatsimLibrary.VatsimDb;

namespace hw
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"{VatsimDbHepler.DATA_DIR}");

            using(var db = new VatsimDbContext())
            {
                //Query 1
                var _pilots = db.Pilots.Select(p => p).ToList();

                var time = from p in _pilots select p.TimeLogon;
                var maxTime = time.Max();

                var longestTime = 
                    from p in _pilots
                    where p.TimeLogon == maxTime
                    select p.Realname;

                Console.WriteLine(sepalWidth.ToList()[0]);

                //Query 2
                var _controllers = db.Controllers.Select(p => p).ToList();

                var time = from p in _controllers select p.TimeLogon;
                var maxTime = time.Max();

                var longestTime = 
                    from p in _controllers
                    where p.TimeLogon == maxTime
                    select p.Realname;

                Console.WriteLine(sepalLength.ToList()[0]);

                //Query 3
                var _flights = db.Flights.Select(f => f).ToList();

                var plannedDepAirports = 
                from flight in _flights
                group flight by flight.PlannedDepairport into flightGroup
                select new 
                {
                    Airport = flightGroup.Key,
                    CountOfDep = flightGroup.Count(),
                };

                List<int> countList = new List<int>();

                foreach (var f in plannedDepAirports)
                {
                    countList.Add(f.CountOfDep);
                }

                var DepAirports = 
                from highest in plannedDepAirports
                where highest.CountOfDep == countList.Max()
                select highest.Airport;

                Console.WriteLine(DepAirports.ToList()[0]); 

                //Query 4
                var _flights = db.Flights.Select(f => f).ToList();

                var plannedDestairports = 
                from flight in _flights
                group flight by flight.PlannedDestairport into flightGroup
                select new 
                {
                    Airport = flightGroup.Key,
                    counter = flightGroup.Count(),
                };

                List<int> countList = new List<int>();

                foreach (var f in plannedDestairports)
                {
                    countList.Add(f.counter);
                }

                var Destairports = 
                from highest in plannedDestairports
                where highest.counter == countList.Max()
                select highest.Airport;

                Console.WriteLine(Destairports.ToList()[0]);

                //Query 5
                var _flights = db.Flights.Select(f => f).ToList();

                var pilotAltitude = 
                from flight in _flights
                group flight by flight.Alitude into currentAltitude
                select new
                {
                    Altitude = currentAltitude.key,
                    CountofAltitudes = currentAltitude.Count(),
                };

                var pilotAltitude = 
                from flight in _flights
                orderby flight.
                select new
                {
                    Altitude = currentAltitude.key,
                    CountofAltitudes = currentAltitude.Count(),
                };


                var pilotName = 
                from flight in _flights
                group flight by flight.Realname into pilotInfo
                select new 
                {
                    Pilot = pilotInfo.Key,
                    CountofPilots = pilotInfo.Count(),
                };

                var pilotPlane = 
                from flight in _flights
                group flight by flight.
                
                //Query 6
                var _positions = db.Positions.Select(p => p).ToList();

                var newName = 
                from position in _positions
                group position by position.Realname into pilotName
                select new
                {
                    Name = pilotName.Key,
                    slowestSpeed = pilotName.Min(x => x.Groundspeed),
                };

                List<string> findingSlowest = new List<string>();

                foreach(var width in newName){
                    slowest.Add(width.slowestSpeed);
                }

                string min_Pilot_Speed = slowest.Min();

                var querySix = 
                from lowest in newName
                where lowest.slowestSpeed == min_Pilot_Speed
                select lowest.Name;

                Console.WriteLine(querySix.ToList()[0]);

                //Query 7
                var _flights = db.Flights.Select(p => p).ToList();
                var plannedAircraft = 
                    from p in _flights 
                    group p by p.PlannedAircraft into g                   
                    select new 
                    {
                        Key = g.Key, Count = g.Count()
                    };

                var result = plannedAircraft.Max(x => x.Count);
                var cls = plannedAircraft.Where(x => x.Count == result).First();

                Console.WriteLine("Class - {0} ", cls);
                Console.WriteLine("Count - {0} ", result);
               
   
                //Query 8
                var _positions = db.Positions.Select(p => p).ToList();

                var newName = 
                from position in _positions
                group position by position.Realname into pilotName
                select new
                {
                    Name = pilotName.Key,
                    fastestSpeed = pilotName.Max(x => x.Groundspeed),
                };

                List<string> fastest = new List<string>();

                foreach(var width in newName){
                    fastest.Add(width.fastestSpeed);
                }

                string max_Pilot_Speed = fastest.Max();

                var queryeight = 
                from highest in newName
                where highest.fastestSpeed == max_Pilot_Speed
                select highest.Name;

                Console.WriteLine(queryEight.ToList()[0]);

                //Query 9
                var _pilots = db.Pilots.Select(p => p).ToList();

                var direction = 
                from position in _positions
                select position.Heading;

                var North = 
                from degrees in direction
                where 90 <= Convert.ToInt32(degrees) && Convert.ToInt32(degrees) <= 270 select degrees;

                int pilots = North.Count();

                Console.WriteLine(pilots);
                
                //Query 10
                var _flights = db.Flights.Select(p => p).ToList();

                var pilot = 
                from flight in _flights
                group flight by flight.PlannedRemarks into remarks
                select new
                {
                    Name = remarks.Key,
                    LongestRemark = remarks.Max(x => x.PlannedRemarks)
                };

                List<string> FindingLongest = new List<string>();

                foreach(var width in pilot){
                    FindingLongest.Add(width.LongestRemark);
                }

                string LR = FindingLongest.Max();

                var queryTen = 
                from highest in pilot
                where highest.LongestRemark == LR
                select highest.Name;

                Console.WriteLine(queryTen.ToList()[0]);
            }

            //     var _pilots = db.Pilots.Select(p => p).ToList();
            //     Console.WriteLine($"The number of pilots records is: {_pilots.Count} ");

            //     //1238470                
            //     //UAL2865
            //     //20201013162413
            //     var _pilot = db.Pilots.Find("1238470", "UAL2865", "20201013162413");                
            //     if(_pilot != null){
            //         Console.WriteLine($"Pilot found: {_pilot.Realname}");
            //     } else {
            //         Console.WriteLine("Pilot not found");
            //     }                

            //     //1385451
            //     //N130JM
            //     //20201021233811
            //     _pilot = db.Pilots.Find("1385451", "N130JM", "20201021233811");
            //     if(_pilot != null){
            //         Console.WriteLine($"Pilot found: {_pilot.Realname}");
            //     } else {
            //         Console.WriteLine("Pilot not found");
            //     }

            //     //1484591
            //     //PAL922
            //     //20201028132105
            //     _pilot = db.Pilots.Find("1484591", "PAL922", "20201028132105");
            //     if(_pilot != null){
            //         Console.WriteLine($"Pilot found: {_pilot.Realname}");
            //     } else {
            //         Console.WriteLine("Pilot not found");
            //     }                
            // }            
        }
    }
}
