using System;

namespace Paradigms
{
	public class Procedural
	{
		#region Task 1
		
		public static (double x, double y) ConvertFromPolarToCartesian(double angleInDegrees, double distance)
		{
			double angleInRadians = DegreesToRadians(angleInDegrees);

			double x = Math.Cos(angleInRadians) * distance;
			double y = Math.Sin(angleInRadians) * distance;

			return (x, y);
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
		
		public static (double x, double y) GetDetectedPoint(double radarX, double radarY, double detectedAngleInDegrees, double detectedDistance)
		{
			(double detectedOffsetX, double detectedOffsetY) = ConvertFromPolarToCartesian(detectedAngleInDegrees, detectedDistance);

			double x = radarX + detectedOffsetX;
			double y = radarY + detectedOffsetY;

			return (x, y);
		}

		#endregion

		#region Task 3

		/// <param name="detections">
		/// In each row:
		/// Value by index 0 is detected angle in degrees.
		/// Value by index 1 is detected distance.
		/// </param>
		/// <returns>
		/// In each row:
		/// Value by index 0 is detected X.
		/// Value by index 1 is detected Y.
		/// </returns>
		public static double[,] GetDetectedPoints(double radarX, double radarY, double[,] detections)
		{
			double[,] radarDetections = new double[detections.GetLength(0), detections.GetLength(1)];

			for (int i = 0; i < detections.GetLength(0); i++)
			{
				double detectedAngleInDegrees = detections[i, 0];
				double detectedDistance = detections[i, 1];

				(double x, double y) = GetDetectedPoint(radarX, radarY, detectedAngleInDegrees, detectedDistance);
				radarDetections[i, 0] = x;
				radarDetections[i, 1] = y;
			}

			return radarDetections;
		}

		/// <param name="points">
		/// In each row:
		/// Value by index 0 is point X.
		/// Value by index 1 is point Y.
		/// </param>
		public static (double x, double y) GetAveragePoint(double[,] points)
		{
			double totalX = 0;
			double totalY = 0;

			for (int i = 0; i < points.GetLength(0); i++)
			{
				double pointX = points[i, 0];
				double pointY = points[i, 1];

				totalX += pointX;
				totalY += pointY;
			}

			double averageX = totalX / points.GetLength(0);
			double averageY = totalY / points.GetLength(0);

			return (averageX, averageY);
		}

		public static double GetDistanceBetween(double point1X, double point1Y, double point2X, double point2Y)
		{
			var distanceSquare = Math.Pow(point1X - point2X, 2) + Math.Pow(point1Y - point2Y, 2);
			return Math.Sqrt(distanceSquare);
		}

		/// <param name="points">
		/// In each row:
		/// Value by index 0 is point X.
		/// Value by index 1 is point Y.
		/// </param>
		public static double GetStandardDeviation(double[,] points, double referenceX, double referenceY)
		{
			var deviation = 0.0;

			for (int i = 0; i < points.GetLength(0); i++)
			{
				double pointX = points[i, 0];
				double pointY = points[i, 1];

				var distance = GetDistanceBetween(referenceX, referenceY, pointX, pointY);
				deviation += distance * distance;
			}
			
			var standardDeviation = Math.Sqrt(deviation / points.GetLength(0));
			return standardDeviation;
		}

		#endregion
	}
}
