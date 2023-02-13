using System;
using System.Collections.Generic;
using System.Linq;

namespace Paradigms
{
	public sealed class Cartesian2D
	{
		public double X { get; private init; }

		public double Y { get; private init; }
		
		public static Cartesian2D Create(double x, double y)
		{
			return new Cartesian2D
			{
				X = x,
				Y = y
			};
		}
	}
	
	public sealed class Polar2D
	{
		public double AngleInRadians { get; private init; }

		public double Radius { get; private init; }

		public static Polar2D Create(double angleInRadians, double radius)
		{
			return new Polar2D
			{
				AngleInRadians = angleInRadians,
				Radius = radius
			};
		}
	}
	
	public static class CoordinatesExtensions
	{
		#region Task 1

		public static double ToRadians(this double angleInDegrees)
		{
			return angleInDegrees * Math.PI / 180.0;
		}

		public static Cartesian2D ToCartesian2D(this Polar2D point)
		{
			return Cartesian2D.Create(
				x: Math.Cos(point.AngleInRadians) * point.Radius,
				y: Math.Sin(point.AngleInRadians) * point.Radius);
		}

		public static string GetDescription(this Cartesian2D point)
		{
			return $"X = {point.X}{Environment.NewLine}Y = {point.Y}";
		}

		#endregion

		#region Task 2

		public static Cartesian2D Shift(this Cartesian2D point, Cartesian2D offset)
		{
			return Cartesian2D.Create(
				x: point.X + offset.X,
				y: point.Y + offset.Y);
		}

		#endregion

		#region Task 3

		public static Cartesian2D GetAverage(this IReadOnlyCollection<Cartesian2D> points)
		{
			return Cartesian2D.Create(
				x: points.Average(point => point.X),
				y: points.Average(point => point.Y));
		}

		#endregion
	}
}
