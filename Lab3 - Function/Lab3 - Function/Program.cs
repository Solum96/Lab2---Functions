// Nils Lundell och Sofia Lindgren
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3___Function
{
    class Program
    {

        static string startLocation;
        static double startLatitude;
        static double startLongitude;
        static string endLocation;
        static double endLatitude;
        static double endLongitude;
        static string[] Places = new string[] { "Stockholm", "Göteborg", "Oslo", "Luleå", "Helsinki", "Berlin", "Paris" };
        static double[] Latitudes = new double[] { 59.3261917, 57.7010496, 59.8939529, 65.5867395, 60.11021, 52.5069312, 48.859 };
        static double[] Longitudes = new double[] { 17.7018773, 11.6136602, 10.6450348, 22.0422998, 24.7385057, 13.1445521, 2.2069765 };
        static string[] Route;

        static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {
                try
                {

                    Console.WriteLine("Select a service:");
                    Console.WriteLine("[1] Find distance between two cities");
                    Console.WriteLine("[2] Find distance in route");
                    Console.WriteLine("[0] EXIT");
                    int menu = int.Parse(Console.ReadLine());   
                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            FindDistance();
                            break;

                        case 2:
                            Console.Clear();
                            FindRoute();
                            break;

                        case 0:
                            loop = false;
                            break;

                        default:
                            throw new Exception("Invalid command.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Use numbers.");
                }
            }
            
        }

        private static void FindRoute()
        {
            //TODO: Write method for FindRoute.
        }

        private static void FindDistance()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Select starting location: ");
                    Console.WriteLine("[1] Stockholm");
                    Console.WriteLine("[2] Göteborg");
                    Console.WriteLine("[3] Oslo");
                    Console.WriteLine("[4] Luleå");
                    Console.WriteLine("[5] Helsinki");
                    Console.WriteLine("[6] Berlin");
                    Console.WriteLine("[7] Paris");

                    int input = int.Parse(Console.ReadLine());
                    SetStartLocation(input);
                    if (input < 0 && input > 7) throw new ArgumentException("Choose a number between 1 and 7");

                    Console.WriteLine("Select end location: ");
                    Console.WriteLine("[1] Stockholm");
                    Console.WriteLine("[2] Göteborg");
                    Console.WriteLine("[3] Oslo");
                    Console.WriteLine("[4] Luleå");
                    Console.WriteLine("[5] Helsinki");
                    Console.WriteLine("[6] Berlin");
                    Console.WriteLine("[7] Paris");
                    input = int.Parse(Console.ReadLine());
                    SetEndLocation(input);
                    if (input < 0 && input > 7) throw new ArgumentException("Choose a number between 1 and 7");
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Use numbers.");
                }
                Console.Clear();
                Console.WriteLine("Press any button to continue. . .");
                Console.ReadKey();
                double distance = GetDistanceKilometers(startLatitude, endLatitude, startLongitude, endLongitude);
                Console.WriteLine($"Distance between {startLocation} and {endLocation} is {distance}km");
                Console.ReadKey();
            }
        }

        private static double GetDistanceKilometers(double xAxis1, double xAxis2, double yAxis1, double yAxis2)
        {
           double distance = (2 * 6371) * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((Degrees2Radians(xAxis2) - Degrees2Radians(xAxis1)) / 2), 2) + //
                Math.Cos(Degrees2Radians(xAxis1)) * Math.Cos(Degrees2Radians(xAxis2)) *                                                        // Calculates distance using Haversine Formula
                Math.Pow(Math.Sin((Degrees2Radians(yAxis2) - Degrees2Radians(yAxis1)) / 2), 2)));                                              //
            return Math.Round(distance, 2);
        }

        private static double Degrees2Radians(double degrees)
        {
            double radian = degrees * (Math.PI / 180);
            return radian;
        }

        private static void SetStartLocation(int menu)
        {
            startLocation = Places[menu - 1];
            startLatitude = Latitudes[menu - 1];
            startLongitude = Longitudes[menu - 1];
        }
        private static void SetEndLocation(int menu)
        {
            endLocation = Places[menu - 1];
            endLatitude = Latitudes[menu - 1];
            endLongitude = Longitudes[menu - 1];
        }
    }
}
