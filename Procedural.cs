using System;

namespace Paradigms
{
	public class Procedural
	{
		#region Task 1
		
		public static (double x, double y) ConvertFromPolarInDegreesToCartesian(double angleInDegrees, double radius)
		{
			double angleInRadians = DegreesToRadians(angleInDegrees);

			double x = Math.Cos(angleInRadians) * radius;
			double y = Math.Sin(angleInRadians) * radius;

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

		public static (double x, double y) AddPoints(double firstX, double firstY, double secondX, double secondY)
		{
			double x = firstX + secondX;
			double y = firstY + secondY;
			return (x, y);
		}

		#endregion

		#region Task 3

		/// <param name="points">
		/// In each row:
		/// Value by index 0 is angle in degrees.
		/// Value by index 1 is radius.
		/// </param>
		/// <returns>
		/// In each row:
		/// Value by index 0 is X.
		/// Value by index 1 is Y.
		/// </returns>
		public static double[,] ConvertManyFromPolarInDegreesToCartesian(double[,] points)
		{
			double[,] convertedPoints = new double[points.GetLength(0), 2];

			for (int i = 0; i < points.GetLength(0); i++)
			{
				double angleInDegrees = points[i, 0];
				double radius = points[i, 1];

				(double x, double y) = ConvertFromPolarInDegreesToCartesian(angleInDegrees, radius);
				convertedPoints[i, 0] = x;
				convertedPoints[i, 1] = y;
			}

			return convertedPoints;
		}

		/// <param name="points">
		/// In each row:
		/// Value by index 0 is initial X.
		/// Value by index 1 is initial Y.
		/// </param>
		/// <returns>
		/// In each row:
		/// Value by index 0 is shifted X.
		/// Value by index 1 is shifted Y.
		/// </returns>
		public static double[,] GetShiftedPoints(double[,] points, double offsetX, double offsetY)
		{
			double[,] shiftedPoints = new double[points.GetLength(0), 2];

			for (int i = 0; i < points.GetLength(0); i++)
			{
				double initialX = points[i, 0];
				double initialY = points[i, 1];

				(double x, double y) = AddPoints(initialX, initialY, offsetX, offsetY);
				shiftedPoints[i, 0] = x;
				shiftedPoints[i, 1] = y;
			}

			return shiftedPoints;
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

		public static double GetDistanceBetween(double firstX, double firstY, double secondX, double secondY)
		{
			var distanceSquare = Math.Pow(firstX - secondX, 2) + Math.Pow(firstY - secondY, 2);
			return Math.Sqrt(distanceSquare);
		}

		#endregion
	}
}
