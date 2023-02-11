using System;

namespace Paradigms
{
	public static class MathUtils
	{
		public static double DegreesToRadians(double degrees)
		{
			return degrees * Math.PI / 180.0;
		}
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
	}
}
