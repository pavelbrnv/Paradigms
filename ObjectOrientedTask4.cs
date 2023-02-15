using System;

namespace Paradigms
{
	public abstract class BasePoint
	{
		public abstract double GetRadius();
	}
	
	public class Point3D : BasePoint
	{
		public double X { get; }

		public double Y { get; }

		public double Z { get; }
		
		public Point3D(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}
		
		public static Point3D FromPolarInRadians(double azimuthInRadians, double elevationInRadians, double radius)
		{
			Point2D pointInProjection = Point2D.FromPolarInRadians(elevationInRadians, radius);

			double radiusXY = pointInProjection.X;
			double z = pointInProjection.Y;

			Point2D pointXY = Point2D.FromPolarInRadians(azimuthInRadians, radiusXY);

			return new Point3D(pointXY.X, pointXY.Y, z);
		}

		public static Point3D FromPolarInDegrees(double azimuthInDegrees, double elevationInDegrees, double radius)
		{
			double azimuthInRadians = MathUtils.DegreesToRadians(azimuthInDegrees);
			double elevationInRadians = MathUtils.DegreesToRadians(elevationInDegrees);
			return FromPolarInRadians(azimuthInRadians, elevationInRadians, radius);
		}

		public override string ToString()
		{
			return $"X = {X}{Environment.NewLine}Y = {Y}{Environment.NewLine}Z = {Z}";
		}

		public static Point3D operator +(Point3D left, Point3D right)
		{
			return new Point3D(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
		}

		public static Point3D operator -(Point3D left, Point3D right)
		{
			return new Point3D(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
		}

		public override double GetRadius()
		{
			Point2D pointXY = new Point2D(X, Y);
			double radiusXY = pointXY.GetRadius();
			Point2D pointInProjection = new Point2D(radiusXY, Z);
			return pointInProjection.GetRadius();
		}
	}

	public abstract class PointsCalculator<TPoint>
		where TPoint : BasePoint
	{
		public abstract TPoint Addition(TPoint first, TPoint second);

		public abstract TPoint Subtraction(TPoint minuend, TPoint subtrahend);

		public abstract TPoint GetAverage(TPoint[] points);
		
		public double GetDistanceBetween(TPoint first, TPoint second)
		{
			var offset = Subtraction(first, second);
			return offset.GetRadius();
		}

		public double GetStandardDeviation(TPoint[] points, TPoint referencePoint)
		{
			var deviation = 0.0;

			foreach (var point in points)
			{
				var distance = GetDistanceBetween(point, referencePoint);
				deviation += distance * distance;
			}

			var standardDeviation = Math.Sqrt(deviation / points.Length);
			return standardDeviation;
		}

		public TPoint[] ShiftMany(TPoint[] points, TPoint offset)
		{
			TPoint[] shiftedPoints = new TPoint[points.Length];

			for (int i = 0; i < shiftedPoints.Length; i++)
			{
				shiftedPoints[i] = Addition(points[i], offset);
			}

			return shiftedPoints;
		}
	}

	public class Points3DCalculator : PointsCalculator<Point3D>
	{
		public override Point3D Addition(Point3D first, Point3D second)
		{
			return first + second;
		}

		public override Point3D Subtraction(Point3D minuend, Point3D subtrahend)
		{
			return minuend - subtrahend;
		}

		public override Point3D GetAverage(Point3D[] points)
		{
			double totalX = 0;
			double totalY = 0;
			double totalZ = 0;

			foreach (var point in points)
			{
				totalX += point.X;
				totalY += point.Y;
				totalZ += point.Z;
			}

			double averageX = totalX / points.Length;
			double averageY = totalY / points.Length;
			double averageZ = totalZ / points.Length;

			return new Point3D(averageX, averageY, averageZ);
		}
	}
}
