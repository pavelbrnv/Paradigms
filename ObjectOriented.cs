using System;

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

		public static Point2D GetAverage(Point2D[] points)
		{
			double totalX = 0;
			double totalY = 0;

			foreach (var point in points)
			{
				totalX += point.X;
				totalY += point.Y;
			}

			double averageX = totalX / points.Length;
			double averageY = totalY / points.Length;

			return new Point2D(averageX, averageY);
		}

		public static double GetStandardDeviation(Point2D[] points, Point2D referencePoint)
		{
			var deviation = 0.0;

			foreach (var point in points)
			{
				var distance = point.GetDistanceTo(referencePoint);
				deviation += distance * distance;
			}

			var standardDeviation = Math.Sqrt(deviation / points.Length);
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

		public static Point2D[] ShiftMany(Point2D[] points, Point2D offset)
		{
			Point2D[] shiftedPoints = new Point2D[points.Length];

			for (int i = 0; i < shiftedPoints.Length; i++)
			{
				shiftedPoints[i] = points[i] + offset;
			}

			return shiftedPoints;
		}
		
		public double GetRadius()
		{
			return Math.Sqrt(X * X + Y * Y);
		}

		public double GetDistanceTo(Point2D other)
		{
			var offset = this - other;
			return offset.GetRadius();
		}

		#endregion
	}
}
