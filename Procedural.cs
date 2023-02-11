using System;

namespace Paradigms
{
	public class Procedural
	{
		#region Task 1
		
		public static void Task1(double angleInDegrees, double distance)
		{
			double angleInRadians = DegreesToRadians(angleInDegrees);

			double x = Math.Cos(angleInRadians) * distance;
			double y = Math.Sin(angleInRadians) * distance;

			Print(x, y);
		}

		public static double DegreesToRadians(double degrees)
		{
			return degrees * Math.PI / 180.0;
		}

		public static void Print(double x, double y)
		{
			Console.WriteLine($"X = {x}{Environment.NewLine}Y = {y}");
		}

		#endregion

		#region Task 2

		public static void Task2(double radarX, double radarY, double detectedAngleInDegrees, double detectedDistance)
		{
			double detectedAngleInRadians = DegreesToRadians(detectedAngleInDegrees);

			double detectedOffsetX = Math.Cos(detectedAngleInRadians) * detectedDistance;
			double detectedOffsetY = Math.Sin(detectedAngleInRadians) * detectedDistance;

			double x = radarX + detectedOffsetX;
			double y = radarY + detectedOffsetY;

			Print(x, y);
		}

		#endregion
	}
}
