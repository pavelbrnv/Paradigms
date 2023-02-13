using System;
using System.Collections.Generic;

namespace Paradigms
{
	public static class MathUtils
	{
		#region Base

		public static double DegreesToRadians(double degrees)
		{
			return degrees * Math.PI / 180.0;
		}

		#endregion

		#region Task 3

		public static Point2D GetAverage(IReadOnlyCollection<Point2D> points)
		{
			double totalX = 0;
			double totalY = 0;

			foreach (var point in points)
			{
				totalX += point.X;
				totalY += point.Y;
			}

			double averageX = totalX / points.Count;
			double averageY = totalY / points.Count;

			return new Point2D(averageX, averageY);
		}

		public static double GetStandardDeviation(IReadOnlyList<Point2D> points, Point2D referencePoint)
		{
			var deviation = 0.0;
			foreach (var point in points)
			{
				var distance = point.GetDistanceTo(referencePoint);
				deviation += distance * distance;
			}

			var standardDeviation = Math.Sqrt(deviation / points.Count);
			return standardDeviation;
		}

		#endregion
	}

	public class Point2D
	{
		#region Base

		public double X { get; }

		public double Y { get; }

		public Point2D(double x, double y)
		{
			X = x;
			Y = y;
		}
		
		public override string ToString()
		{
			return $"X = {X}{Environment.NewLine}Y = {Y}";
		}

		#endregion

		#region Task 1

		public static Point2D FromPolarInRadians(double angleInRadians, double radius)
		{
			double x = Math.Cos(angleInRadians) * radius;
			double y = Math.Sin(angleInRadians) * radius;

			return new Point2D(x, y);
		}

		public static Point2D FromPolarInDegrees(double angleInDegrees, double radius)
		{
			double angleInRadians = MathUtils.DegreesToRadians(angleInDegrees);
			return FromPolarInRadians(angleInRadians, radius);
		}

		#endregion

		#region Task 2

		public static Point2D operator +(Point2D left, Point2D right)
		{
			return new Point2D(left.X + right.X, left.Y + right.Y);
		}

		public static Point2D operator -(Point2D left, Point2D right)
		{
			return new Point2D(left.X - right.X, left.Y - right.Y);
		}

		#endregion

		#region Task 3

		public double GetDistanceTo(Point2D other)
		{
			var distanceSquare = Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2);
			return Math.Sqrt(distanceSquare);
		}

		#endregion
	}
}
